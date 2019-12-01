using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootRange = 50f;
    private Transform target;
    private bool facingRight = true;
    public float attackInterval = 5f;
    private float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (counter > attackInterval&&distanceToPlayer<shootRange)
        {
            Shoot();
            counter = 0f;
        }
        if (transform.position.x < target.position.x && !facingRight)
        {
            Flip();
        }
        else if (transform.position.x > target.position.x && facingRight)
        {
            Flip();
        }
    }
    void Shoot()
    {
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
