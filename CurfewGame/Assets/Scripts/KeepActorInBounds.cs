using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepActorInBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int xRange = 25;
    public int zRange = 5;
    // Update is called once per frame
    void Update()
    {
        // Reset our actor if they wander out of bounds
        Vector3 pos = transform.position;
        if (pos.x < -xRange)
        {
            transform.position = new Vector3(-xRange, pos.y, pos.z);
        }
        if (pos.x > xRange)
        {
            transform.position = new Vector3(xRange, pos.y, pos.z);
        }
        pos = transform.position;
        if (pos.z < -zRange)
        {
            transform.position = new Vector3(pos.x, pos.y, -zRange);
        }
        if (pos.z > zRange)
        {
            transform.position = new Vector3(pos.x, pos.y, zRange);
        }
    }
}
