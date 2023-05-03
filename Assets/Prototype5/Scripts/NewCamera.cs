using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public Transform cameraSpot;
    public float travelSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = cameraSpot.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * travelSpeed);
        
    }
}
