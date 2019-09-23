using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexBullet : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 50f;
    public GameObject impactEffect;
    public Rigidbody2D rb;
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
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
