using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int value;
    public float destroyTime;
    protected float timeCounter = 0f;
    public float radius;
    public LayerMask whatIsPlayer;
    protected bool isCollected;
    protected Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {  
    }
}
