using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : GameBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed);
        if (transform.position.y < -10 || transform.position.y > 10)
        {
            Destroy(gameObject);
            _GM.AddScore(20);
        }
    }
}

