using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxMana = 50f;
    private float currentMana = 0f;
    private float currentHealth;
    [SerializeField] private Stat health;
    [SerializeField] private Stat mana;
    public Animator animator;
    private bool isHurt = false;
    private Enemy enemy;
    public RectTransform canvasTransform;
    private int points = 0;
    [SerializeField]private Text pointText;

    public float delayTime;
    private float curTime = 0;
    void Start()
    {
        //health = GameObject.FindGameObjectWithTag("Health").GetComponent<Stat>();
        enemy = GetComponent<Enemy>();
        health.Initialize(maxHealth, maxHealth);
        mana.Initialize(currentMana, maxMana);
        currentHealth = maxHealth;
    }
    public float MyMana
    {
        get
        {
            return currentMana;
        }
        set
        {
            currentMana += value;
            if (currentMana > maxMana)
            {
                currentMana = maxMana;
            }
            mana.MyCurrentValue = currentMana;
        }
    }
    public int MyPoints
    {
        get
        {
            return points;
        }
        set
        {
            points += value;
            pointText.text = "Scores: " + points;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        CombatTextManager.Instance.CreateText(transform.position, "-"+damage.ToString(), Color.red, canvasTransform, new Vector3(0f, 1f, 0f));
        health.MyCurrentValue = currentHealth;
        isHurt = true;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        animator.SetBool("isHurt", isHurt);
        isHurt = false;
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
            mana.MyCurrentValue = maxMana;
        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHealth+= 10f;
            CombatTextManager.Instance.CreateText(transform.position, "+10", Color.green, canvasTransform, new Vector3(0f, 1f, 0f));
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
                health.MyCurrentValue = maxHealth;
            }
            else
            {
                health.MyCurrentValue = currentHealth;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (curTime<delayTime)
        {
            if (col.gameObject.tag.Equals("Enemy"))
            {
                Enemy enemy = col.gameObject.GetComponent<Enemy>();
                TakeDamage(enemy.damageDealt);
                
                Debug.Log("Player Hit!");
            }
            curTime = delayTime;
        }
        else
        {
            curTime -= Time.deltaTime;
            
        }
        if (col.gameObject.tag.Equals("Platform"))
        {
            transform.parent = col.transform;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Platform"))
        {
            transform.parent = null;
        }
    }
}
