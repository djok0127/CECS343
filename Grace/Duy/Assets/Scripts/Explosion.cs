using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage = 500;
    public float duration = 3f;
    private float count=0f;
    
    void Update()
    {
        count += Time.deltaTime;
        if (count > duration)
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
            
            //Destroy(gameObject);
        }
    }
}
