using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewMovement : MonoBehaviour
{

    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.FindWithTag("Plane").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                //rb.transform.DOLookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z)).SetEase(moveEase);
                rb.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                //transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * speed);
                //transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }

        rb.AddForce(transform.forward * speed);
    }
}
