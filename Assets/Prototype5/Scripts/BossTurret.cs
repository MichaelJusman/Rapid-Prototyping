using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum WeaponType { Orb, Lazer, AOE, Homing}
public class BossTurret : GameBehaviour
{
    
    [Header("Aim & Detection")]
    public Transform target;
    public GameObject targetPlayer;
    public Transform firingPoint;
    public Transform stillPoint;
    public GameObject turretHead;
    public bool isEngaged;

    [Header("Attack Variations")]
    public int randomAttacks;
    public float fireRate = 1f;
    public float fireCounter;
    WeaponType weaponType;

    [Header("Orb")]
    public GameObject orbBullet;
    public float orbSpeed = 1000f;

    [Header("Lazer")]
    public GameObject lazerPillar;
    public float lazerSpeed = 3000f;

    [Header("AOE")]
    public GameObject aoeAttack;
    public GameObject aoeIndicator;

    [Header("Homing")]
    public GameObject homingMissile;
    public float homingSpeed = 5;
    public GameObject HomingInstance;



    // Start is called before the first frame update
    void Start()
    {
        isEngaged = false;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEngaged)
        {
            turretHead.transform.LookAt(target);


            if (fireCounter <= 0)
            {
                RandomWeaponChange();
                fireCounter = 1f / fireRate;
            }

            fireCounter -= Time.deltaTime;


        }
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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

    void ChangeWeapon()
    {
        switch (weaponType)
        {
            case WeaponType.Orb:
                FireOrb();
                break;

            case WeaponType.Lazer:
                LazerPillar();
                break;

            case WeaponType.AOE:
                AOEAttact();
                break;
            case WeaponType.Homing:
                HomingAttack();
                break;
        }
            
    }

    void RandomWeaponChange()
    {
        weaponType = RandomEnum<WeaponType>();
        ChangeWeapon();
    }

    void FireOrb()
    {
        GameObject projectileInstance = Instantiate(orbBullet, firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * orbSpeed);

        Destroy(projectileInstance, 2);
    }

    void LazerPillar()
    {
        GameObject lazerInstance = Instantiate(lazerPillar, firingPoint.position, firingPoint.rotation);
        lazerInstance.GetComponent<Rigidbody>().MovePosition(firingPoint.forward * lazerSpeed);
        Destroy(lazerInstance, 2);

    }

    void AOEAttact()
    {
        GameObject AOEInstance = Instantiate(aoeAttack, stillPoint.position, stillPoint.rotation);
        Destroy(AOEInstance, 5);

    }

    void HomingAttack()
    {
        GameObject HomingInstance = Instantiate(homingMissile, firingPoint.position, firingPoint.rotation);
        Destroy(HomingInstance, 2);
    }
}
