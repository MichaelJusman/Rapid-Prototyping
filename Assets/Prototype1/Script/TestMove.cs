using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public float speed = 5f;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.Find("Island").GetComponent<Collider>();
    }

    private void Update()
    {
        //transform.position = cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        //if(Input.GetMouseButton(0))
        // {
        //     ray = cam.ScreenPointToRay(Input.mousePosition);
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * speed);
        //         transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        //     }
        // }
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * speed);
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

    }

}
