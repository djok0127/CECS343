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
    public bool knockFromRight;
    public float knockBackx;
    private Player player;
    private float oldPosition;
    private Rigidbody2D rigidbody2d;
    private Spawner spawner;
   
    void Awake()
    {
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        currentHealth = maxHealth;
        hitPoint.Initialize(maxHealth, maxHealth);
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Transform targetPosition=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (targetPosition.position.x < transform.position.x)
        {
            knockFromRight = false;
        }
        else
        {
            knockFromRight = true;
        }
    }
    
    public void TakeDamage(float damage)
    {
        
        if (knockFromRight)
        {
            transform.position = new Vector2(transform.position.x - knockBackx, transform.position.y);
            Debug.Log("knock back right");
        }
        if (!knockFromRight)
        {
            transform.position = new Vector2(transform.position.x+knockBackx, transform.position.y);
            Debug.Log("knock back left");
        }
        CombatTextManager.Instance.CreateText(transform.position, damage.ToString(), Color.red, canvasTransform,new Vector3(0f,1f,0f));
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
    public float getCurrentHealth()
    {
        return currentHealth;
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
