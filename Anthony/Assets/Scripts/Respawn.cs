using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private bool isDead = false;
    private bool isGrounded;
    public Transform fireCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsFire;
    void Update()
    {

        /*if (isDead)
        {
            public static bool GameIsPaused = true;
			public GameObject deadMessage;
        }*/
    }

    void FixedUpdate()
    {
        isDead = Physics2D.OverlapCircle(fireCheck.position, checkRadius, whatIsFire);
    }
	
	/*void pause ()
	{
		deadMessage.SetActive(true);
	}
	*/
}

