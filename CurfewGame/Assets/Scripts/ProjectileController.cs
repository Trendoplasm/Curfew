using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float projectileSpeed = 1.0f;
    public int damage = 5;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Get our direction by finding the location of the mouse
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 realMouse = new Vector3(mouse.x, transform.position.y, mouse.z); ;
        direction = Vector3.Normalize(realMouse - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forwards
        transform.Translate(direction * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Destroy(gameObject);
        }
    }
}
