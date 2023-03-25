using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement1 : GameBehaviour
{
    public GameObject neckPivot; //position of the point you want to rotate around
    public GameObject mouthPivot; //position of the point you want to rotate around

    public float rotationSpeed = 20;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            neckPivot.transform.RotateAround(neckPivot.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            //neckPivot.transform.RotateAround(neckPivot.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            neckPivot.transform.RotateAround(neckPivot.transform.position, -Vector3.up, rotationSpeed * Time.deltaTime);
            //neckPivot.transform.RotateAround(neckPivot.transform.position, -Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            mouthPivot.transform.RotateAround(mouthPivot.transform.position, -Vector3.left, rotationSpeed * Time.deltaTime);
            
            //mouthPivot.transform.RotateAround(neckPivot.transform.position, -Vector3.left, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            mouthPivot.transform.RotateAround(mouthPivot.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
            //mouthPivot.transform.RotateAround(neckPivot.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
        }

    }
}
