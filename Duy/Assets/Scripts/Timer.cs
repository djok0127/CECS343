using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time=7f;
    private float counter=0f;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > time)
            Destroy(gameObject);
    }
}
