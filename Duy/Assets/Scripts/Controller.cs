using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using V_AnimationSystem;
using System;

public class Controller : MonoBehaviour
{
    
    private Rigidbody2D rigidbody2d;
    
    public float jumpVelocity = 10f;
    public float speed = 5f;
    private float moveInput;

    
    //[SerializeField] private LayerMask platformlayerMask;
    //private Transform transform;
    //checking grounding for jumping
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    public Transform attackPoint;
    
    private bool facingRight=true;
    public Animator animator;

    public int jumpTimes;
    private int jumpCount;
    //private bool isJumping = false;

    //variable for knocking back
    public float knockBackx;
    public float knockBacky;
    public float knockBackLength;
    public float knockBackCount;
    public bool knockFromRight;
    //private bool isKnockedBack = false;
    

    private void Awake()
    {

        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        jumpCount = jumpTimes;
        
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            jumpCount = jumpTimes;
            //animator.SetBool("isHurt", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)&&jumpCount>0)
        {
            
            //float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            SoundManager.PlaySound("jump");
            animator.SetFloat("yVelocity", rigidbody2d.velocity.y);
            jumpCount--;
            isGrounded = false;
            //isJumping = true;
        }
        //if (isGrounded&&!Input.GetKeyDown(KeyCode.UpArrow))
        //{
        
        animator.SetFloat("yVelocity", rigidbody2d.velocity.y);
        animator.SetBool("isJumping", !isGrounded);
        


    }
    void FixedUpdate()
    {
     
        //isDead= Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsFire);
        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        if (knockBackCount <= 0)
        {
            rigidbody2d.velocity = new Vector2(moveInput * speed, rigidbody2d.velocity.y);
            animator.SetBool("isHurt", false);
        }
        else
        {

            animator.SetBool("isHurt", true);
            if (knockFromRight)
            {
                rigidbody2d.velocity = new Vector2(-knockBackx, knockBacky);
            }
            if (!knockFromRight)
            {
                rigidbody2d.velocity = new Vector2(knockBackx, knockBacky);
            }
            knockBackCount -= Time.deltaTime;
        }
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
        transform.Rotate(0f, 180f, 0f);
    }


}
