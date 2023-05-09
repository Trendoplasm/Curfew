using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 10.0f;

    private float horizontalInput;
    private float verticalInput;

    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        // Get input from the controller
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // And move our character in the world. The bounding is automatically handled by KeepActorInBounds
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        // Spawn a projectile if we press the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
