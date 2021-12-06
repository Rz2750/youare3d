using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        // Spin the object around the target at rotateSpeed degrees/second.
        // if (Input.GetKey("q"))
        // {
        //     transform.RotateAround(player.transform.position, Vector3.up, (rotateSpeed) * Time.deltaTime);
        // }
        // if (Input.GetKey("e"))
        // {
        //     transform.RotateAround(player.transform.position, Vector3.up, (-rotateSpeed) * Time.deltaTime);
        // }

        offset = transform.position - player.transform.position;

    }
}
