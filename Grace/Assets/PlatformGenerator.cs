using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform character;
    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }


    // Update is called once per frame
    void Update()
    {
        // if current poistion is less than generation point
        if(character.position.x < generationPoint.position.x)
        {
            // generate new platform
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            // creates the copy of current object
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
