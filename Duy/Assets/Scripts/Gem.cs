using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item
{
    
    void Update()
    {
        isCollected = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);
        if (isCollected)
        {
            player.MyPoints = value;
            Destroy(gameObject);
        }
        timeCounter += Time.deltaTime;
        if (timeCounter > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
