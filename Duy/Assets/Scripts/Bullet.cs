using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public GameObject impactEffect;
    public Rigidbody2D rb;
    public Transform playerLocation;
    public float destroyDistance;
    private float startDistance;
    // Start is called before the first frame update
    void Start()
    {
        startDistance = transform.position.x;
        rb.velocity = transform.right * speed;
        
    }
    void Update()
    {
        float totalDistance = Mathf.Abs(transform.position.x - startDistance);
        if (totalDistance > destroyDistance)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Debug.Log("I'm getting destroy here!");
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.tag);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Boss boss = hitInfo.GetComponent<Boss>();
        //Character player = hitInfo.GetComponent<Character>();
        if (hitInfo.name !="Character"&&hitInfo.name!="Projectile(Clone)")
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            if(boss != null)
            {
                boss.TakeDamage(damage);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
}
