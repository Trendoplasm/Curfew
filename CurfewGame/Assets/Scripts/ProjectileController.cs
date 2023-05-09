using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float projectileSpeed = 1.0f;
    public int damage = 5;

    private float playerSpeed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Get our direction by finding the location of the mouse
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 realMouse = new Vector3(mouse.x, 0, mouse.y);
        direction = Vector3.Normalize(realMouse - transform.position);

        // Also get the speed of the player when the projectile was launched to add to our projectileSpeed
        playerSpeed = GameObject.Find("Player").GetComponent<PlayerController>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forwards
        //transform.Translate(direction * (projectileSpeed + playerSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Destroy(gameObject);
        }
    }
}
