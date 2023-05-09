using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnProjectile : MonoBehaviour
{
    private float xRange;
    private float zRange;
    private float padding = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        xRange = GameObject.Find("Player").GetComponent<KeepActorInBounds>().xRange + padding;
        zRange = GameObject.Find("Player").GetComponent<KeepActorInBounds>().zRange + padding;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy our projectile if it's out of range
        Vector3 pos = transform.position;
        if (pos.x < -xRange)
        {
            Destroy(gameObject);
        }
        if (pos.x > xRange)
        {
            Destroy(gameObject);
        }
        pos = transform.position;
        if (pos.z < -zRange)
        {
            Destroy(gameObject);
        }
        if (pos.z > zRange)
        {
            Destroy(gameObject);
        }
    }
}
