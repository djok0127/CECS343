﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private StatEnemy hitPoint;
    public float maxHealth = 100f;
    private float currentHealth;
    public float damageDealt = 10f;
    public int points;
    public GameObject deathEffect;
    private Player playerScore;
    private float oldPosition;
   
    void Awake()
    {
        playerScore= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentHealth = maxHealth;
        hitPoint.Initialize(maxHealth, maxHealth);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        hitPoint.MyCurrentValue = currentHealth;
        if (currentHealth <= 0)
        {
            playerScore.MyPoints = points;
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Death"))
        {
            Destroy(gameObject);
        }
    }



}
