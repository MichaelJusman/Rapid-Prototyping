using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTree : GameBehaviour
{

    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;
    public float speed;
    public float boostDuration = 1;

    public bool isDocked = true;
    public bool isBoosted  = false;

    public GameObject seedTree;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.FindWithTag("Plane").GetComponent<Collider>();

        Physics.IgnoreLayerCollision(3, 8);
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
            isDocked = false;
            isBoosted = true;
        }
        
        if(!isDocked && isBoosted)
        {
            speed = _UI2.speedValue;
            rb.AddForce(transform.forward * speed);
            StartCoroutine(BoostDuration(boostDuration));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnSeed();
        }
    }

    //public void LaunchTree(float _speed)
    //{
    //    //rb.AddForce.ForceMode.Impulse;
    //    rb.AddForce(transform.forward * _speed, ForceMode.VelocityChange);
    //    StartCoroutine(BoostDuration(boostDuration));
    //}

    IEnumerator BoostDuration(float _time)
    {
        yield return new WaitForSeconds(_time);
        isBoosted = false;
    }

    public void SpawnSeed()
    {
        Instantiate(seedTree, transform.position, transform.rotation);
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.CompareTag("Atmostphere"))
    //    {
    //        SpawnSeed();
    //    }
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Atmostphere"))
    //    {
    //        SpawnSeed();
    //    }
    //}

}
