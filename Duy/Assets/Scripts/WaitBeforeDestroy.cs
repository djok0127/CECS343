using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBeforeDestroy : MonoBehaviour
{
    public float timer;
    private float counter = 0f;
   
    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > timer)
        {
            Destroy(gameObject);
        }
    }
}
