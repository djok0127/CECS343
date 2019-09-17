using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public int damage = 100;
    public GameObject impactEffect;
    public float followTime = 10f;
    private float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        counter += Time.deltaTime;
        if (counter > followTime)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Follow bullet destroy");
        }
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log(hitInfo.gameObject.tag);
        Player player= hitInfo.gameObject.GetComponent<Player>();
        
        if (player!=null)
        {
            Debug.Log("Player Hit!");
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
    }

}
