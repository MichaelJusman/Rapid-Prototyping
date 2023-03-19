using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraformer : GameBehaviour
{
    public GameObject mainPlanet;
    public GameObject terraformedPlanet;

    public void Start()
    {
        mainPlanet.SetActive(true);
        terraformedPlanet.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Seed"))
        {
            terraformedPlanet.SetActive(true);
            mainPlanet.SetActive(false);
            Destroy(collision.gameObject);
            _GM2.AddScore(1);
        }

        if (collision.collider.CompareTag("Player"))
        {
            _RT.Die();
        }
    }
}
