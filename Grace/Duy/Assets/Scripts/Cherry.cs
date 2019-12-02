using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public int healValue;
    public float destroyTime;
    private float timeCounter = 0f;
    public float radius;
    public LayerMask whatIsPlayer;
    private bool isCollected;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        isCollected = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);
        if (isCollected)
        {
            player.Heal(healValue);
            Destroy(gameObject);
        }
        timeCounter += Time.deltaTime;
        if (timeCounter > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
