using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    public float pullForce = 20f;
    public float pullDistance = 30f;
    public float duration = 5f;
    public GameObject afterEffect;
    private float count = 0f;
    private Player player;
    public float damage = 3f;
    private Transform playerPosition;
    public LayerMask whatIsPlayer;
    private bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            playerPosition.transform.position = Vector2.MoveTowards(playerPosition.transform.position, transform.position, pullForce * Time.deltaTime);
        }
        count += Time.deltaTime;
        if (count > duration)
        {
            Instantiate(afterEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        inRange = Physics2D.OverlapCircle(transform.position, pullDistance,whatIsPlayer);
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log(hitInfo.gameObject.tag);
        Player player = hitInfo.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Player Hit!");
            player.TakeDamage(damage);
        }
    }
}
