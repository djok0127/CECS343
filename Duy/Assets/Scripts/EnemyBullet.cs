using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed=50f;
    public float damage = 5f;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 moveDirection = (target.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player!=null)
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
