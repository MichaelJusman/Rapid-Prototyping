using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    public float speed = 5.0f;
    private GameObject focalPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
