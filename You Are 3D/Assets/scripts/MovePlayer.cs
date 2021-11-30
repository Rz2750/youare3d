//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MovePlayer : MonoBehaviour
//{
//    private CharacterController controller;
//    private Vector3 playerVelocity;
//    private bool groundedPlayer;
//    private float playerSpeed = 2.0f;
//    private float jumpHeight = 1.0f;
//    private float gravityValue = -9.81f;

//    private void Start()
//    {
//        controller = gameObject.AddComponent<CharacterController>();
//    }

//    void Update()
//    {
//        groundedPlayer = controller.isGrounded;
//        if (groundedPlayer && playerVelocity.y < 0)
//        {
//            playerVelocity.y = 0f;
//        }
//        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//        controller.Move(move * Time.deltaTime * playerSpeed);

//        if (move != Vector3.zero)
//        {
//            gameObject.transform.forward = move;
//        }

//        // Changes the height position of the player..
//        if (Input.GetButtonDown("Jump") && groundedPlayer)
//        {
//            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
//        }

//        playerVelocity.y += gravityValue * Time.deltaTime;
//        controller.Move(playerVelocity * Time.deltaTime);
//    }
//}

using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    bool isMoving = false;
    AudioSource audioSrc;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        audioSrc = GetComponent<AudioSource>();

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;
        
        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);
        if ((velocity.y != 0 && velocity.x !=0) || velocity.z!= 0)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        } else
            audioSrc.Stop();
    }
}


/*if (rb.velocity.x != 0)
    isMoving = true;
else
    isMoving = false;

if (isMoving)
{
    if (!audioSrc.isPlaying)
        audioSrc.Play();
}
else
    audioSrc.Stop();
	}*/