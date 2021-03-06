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
    public AudioClip roll;
    public AudioClip wall;


    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    bool isMoving = false;
    bool colliding = false;
    bool hasKey = false;

    AudioSource ballAudio;
    //public AudioSource wallcollisionaudio;
    Collision collision;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        ballAudio = GetComponent<AudioSource>();
        //wallcollisionaudio = GetComponent<AudioSource>();

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
        
        if ((velocity.y != 0 && velocity.x != 0) || velocity.z != 0)
        {
            isMoving = true;
            colliding = false;

        }
        else
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
            if (!ballAudio.isPlaying)
                ballAudio.PlayOneShot(roll, 0.7F);
        }
        else
        {
            ballAudio.Pause();

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "key") {
            hasKey = true;
            Destroy (collision.gameObject);
        }
        // else if ((collision.gameObject.tag == "Door") and (hasKey == true)) {
        //     hasKey = false;
        //     collision.gameObject.transform.position = new Vector3(0,-5,0);
        // }
        else if(collision.gameObject.tag!= "ground")
        {
            ballAudio.PlayOneShot(wall, 0.3F);
            isMoving = false;
            Debug.Log("here");

        } else

        { if (!isMoving)
            {
                ballAudio.Pause();

            }
        }


    }

}


/*if (rb.velocity.x != 0)
    isMoving = true;
else
    isMoving = false;

if (isMoving)
{
    if (!rollingaudio.isPlaying)
        rollingaudio.Play();
}
else
    rollingaudio.Stop();
	}*/