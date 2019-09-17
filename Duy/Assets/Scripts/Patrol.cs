using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float rayCastDistance;
    
    private bool movingRight=true;
    public Animator animator;
    public Transform groundCheck;
    void Awake()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        animator.SetFloat("speed", speed);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, rayCastDistance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                //transform.Rotate(0f, 180f, 0f);
                transform.eulerAngles = new Vector3(0, 180, 0);
                
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                //transform.Rotate(0f, -180f, 0f);
                
                movingRight = true;
            }
        }
    }
}
