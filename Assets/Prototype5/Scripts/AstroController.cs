using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameBehaviour;

public class AstroController : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 2f; // The player's movement speed
    public float turnSpeed = 10f; // The player's turn speed
    public float jumpHeight = 3f; // The player's jump height
    public float gravity = -9.81f; // The player's gravity

    public Vector3 moveDirection; // The player's movement direction
    public bool isGrounded; // Whether the player is grounded

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        // Get the player's input for movement and turning
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the player's movement direction based on the input and the player's forward direction
        moveDirection = transform.forward * vertical * moveSpeed;
        moveDirection += transform.right * horizontal * moveSpeed;

        // Rotate the player to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), turnSpeed * Time.deltaTime);
        }

        // Apply gravity to the player's movement direction
        moveDirection.y += gravity * Time.deltaTime;

        // If the player is grounded, reset their vertical movement to zero and allow them to jump
        if (isGrounded)
        {
            moveDirection.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        // Move the player based on the final movement direction
        controller.Move(moveDirection * Time.deltaTime);
    }
}

