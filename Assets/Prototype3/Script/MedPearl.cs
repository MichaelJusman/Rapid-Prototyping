using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPearl : GameBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public float speed = 5;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        rb.transform.LookAt(player.transform);
        rb.AddForce(transform.forward * _FS.projectileSpeed * Time.deltaTime);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Star"))
        {
            Destroy(gameObject);
            _GM3.AddMouthValue(2);
        }

        if (collision.collider.CompareTag("Damager"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}