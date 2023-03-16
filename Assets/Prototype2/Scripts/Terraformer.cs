using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraformer : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Seed"))
        {
            GetComponent<Renderer>().material.color = Color.green;
            Destroy(collision.gameObject);
        }
    }
}
