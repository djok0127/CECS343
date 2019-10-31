using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public float slashRange;
    public LayerMask whatIsEnemy;
    public float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, slashRange, whatIsEnemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slashRange);
    }
}
