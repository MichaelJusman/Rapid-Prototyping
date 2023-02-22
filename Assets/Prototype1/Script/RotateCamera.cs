using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float rotationSpeed;
    bool isFacingForward = true;
    public GameObject vocalPoint;

    void Update()
    {
        if(isFacingForward)
        {
            vocalPoint.transform.eulerAngles = new Vector3(0, 0, 0);
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
        else
        {
            vocalPoint.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            isFacingForward = !isFacingForward;
        }
    }
}
