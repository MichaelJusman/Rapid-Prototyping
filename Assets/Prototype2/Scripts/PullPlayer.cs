using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlayer : GameBehaviour
{
    public float sphereRadius = 5;
    public LayerMask playerLayer;
    public LayerMask treeSeedLayer;
    public GameObject player;

    public GameObject planetCenter;
    public float pullSpeed = 100;

    public void Start()
    {

    }

    private void Update()
    {
        //if (Physics.CheckSphere(transform.position, sphereRadius, playerLayer))
        //{
        //    Debug.Log("Im being pulled");
        //    GravitationalRing();
        //}

        //if (Collider.Equals(transform.position, player.transform.position))
        //{
        //    Debug.Log("Im being pulled");
        //    GravitationalRing();
        //}
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, sphereRadius);
    //}

    public void GravitationalRing()
    {
        //player.transform.Translate(Time.deltaTime * pullSpeed * planetCenter.transform.position); 
        Vector3 direction = planetCenter.transform.position - player.transform.position;
        player.GetComponent<Rigidbody>().AddForce(pullSpeed * direction);
    }
}
