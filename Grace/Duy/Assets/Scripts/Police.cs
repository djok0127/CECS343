using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : Normal
{
    
    //private float oldPosition = 0f;
    private Transform targetPosition;
    
    private Rigidbody2D rb;
    public Animator animator;
    //private Enemy police;
    //**************
    public LayerMask whatIsGround;
    public Transform groundCheck;
    private float checkRadius=.5f;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
        rb = GetComponent<Rigidbody2D>();
        
        //police = GetComponent<Enemy>();
        
        hitPoint.Initialize(maxHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (targetPosition.position.x < transform.position.x)
        {
            knockFromRight = false;
        }
        else
        {
            knockFromRight = true;
        }
        if (isGrounded)
        {
            
            float distanceToPlayer = Vector2.Distance(transform.position, targetPosition.position);
            if (distanceToPlayer < attackRange)
            {
                animator.SetFloat("speed", 0f);
                MeleeAttack();
            }
            else
            {
                animator.SetFloat("speed", speed);
                animator.SetBool("meleeAttack", false);
                //Shoot();
                transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
            }
            if (transform.position.x < targetPosition.position.x && !facingRight)
            {
                Flip();
            }
            else if (transform.position.x > targetPosition.position.x && facingRight)
            {
                Flip();
            }
            //oldPosition = transform.position.x;
        }

    }
    public override void TakeDamage(float damage)
    {
        if (knockFromRight)
        {
            transform.position = new Vector2(transform.position.x - knockBackx, transform.position.y);
            Debug.Log("knock back right");
        }
        if (!knockFromRight)
        {
            transform.position = new Vector2(transform.position.x + knockBackx, transform.position.y);
            Debug.Log("knock back left");
        }
        CombatTextManager.Instance.CreateText(transform.position, damage.ToString(), Color.red, canvasTransform, new Vector3(0f, 1f, 0f));
        currentHealth -= damage;
        SoundManager.PlaySound("hit");
        hitPoint.MyCurrentValue = currentHealth;
        if (currentHealth <= 0)
        {
            spawner.ReduceEnemyCount();
            player.MyPoints = points;
            player.MyMana = points;
            Die();
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    void MeleeAttack()
    {
        if (Time.time > lastAttackTime + attackDelay)
        {
            player.TakeDamage(damage);
            lastAttackTime = Time.time;
            animator.SetBool("meleeAttack", true);
            var playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
            //var playerLocation = hitInfo.gameObject.GetComponent<Transform>();
            playerControl.knockBackCount = playerControl.knockBackLength;
            if (targetPosition.position.x < transform.position.x)
            {
                playerControl.knockFromRight = true;
            }
            else
            {
                playerControl.knockFromRight = false;
            }
            
        }
        else
        {
            animator.SetBool("meleeAttack", false);
        }   
    }
    
    
}
