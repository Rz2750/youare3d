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
    public bool DEBUG_MODE;
    
    private int grounded = 5;
    private float y_prev = 0.0f;
    private float y_curr = 0.0f;
    
    // Start is called before the first frame update
    void Start() {
        y_prev = this.transform.position.y;
        y_curr = this.transform.position.y;
        
        StartCoroutine(StartGravityPause());
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    // FixedUpdate is called once per phsyics engine update
    void FixedUpdate() {        
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
        if (DEBUG_MODE) Debug.Log("VELOCITY: " + rb.velocity.x + ", " + rb.velocity.z);
        float x_drag = -FRICTION*PLAYER_SPD*rb.velocity.x;
        float z_drag = -FRICTION*PLAYER_SPD*rb.velocity.z;
        if (DEBUG_MODE) Debug.Log("DRAG: " + x_drag + ", " + z_drag);
        if (!(moveFwd ^ moveBack))
            rb.AddForce(new Vector3(0, 0, z_drag));
        if (!(moveLeft ^ moveRight))
            rb.AddForce(new Vector3(x_drag, 0, 0));
        
        // ********** JUMPING ********** //
        // "grounded": how long until you can jump next.
        // requires your y-position to stay stable for 5 frames before you can jump again.
        
        y_prev = y_curr;
        y_curr = this.transform.position.y;
        
        if (grounded == 0) {
            if (moveJump) {
                rb.AddForce(new Vector3(0, JUMP_POWER, 0), ForceMode.Impulse);
                grounded = 5;
            }
            else if (y_prev - y_curr > 0.5)
                grounded = 5;
        }
        
        if (grounded != 0) {
            rb.AddForce(new Vector3(0, -GRAVITY, 0));
            if (Math.Abs(y_prev - y_curr) <= 0.0001 && grounded > 0) {
                grounded--;
            }
        }
        if (DEBUG_MODE) Debug.Log("FRAMES UNTIL GROUNDED: " + grounded + "; y_curr = " + y_curr + ", y_prev = " + y_prev);
    }
    
    // Coroutine that halts the effects of gravity for the first 3 seconds
    // that a level is loaded
    IEnumerator StartGravityPause() {
        float gravity_actual = GRAVITY;
        GRAVITY = 0.0f;
        yield return new WaitForSeconds(3);
        GRAVITY = gravity_actual;
    }
}
