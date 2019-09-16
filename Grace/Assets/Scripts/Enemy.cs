using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float knockBackPwr = 1000f;
    public Rigidbody2D rb;
    private float oldPosition;
    void Start()
    {
        oldPosition = transform.position.x;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (transform.position.x > oldPosition)
        {
            rb.AddForce(new Vector2(transform.position.x-knockBackPwr, transform.position.y));
        }
        else if (transform.position.x < oldPosition)
        {
            rb.AddForce(new Vector2(transform.position.x + knockBackPwr, transform.position.y));
        }
        oldPosition = transform.position.x;
        //rb.AddForce(new Vector2(transform.position.x * knockBackPwr, transform.position.y));
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
