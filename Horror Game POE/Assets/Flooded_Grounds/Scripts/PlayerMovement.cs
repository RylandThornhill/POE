using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CapsuleCollider playerCol;
    float originalHeight;
    public float reducedHeight;
    float moveForward;
    float moveSide;
    float moveUp;
    public float sensitivity = 30.0f;
    public float WaterHeight = 15.5f;
    public GameObject cam;
    float moveFB, moveLR;
    float rotX, rotY;
    CharacterController character;
    public bool webGLRightClickRotation = true;
    bool isGrounded;
    float gravity = -5f;

    public float walkSpeed = 1f;
    public float sprintSpeed;
    float currentSpeed;
    public float jumpSpeed = 5f;
    Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        if (Application.isEditor)
        {
            webGLRightClickRotation = false;
            sensitivity = sensitivity * 1.5f;
        }
        rig = GetComponent<Rigidbody>();
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;
    }

    // Update is called once per frame
    void Update()
    {
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentSpeed != sprintSpeed)
                currentSpeed = sprintSpeed;
        }
        else
            currentSpeed = walkSpeed;
        moveForward = Input.GetAxis("Vertical") * currentSpeed;
        moveSide = Input.GetAxis("Horizontal") * currentSpeed;
        moveUp = Input.GetAxis("Jump") * jumpSpeed;
        if (webGLRightClickRotation)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CameraRotation(cam, rotX, rotY);
            }
        }
        else if (!webGLRightClickRotation)
        {
            CameraRotation(cam, rotX, rotY);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Crouch();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }

    private void FixedUpdate()
    {
        rig.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * rig.velocity.y);
        if (isGrounded && moveUp != 0)
        {
            rig.AddForce(transform.up * moveUp, ForceMode.VelocityChange);
            isGrounded = false;
            Debug.Log("Jumping");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Collision with ground;
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
    }

    void CheckForWaterHeight()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }

    void Crouch()
    {
        playerCol.height = reducedHeight;
    }

    void GoUp()
    {
        playerCol.height = originalHeight;
    }
}
