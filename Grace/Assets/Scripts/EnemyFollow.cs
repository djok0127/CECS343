using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5f;
    public float followDistance=100f;
    public float stoppingDistance=5f;
    public Animator animator;
    private float oldPosition=0f;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        oldPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance
            && Vector2.Distance(transform.position, target.position) < followDistance)
        {
            animator.SetFloat("speed", 1f);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //float movement = GetComponent<Rigidbody2D>().velocity.x;
            if (transform.position.x > oldPosition)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x < oldPosition)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            oldPosition = transform.position.x;
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }
    }
}
