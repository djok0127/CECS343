using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWave : MonoBehaviour
{
    public float destroyDistance;
    public float damage;
    public float speed;
    public GameObject impactEffect;
    private Rigidbody2D rb;
    private float startDistance;
    void Start()
    {
        startDistance = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
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
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            var playerControl = hitInfo.GetComponent<Controller>();
            var playerLocation = hitInfo.GetComponent<Transform>();
            playerControl.knockBackCount = playerControl.knockBackLength;
            if (playerLocation.position.x < transform.position.x)
            {
                playerControl.knockFromRight = true;
            }
            else
            {
                playerControl.knockFromRight = false;
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
