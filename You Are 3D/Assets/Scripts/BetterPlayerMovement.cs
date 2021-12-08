using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Richard's WIP better movement script

public class BetterPlayerMovement : MonoBehaviour {
    
    public float PLAYER_SPD;
    public float JUMP_POWER;
    public float FRICTION;
    public float GRAVITY;
    
    private bool grounded = false;
    private float y_prev = 0.0f;
    private float y_curr = 0.0f;
    
    // Start is called before the first frame update
    void Start() {
        y_prev = this.transform.position.y;
        y_curr = this.transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    // FixedUpdate is called once per phsyics engine update
    void FixedUpdate() {
        // PLAN:
        // holding any movement key increases velocity in that direction by +2 per FixedUpdate (+100 per sec)
        // velocity caps at 100 units in any direction (pythag. theorem used to calculate this)
        // if velocity is over cap, both x_vel and z_vel decrease proportionally until below 100
        
        // if neither W/S is pressed, z_vel trends towards 0 by 4 per FixedUpdate
        // if neither A/D is pressed, x_vel trends towards 0 by 4 per FixedUpdate
        
        // if holding a movement key while player is moving in the opposite direction, velocity changes by 6 instead of 2 until reversal completes
        
        Rigidbody rb = this.GetComponent<Rigidbody>();
        
        bool moveFwd = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        bool moveBack = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));
        bool moveLeft = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
        bool moveRight = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
        bool moveJump = (Input.GetKey(KeyCode.Space));
        
        // ********** MOVEMENT ********** //
        if (moveFwd)
            rb.AddForce(new Vector3(0, 0, PLAYER_SPD));
        if (moveBack)
            rb.AddForce(new Vector3(0, 0, -PLAYER_SPD));
        if (moveRight)
            rb.AddForce(new Vector3(PLAYER_SPD, 0, 0));
        if (moveLeft)
            rb.AddForce(new Vector3(-PLAYER_SPD, 0, 0));
        
        // ********** DRAG ********** //
        Debug.Log("VELOCITY: " + rb.velocity.x + ", " + rb.velocity.z);
        float x_drag = -FRICTION*PLAYER_SPD*rb.velocity.x;
        float z_drag = -FRICTION*PLAYER_SPD*rb.velocity.z;
        Debug.Log("DRAG: " + x_drag + ", " + z_drag);
        if (!(moveFwd ^ moveBack))
            rb.AddForce(new Vector3(0, 0, z_drag));
        if (!(moveLeft ^ moveRight))
            rb.AddForce(new Vector3(x_drag, 0, 0));
        
        // ********** JUMPING ********** //
        // "grounded": whether or not you've touched the ground since your last jump.
        // can only jump if grounded.
        
        y_prev = y_curr;
        y_curr = this.transform.position.y;
        
        if (grounded) {
            if (moveJump) {
                rb.AddForce(new Vector3(0, JUMP_POWER, 0), ForceMode.Impulse);
                grounded = false;
            }
            else if (y_prev - y_curr > 0.5)
                grounded = false;
        }
        
        if (!grounded) {
            rb.AddForce(new Vector3(0, -GRAVITY, 0));
            if (y_prev == y_curr)
                grounded = true;
        }
    }
}
