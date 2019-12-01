using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 300f;
    public GameObject impactEffect;
    private Rigidbody2D rb;
    public float travelTime = 20f;
    private float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= travelTime)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log(hitInfo.gameObject.tag);
        Player player = hitInfo.gameObject.GetComponent<Player>();

        if (player != null)
        {
            //Debug.Log("Player Hit!");
            player.TakeDamage(damage);

            var playerControl = hitInfo.gameObject.GetComponent<Controller>();
            var playerLocation = hitInfo.gameObject.GetComponent<Transform>();
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
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
