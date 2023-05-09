using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private KeepActorInBounds playerControllerScript;
    private Camera cam;
    private int xRange;
    private int zRange;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        playerControllerScript = GameObject.Find("Player").GetComponent<KeepActorInBounds>();
        // Tie the range of motion of the camera to the player!
        xRange = playerControllerScript.xRange;
        zRange = playerControllerScript.zRange;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our camera regularly with the player
        Vector3 cameraPos = transform.position;
        Vector3 playerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        transform.position = new Vector3(playerPos.x, cameraPos.y, playerPos.z);

        KeepCameraInBounds();
    }

    void KeepCameraInBounds()
    {
        Vector3 cameraPos = transform.position;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        // Check if our top or bottom is out of bounds and reset if so
        if (cameraPos.z + height > zRange)
        {
            transform.position = new Vector3(cameraPos.x, cameraPos.y, zRange - height);
        }
        else if (cameraPos.z - height < -zRange)
        {
            transform.position = new Vector3(cameraPos.x, cameraPos.y, -zRange + height);
        }
        cameraPos = transform.position;
        // And do the same for left and right
        if (cameraPos.x + width > xRange)
        {
            transform.position = new Vector3(xRange - width, cameraPos.y, cameraPos.z);
        }
        else if (cameraPos.x - width < -xRange)
        {
            transform.position = new Vector3(-xRange + width, cameraPos.y, cameraPos.z);
        }
    }
}
