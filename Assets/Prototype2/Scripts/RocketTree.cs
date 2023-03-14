using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTree : MonoBehaviour
{

    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;
    public float speed = 100;

    bool isDocked = true;

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
        if (Physics.Raycast(ray, out hit) && isDocked)
        {
            if (hit.collider == planeCollider)
            {
                rb.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDocked)
        {
            LaunchTree(100);
        }



    }

    public void LaunchTree(float _speed)
    {
        rb.AddForce(transform.forward * _speed);
        isDocked = false;
    }
}
