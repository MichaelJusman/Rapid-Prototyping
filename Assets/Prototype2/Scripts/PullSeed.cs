using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullSeed : GameBehaviour
{
    public GameObject planetCenter;
    public GameObject seedTree;
    public GameObject player;
    public float pullSpeed = 100;
    public float sphereRadius = 5;
    public LayerMask treeSeedLayer;
    public bool isFertilized = false;
    public bool isTagged = false;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //private void Update()
    //{
    //    if (Physics.CheckSphere(transform.position, sphereRadius, treeSeedLayer))
    //    {
    //        Debug.Log("Im being pulled");
    //    }
    //}

    //public void AtmostpherePull()
    //{
    //    //player.transform.Translate(Time.deltaTime * pullSpeed * planetCenter.transform.position); 
    //    Vector3 direction = planetCenter.transform.position - seedTree.transform.position;
    //    seedTree.GetComponent<Rigidbody>().AddForce(pullSpeed * direction);
    //}

    //public void OnCollisionStay(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Seed"))
    //    {
    //        Vector3 direction = planetCenter.transform.position - seedTree.transform.position;
    //        seedTree.GetComponent<Rigidbody>().AddForce(pullSpeed * direction);
    //    }
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFertilized && !isTagged)
        {
            player.GetComponent<RocketTree>().SpawnSeed();
            isTagged = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Seed") && !isFertilized)
        {
            Vector3 direction = planetCenter.transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(pullSpeed * direction);
            isFertilized = true;
        }
    }
}
