using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexPlayer : MonoBehaviour
{
    public float pullForce = 20f;
    public float pullDistance = 30f;
    public float duration = 5f;
    public GameObject afterEffect;
    private float count = 0f;
    private Enemy enemy;
    public float damage = 3f;
    private Transform enemyPosition;
    public LayerMask whatIsEnemy;
    private bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        enemyPosition = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            enemyPosition.transform.position = Vector2.MoveTowards(enemyPosition.transform.position, transform.position, pullForce * Time.deltaTime);
        }
        count += Time.deltaTime;
        if (count > duration)
        {
            Instantiate(afterEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        inRange = Physics2D.OverlapCircle(transform.position, pullDistance, whatIsEnemy);
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log(hitInfo.gameObject.tag);
        Enemy enemy = hitInfo.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            
            enemy.TakeDamage(damage);
        }
    }
}
