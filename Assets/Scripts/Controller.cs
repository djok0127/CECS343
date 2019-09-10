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

    //check if player hit fire
    //private bool isDead;

    private void Awake()
    {
        //playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        //boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(rigidbody2d.position.x, 0);
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        
         
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //isDead= Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsFire);
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rigidbody2d.velocity = new Vector2(moveInput * speed, rigidbody2d.velocity.y);
       
        if (moveInput > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveInput < 0) 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    //void Flip()
   // {
        //facingRight = !facingRight;
       // Vector3 Scaler = transform.localScale;
        //Scaler.x *= -1;
       // transform.localScale = Scaler;
  //  }
    /*private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d=Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,
            0f, Vector2.down * .1f, platformlayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }*/
}
