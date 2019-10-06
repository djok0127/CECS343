using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private StatEnemy hitPoint;
    public RectTransform canvasTransform;
    public float maxHealth = 100f;
    private float currentHealth;
    public float damageDealt = 10f;
    public int points;
    public GameObject deathEffect;
    private Player player;
    private float oldPosition;
   
    void Awake()
    {
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentHealth = maxHealth;
        hitPoint.Initialize(maxHealth, maxHealth);
    }
    public void TakeDamage(float damage)
    {
        CombatTextManager.Instance.CreateText(transform.position, damage.ToString(), Color.red, canvasTransform,new Vector3(0f,1f,0f));
        currentHealth -= damage;
        hitPoint.MyCurrentValue = currentHealth;
        if (currentHealth <= 0)
        {
            player.MyPoints = points;
            player.MyMana = points; 
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
