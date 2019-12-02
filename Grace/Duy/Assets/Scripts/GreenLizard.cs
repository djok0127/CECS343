using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenLizard : Boss
{
    private Transform initialPos;
    public int maxAttack;
    private int attackCount = 0;
    public float idleTime;
    private float idleCount = 0f;
    public float moveBackDistance;
    
   
    //add boss special prefab here
    public GameObject slashEffect;
    public Transform attackPoint;
    public Transform attackPoint2;

    //boss rage mode ability
    public GameObject energyWave;
    

    public Animator animator;
    
    
    private Transform target;
    
    private float distanceToPlayer;

    private float initialx;
    

    //some variable that boss need to be trigger once
    private bool stageOne = true, stageTwo = true, stageThree = true;
    //stage2 counting variables
    private float spCounter = 0f;
    
    void Start()
    {
        //initialy = GetComponent<Transform>().position.y;
        Initialize();
        initialx = GetComponent<Transform>().position.x;
        oldPosition = initialx;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentFill = currentHealth / maxHealth;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentFill, Time.deltaTime * 2f);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distanceToPlayer = Vector2.Distance(transform.position, target.position);
        

        //boss mechanic for stage 1
        if (currentHealth / maxHealth >= .6f)
        {
            if (stageOne)
            {
                Say("COME HERE LITTLE FOX!", 5f);
                stageOne = false;
            }
            AttackPattern();
            
        }
        //boss stage2
        else if (currentHealth / maxHealth >= .2f)
        {
            //boss will start to use his special attack
            if (stageTwo)
            {
                Say("MUHAHAHAHA! YOU THINK YOU ALREADY WON?", 10f);
                SoundManager.PlaySound("laugh");
              
                RangeAttack();
                
                stageTwo = false;
            }
            int rand = Random.Range(0, 101);
            if (rand <= 30)//% boss will perform his special range attack
            {
                spCounter += Time.deltaTime;
                if (spCounter > 2)
                {
                    //SoundManager.PlaySound("laugh");
                    Say("TRY DODGING THIS!", 5f);
                    RangeAttack();
                    spCounter = 0f;

                }
                else
                {
                    AttackPattern();
                }
            }
            else
            {
                AttackPattern();
            }

        }
        //boss stage 3
        else
        {
            //boss double speed, damage, maxAttack, defense and idleTime reduce by half
            if (stageThree)
            {
                SoundManager.PlaySound("roar");
                Say("I WILL SLICE YOU OPEN!!!",10f);
                damage = damage * 2;
                speed = speed * 2;
                maxAttack = maxAttack * 2;
                idleTime = idleTime/2;
                defense = defense * 2;
                stageThree = false;

            }
            AttackPattern();
        }
     
    }
    void AttackPattern()
    {
        if (attackCount >= maxAttack)
        {
            animator.SetBool("attacking", false);
            animator.SetFloat("speed", speed);
            //allow time for the boss to move
            idleCount += Time.deltaTime;
            if (idleCount < idleTime)
            {
                //player is on my right
                if (transform.position.x > target.position.x)
                {

                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(transform.position.x + moveBackDistance, transform.position.y), speed * Time.deltaTime);
                }
                //player is on my left
                else
                {

                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(transform.position.x - moveBackDistance, transform.position.y), speed * Time.deltaTime);
                }
            }
            //idle time is up
            else
            {
                //reset attackCount and idleTime
                attackCount = 0;
                idleCount = 0f;
            }
        }
        //else boss do the normal attack mechanic
        else
        {
            if (distanceToPlayer < attackRange)
            {
                //boss.Say("Die!", 1f);
                MeleeAttack();
            }
            else
            {

                animator.SetFloat("speed", speed);
                animator.SetBool("attacking", false);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        PositionCheck();
    }
    public override void TakeDamage(float damage)
    {
        float damageDealt = damage - defense;
        if (damageDealt < 0)
        {
            damageDealt = 0f;
        }
        currentHealth -= damageDealt;
        CombatTextManager.Instance.CreateText(transform.position, "-" + damageDealt.ToString(), Color.red, canvasTransform, new Vector3(0f, 1f, 0f));
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            spawner.isDead();
            player.MyPoints = points;
            SoundManager.PlaySound("deathsound");
            RemoveUI();
            Destroy(gameObject);
        }
    }
    void MeleeAttack()
    {
        if (Time.time > lastAttackTime + attackDelay)
        {
            attackCount++;
            Instantiate(slashEffect, attackPoint.position, attackPoint.rotation);
            
            SoundManager.PlaySound("swordswing");
            animator.SetFloat("speed", 0f);
            animator.SetBool("attacking", true);
            player.TakeDamage(damage);
            lastAttackTime = Time.time;
            var playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
            var playerPosition= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            playerControl.knockBackCount = playerControl.knockBackLength;
            if (playerPosition.position.x < transform.position.x)
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
            animator.SetBool("attacking", false);
            animator.SetFloat("speed", speed);
        }
    }
    void RangeAttack()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        PositionCheck();
        Instantiate(energyWave, attackPoint2.position, attackPoint2.rotation);
           
        SoundManager.PlaySound("energywave");
        animator.SetFloat("speed", 0f);
        animator.SetBool("attacking", true);
        
    }
    void PositionCheck()
    {
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
