using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTree : GameBehaviour<RocketTree>
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
    public GameObject rocketFire;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.FindWithTag("Plane").GetComponent<Collider>();
        rocketFire.SetActive(false);
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

        if (isBoosted)
            rocketFire.SetActive(true);
        else
            rocketFire.SetActive(false);

        if (rb.velocity.z == 0 && !isDocked && !isBoosted)
            Die();
    }

    IEnumerator BoostDuration(float _time)
    {
        yield return new WaitForSeconds(_time);
        isBoosted = false;
    }

    public void SpawnSeed()
    {
        Instantiate(seedTree, transform.position, transform.rotation);
    }

    public void Die()
    {
        Destroy(gameObject);
        _UI2.OnGameEnd();
    }

}
