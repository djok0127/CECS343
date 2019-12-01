using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float initialPos;
    private float endPos;
    public float distanceRight = 50f;
    public float distanceUp = 0f;
    public float speed = 20f;
    private bool moveRight = true;
   
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = GetComponent<Transform>().position.x;
        endPos = initialPos + distanceRight;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > endPos)
        {
            Flip();
            moveRight = false;
            
        }
        if (transform.position.x < initialPos)
        {
            moveRight = true;
            Flip();
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime,
                transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,
                transform.position.y);
        }
        
    }
    void Flip()
    {
        //facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
