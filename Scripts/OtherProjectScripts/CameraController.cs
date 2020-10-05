using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float turnSpeed= 10;
    public Transform player;

    private Vector3 offset;
    private float xmin = 1, xmax = 2;
    private float Yoffset=2;


    void Start()
    {
        offset = new Vector3(player.position.x, player.position.y+Yoffset, player.position.z-3);
    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") > 0.05|| Input.GetAxis("Mouse X") < -0.05)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        }
        transform.position = player.position + offset;
        transform.LookAt(player.position + new Vector3(0, 1, 0));
    }
}
