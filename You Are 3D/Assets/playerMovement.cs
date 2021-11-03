using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed = 1f;

    public float jumpHeight = 6f;
    private float xV = 0f;
    private float zV = 0f;
    private float yV = 0f;
    private Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            xV = xV - 1f;
        }
        if (Input.GetKey("d"))
        {
            xV = xV + 1f;
        }
        if (Input.GetKey("w"))
        {
            zV = zV + 1f;
        }
        if (Input.GetKey("s"))
        {
            zV = zV - 1f;
        }
        if (Input.GetKey("space"))
        {
            yV = yV + 1f; 
        }
        
        xV = xV * 0.95f;
        zV = zV * 0.95f;
        yV = yV * 0.80f;
        velocity.x = (speed*xV)/100;
        velocity.z = (speed*zV)/100;
        velocity.y = (jumpHeight*yV)/100;

        
        transform.position = this.transform.position + velocity;
    }

    void OnCollisionEnter(Collision col) {
        xV = 0;
        zV = 0;

    }

    // void OnCollisionStay(Collision col) {
    //     xV = 0;
    //     zV = 0;
    // }
}
