using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public Transform dropPoint;
    public float speed = 20f;
    public GameObject bombPrefab;
    public GameObject policePrefab;
    public float dropInterval=1f;
    public float deathTime = 30f;
    private float counter1=0f;
    private float counter2 = 0f;
    private Rigidbody2D rb;
    private int number;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Random.seed = (int)System.DateTime.Now.Ticks;
        number = Random.Range(1, 101);
    }

    // Update is called once per frame
    void Update()
    {
        counter1 += Time.deltaTime;
        counter2 += Time.deltaTime;
        if (counter1 >= dropInterval)
        {
            
            //suppose to be 30% that police will drop

            if (number <=30)
            {
                DropPolice();
            }
            else
            {
                DropBomb();
            }
            
            counter1 = 0f;
        }
        if (counter2 >= deathTime)
        {
            Destroy(gameObject);
        }
    }
    void DropBomb()
    {
        Instantiate(bombPrefab, dropPoint.position, dropPoint.rotation);
    }
    void DropPolice()
    {
        Instantiate(policePrefab, dropPoint.position, policePrefab.GetComponent<Transform>().rotation);
    }
}
