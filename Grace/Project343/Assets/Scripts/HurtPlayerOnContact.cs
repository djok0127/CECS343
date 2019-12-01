using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    private float curTime = 0;
    public float delayTime = 1;
    public GameObject enemyType;
    private Enemy enemy;
    private float damage;
    void Start()
    {
        enemy = enemyType.GetComponent<Enemy>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (curTime < delayTime)
        {
            if (col.gameObject.tag.Equals("Player"))
            {
                Player player = col.gameObject.GetComponent<Player>();
                player.TakeDamage(enemy.damageDealt);
                Debug.Log("Player Hit!");
                var playerControl = col.gameObject.GetComponent<Controller>();
                var playerLocation = col.gameObject.GetComponent<Transform>();
                playerControl.knockBackCount = playerControl.knockBackLength;
                if (playerLocation.position.x < transform.position.x)
                {
                    playerControl.knockFromRight = true;
                }
                else
                {
                    playerControl.knockFromRight = false;
                }
            }
            curTime = delayTime;
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
}
