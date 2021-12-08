using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Richard's WIP better movement script

public class BetterPlayerMovement : MonoBehaviour {
    
    public float SPEED_CAP = 100.0f;
    public float JUMP_POWER = 20.0f;
    
    private float x_vel = 0.0f;
    private float z_vel = 0.0f;
    
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
        
        // ********** Z-AXIS MOVEMENT ********** //
        if (Input.GetKey(KeyCode.W)) {
            // Debug.Log("W PRESSED");
            if (z_vel >= 0)
                z_vel += 2;
            else
                z_vel += 6;
        }
        if (Input.GetKey(KeyCode.S)) {
            // Debug.Log("S PRESSED");
            if (z_vel <= 0)
                z_vel -= 2;
            else
                z_vel -= 6;
        }
        if (!(Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))) {
            // Debug.Log("NO Z MOVEMENT");
            if (z_vel < 1 && z_vel > -1)
                z_vel = 0.0f;
            else
                z_vel *= 0.5f;
        }
        
        // ********** X-AXIS MOVEMENT ********** //
        if (Input.GetKey(KeyCode.D)) {
            // Debug.Log("D PRESSED");
            if (x_vel >= 0)
                x_vel += 2;
            else
                x_vel += 6;
        }
        if (Input.GetKey(KeyCode.A)) {
            // Debug.Log("A PRESSED");
            if (x_vel <= 0)
                x_vel -= 2;
            else
                x_vel -= 6;
        }
        if (!(Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.A))) {
            // Debug.Log("NO X MOVEMENT");
            if (x_vel < 1 && x_vel > 1)
                x_vel = 0.0f;
            else
                x_vel *= 0.5f;
        }
        
        // ********** VELOCITY CAP ********** //
        
        float total_vel = (float) Math.Sqrt(Math.Pow(x_vel, 2) + Math.Pow(z_vel, 2));
        if (total_vel > SPEED_CAP) {
            x_vel = (x_vel/total_vel)*100.0f;
            z_vel = (z_vel/total_vel)*100.0f;
        }
        
        // Debug.Log("TARGET VELOCITY: " + x_vel + ", " + z_vel);
        this.GetComponent<Rigidbody>().AddForce(new Vector3(x_vel, 0, z_vel));
        
        // ********** JUMPING ********** //
        // "grounded": whether or not you've touched the ground since your last jump.
        // can only jump if grounded.
        
        y_prev = y_curr;
        y_curr = this.transform.position.y;
        
        if (Input.GetKey(KeyCode.Space) && grounded) {
            Debug.Log("SPACE PRESSED");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, JUMP_POWER, 0), ForceMode.Impulse);
            grounded = false;
        }
        
        if ((y_prev == y_curr) && !grounded) 
            grounded = true;
        else if ((y_prev - y_curr > 0.5) && grounded) {
            grounded = false;
        }
    }
}
