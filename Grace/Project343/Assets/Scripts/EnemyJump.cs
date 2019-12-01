using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    private bool isGrounded;
    private bool atEdge;
    private Rigidbody2D rigidbody2d;
    private Transform target;

    public float jumpVelocity;
    public float yDistanceBeforeJumping = 5f;
    public float xDistanceBeforeJumping = 5f;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsEdge;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //atEdge = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsEdge);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        atEdge = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsEdge);
        if (isGrounded && atEdge && target.position.y - transform.position.y> yDistanceBeforeJumping)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            //rigidbody2d.AddForce(Vector2.up * jumpVelocity);
            //rigidbody2d.AddForce(new Vector2(0f,jumpVelocity);
        }
        else if (isGrounded && (target.position.y - transform.position.y) > yDistanceBeforeJumping &&
            Mathf.Abs(target.position.x -transform.position.x)<=xDistanceBeforeJumping)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }
    
}
