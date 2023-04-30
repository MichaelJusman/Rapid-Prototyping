using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : GameBehaviour
{
    [Header("Aim & Detection")]
    public Transform target;
    public Transform firingPoint;
    public GameObject turretHead;
    public bool isEngaged;

    [Header("Projectiles")]
    public GameObject orbBullet;
    public float projectileSpeed = 1000f;

    [Header("Firing")]
    public float fireRate = 1f;
    public float fireCounter;


    // Start is called before the first frame update
    void Start()
    {
        isEngaged = false;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEngaged)
        {
            turretHead.transform.LookAt(target);

            if(fireCounter <= 0)
            {
                FireOrb();
                fireCounter = 1f/fireRate;
            }

            fireCounter -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isEngaged = true;
            target = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEngaged = false;
            target = null;

        }
    }

    void FireOrb()
    {
        GameObject projectileInstance = Instantiate(orbBullet, firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);

        Destroy(projectileInstance, 2);
    }
}
