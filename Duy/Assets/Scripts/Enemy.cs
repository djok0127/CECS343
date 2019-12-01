using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRange;
    
    public float damage;
    public float speed;
    protected float lastAttackTime;
    public float attackDelay;

    public bool facingRight = true;

    public float maxHealth;
    protected float currentHealth;
    
    public int points;
    public GameObject deathEffect;
    public bool knockFromRight;
    public float knockBackx;
    protected Player player;
    protected float oldPosition;
    protected Rigidbody2D rigidbody2d;
    protected Spawner spawner;
   
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
   

    virtual public void TakeDamage(float damage)
    {

    }
    
    public float getCurrentHealth()
    {
        return currentHealth;
    }
    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
