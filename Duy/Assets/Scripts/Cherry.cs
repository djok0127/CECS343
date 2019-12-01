﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Item
{
    
    void Update()
    {
        isCollected = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);
        if (isCollected)
        {
            player.Heal(value);
            Destroy(gameObject);
        }
        timeCounter += Time.deltaTime;
        if (timeCounter > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
