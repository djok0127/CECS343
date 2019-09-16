using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    public Transform zoom;
    public float smoothTime = 2;

    Vector3 offset;

    void Awake()
    {
        offset = zoom.position - transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, zoom.position - offset, Time.deltaTime * smoothTime);
    }
}
