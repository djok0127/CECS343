using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour
{
    public GameObject platform;

    public float spawnTime;

    public float yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("platformSpawn", 0, spawnTime);
    }

    // Update is called once per frame
    void platformSpawn()
    {
        float y = Random.Range(yMin, yMax);

        Vector3 pos = new Vector3(transform.position.x, y, 0);

        Instantiate(platform, pos, transform.rotation);
    }
}
