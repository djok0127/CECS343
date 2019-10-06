using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public Transform dropPoint;
    public float speed = 20f;
    public GameObject bombPrefab;
    public GameObject policePrefab;
    private Enemy enemy;
    public float bonusHealth=10f;
    public float bonusDamage = 1f;
    public float dropInterval=1f;
    public float deathTime = 30f;
    private float counter1=0f;
    private float timer = 0f;
    private Rigidbody2D rb;
    private int number;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = policePrefab.GetComponent<Enemy>();
        //rb.velocity = transform.right * speed;
        Random.seed = (int)System.DateTime.Now.Ticks;
        number = Random.Range(1, 101);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            enemy.maxHealth += bonusHealth;
            enemy.damageDealt += bonusDamage;
            //bonusStat += 10f;
            timer = 0f;
        }
        counter1 += Time.deltaTime;
        
        if (counter1 >= dropInterval)
        {

            //suppose to be 30% that police will drop

            DropPolice();
            counter1 = 0f;
        }
        
    }
    void DropBomb()
    {
        Instantiate(bombPrefab, dropPoint.position, dropPoint.rotation);
    }
    void DropPolice()
    {
        
        Instantiate(policePrefab, dropPoint.position, policePrefab.GetComponent<Transform>().rotation);
    }
}
