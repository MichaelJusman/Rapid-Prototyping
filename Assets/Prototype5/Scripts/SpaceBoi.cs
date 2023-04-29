using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameBehaviour;

public class SpaceBoi : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float turnSpeed = 0.15f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;
        Vector3 move = new Vector3(x, 0f, z);
        Debug.Log(move);


        //// Calculate the new rotation for the character based on the move direction
        //Quaternion newRotation = Quaternion.LookRotation(move);

        //// Smoothly rotate the character towards the new rotation
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, turnSpeed * Time.deltaTime);

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), turnSpeed);


        controller.Move(move * speed * Time.deltaTime);

        if (move.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
