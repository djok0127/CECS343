using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialEffect : MonoBehaviour
{
    public GameObject Effect;
    public float delayTime = 1f;
    private float count = 0;

    void Start()
    {
        
    }
    void Update()
    {
        count += Time.deltaTime;
        //Debug.Log("I'm here in update");
        if (count >= delayTime)
        {
            Debug.Log("Calling Explosion");
            Explosion();
        }
    }
    void Explosion()
    {       
        Instantiate(Effect, transform.position, transform.rotation);
        Destroy(gameObject);       
    }

}
