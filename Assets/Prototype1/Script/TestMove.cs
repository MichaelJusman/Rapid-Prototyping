using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public Vector2 turn;
    public float speed = 5f;
    public float sensitivity = .5f;
    public Rigidbody rb;

    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        //turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }
}
