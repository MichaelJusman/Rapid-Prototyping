using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Enemy : GameBehaviour
{

    public float speed;
    private Rigidbody rb;
    private GameObject player;
    Collider walls;
    public bool tagged = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce( lookDirection * speed);
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
            
            if (tagged)
                _GM.AddScore(10);
            else
                _GM.AddScore(5);

        }

        if (collision.collider.CompareTag("Player"))
        {
            tagged = true;
            GetComponent<Renderer>().material.color = Color.blue;

        }
    }
}
