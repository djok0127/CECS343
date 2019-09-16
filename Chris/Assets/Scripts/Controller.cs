using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using V_AnimationSystem;
using System;

public class Controller : MonoBehaviour
{
    //private Player_Base playerBase;
    private Rigidbody2D rigidbody2d;
    //private SpriteRenderer sr;
    public float jumpVelocity = 10f;
    public float speed = 5f;
    private float moveInput;
    //private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask platformlayerMask;
    //private Transform transform;
    //checking grounding for jumping
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    //public LayerMask whatIsFire;
    public Transform attackPoint;
    //check if player hit fire
    //private bool isDead;
    private bool facingRight=true;
    public Animator animator;

    public int jumpTimes;
    private int jumpCount;
    private bool isJumping = false;
    private void Awake()
    {
        //playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();

        //boxCollider2d = transform.GetComponent<BoxCollider2D>();
        //someScale = transform.localScale.x;
        jumpCount = jumpTimes;
        
    }
    // Update is called once per frame
    void Update()
    {
        
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
                animator.SetFloat("yVelocity", rigidbody2d.velocity.y);
            }
            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (jumpCount < jumpTimes)
                    {
                        rigidbody2d.velocity = Vector2.up * jumpVelocity;
                        animator.SetFloat("yVelocity", rigidbody2d.velocity.y);
                        jumpCount++;
                    }
                }
            }
        }*/
        
        if (Input.GetKeyDown(KeyCode.UpArrow)&&jumpCount>0)
        {
            
            //float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            animator.SetFloat("yVelocity", rigidbody2d.velocity.y);
            jumpCount--;
            //isJumping = true;
        }
        //if (isGrounded&&!Input.GetKeyDown(KeyCode.UpArrow))
        //{
        animator.SetFloat("yVelocity", rigidbody2d.velocity.y);
        animator.SetBool("isJumping", !isGrounded);
        //}
        /*
        if (moveInput > 0 && !facingRight)
        {
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //transform.localScale = new Vector2(someScale, transform.localScale.y);
            //transform.Rotate(0f, 180f, 0f);
            //attackPoint.Rotate(0f, 180f, 0f);
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            //gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //transform.localScale = new Vector2(-someScale, transform.localScale.y);
            //transform.Rotate(0f, 180f, 0f);
            //attackPoint.Rotate(0f, 180f, 0f);
            Flip();
        }*/


    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            jumpCount = jumpTimes;
        }
        //isDead= Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsFire);
        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        rigidbody2d.velocity = new Vector2(moveInput * speed, rigidbody2d.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveInput));
        if (moveInput > 0 && !facingRight)
        {
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //transform.localScale = new Vector2(someScale, transform.localScale.y);
           
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            //gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //transform.localScale = new Vector2(-someScale, transform.localScale.y);
            
            Flip();
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        //Vector3 scaler = transform.localScale;
        //scaler.x *= -1;
        //transform.localScale = scaler;
        transform.Rotate(0f, 180f, 0f);
    }
    /*private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d=Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,
            0f, Vector2.down * .1f, platformlayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }*/
}
