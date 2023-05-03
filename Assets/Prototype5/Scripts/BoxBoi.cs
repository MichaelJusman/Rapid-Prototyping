using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class BoxBoi : GameBehaviour
{
    public GameObject boxPoint;

    public float travelSpeed = 5f;

    public Camera cam;
    public float cameraSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_GSM.gameState == GameState.Playing)
        {
            //the position of the object
            Vector3 targetPosition = boxPoint.transform.position;

            //lerp object to targeted position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * travelSpeed);

            // Cast a ray from the camera to the mouse position
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                // Get the point on the surface where the ray hit
                Vector3 hitPoint = hitInfo.point;

                // Calculate the rotation needed to look at the hit point
                Vector3 lookDirection = hitPoint - transform.position;
                Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

                // Apply the rotation to the object
                transform.rotation = rotation;
            }
        }
    }
}
