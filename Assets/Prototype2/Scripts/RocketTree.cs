using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTree : GameBehaviour<RocketTree>
{

    Camera cam;
    public float cameraSpeed = 2;

    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;
    public float speed;
    public float boostDuration = 1;

    public bool isDocked = true;
    public bool isBoosted  = false;

    public GameObject seedTree;
    public GameObject dieExplosion;
    public GameObject rocketThruster;

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
        if (_GSM.gameState == GameState.Playing)
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
                //ZoomOut();
            }

            if (!isDocked && isBoosted)
            {
                speed = _UI2.speedValue;
                rb.AddForce(transform.forward * speed);
                StartCoroutine(BoostDuration(boostDuration));

            }

            if (isBoosted)
                rocketThruster.GetComponent<ParticleSystem>().Play();
            else
                rocketThruster.GetComponent<ParticleSystem>().Stop();

            if (rb.velocity.z == 0 && !isDocked && !isBoosted)
            {
                DelayedDeath();
                _UI2.OnStranded();
            }
        }
        else
            return;


        
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

    public void DelayedDeath()
    {
        StartCoroutine(ProlongDeathSequence(3));
    }

    public void InstantDeath()
    {
        StartCoroutine(ProlongDeathSequence(1));
    }

    IEnumerator ProlongDeathSequence(float _time)
    {
        yield return new WaitForSeconds(_time);
        dieExplosion.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        _GM2.OnGameEnd();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Planet"))
        {
            InstantDeath();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Atmostphere"))
        {
            isBoosted=true;
        }
    }

    //public void ZoomOut()
    //{
    //    cam.orthographicSize = 30 * Time.deltaTime;
    //}

}
