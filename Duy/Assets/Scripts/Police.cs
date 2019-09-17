﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    public float attackRange;
    private float damage;
    public float speed;
    private float lastAttackTime;
    public float attackDelay;
    
    private bool facingRight = true;
    private float oldPosition = 0f;
    private Transform targetPosition;
    private Player player;
    private Rigidbody2D rb;
    public Animator animator;

    //**************
    public LayerMask whatIsGround;
    public Transform groundCheck;
    private float checkRadius=.5f;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        damage = GetComponent<Enemy>().damageDealt;
        
    }

    // Update is called once per frame
    void Update()
    {
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
                transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
            }
            if (transform.position.x > oldPosition && !facingRight)
            {
                Flip();
            }
            else if (transform.position.x < oldPosition && facingRight)
            {
                Flip();
            }
            oldPosition = transform.position.x;
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
    
    private IEnumerator PlayAnimInterval(int n, float time)
    {
        animator.SetBool("meleeAttack", true);
        while (n > 0)
        {
            //ani.Play("Police_meele_attack", -1, 0F);
            --n;
            yield return new WaitForSeconds(time);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
