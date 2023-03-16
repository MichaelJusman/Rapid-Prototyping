using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraformer : GameBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Seed"))
        {
            GetComponent<Renderer>().material.color = Color.green;
            Destroy(collision.gameObject);


            //roto2.GameManager.AddScoore(1);P
        }
    }
}
