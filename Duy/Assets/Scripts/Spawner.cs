using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 3f;
    public float statBonus = 10f;
    private float timer = 0f;
    //Enemy game object to spawn
    public GameObject policePrefab;
    public GameObject firePrefab;
    public GameObject bossPrefab;

    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = policePrefab.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //every minute
        if (timer > 60)
        {

        }
    }
}
