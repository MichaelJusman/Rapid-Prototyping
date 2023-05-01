using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : GameBehaviour
{
    [Header("Weapon Type")]
    public GameObject[] weaponType;
    public Transform firingPoint;

    [Header("Cannon")]
    public float cannonSpeed = 300;
    public float cannonRate = 1f;
    public float cannonCounter;

    [Header("Bullet")]
    public float bulletSpeed = 1000;
    public float bulletRate = 10f;
    public float bulletCounter;


    public void Update()
    {
        if(_GSM.gameState == GameState.Playing)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                FireWeapon();
            }

            if (Input.GetButton("Fire2"))
            {
                if (bulletCounter <= 0)
                {
                    FireSecondary();

                    bulletCounter = 1f / bulletRate;
                }

                bulletCounter -= Time.deltaTime;
            }
        }
    }

    void FireWeapon()
    {
        GameObject projectileInstance = Instantiate(weaponType[0], firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * cannonSpeed);

        Destroy(projectileInstance, 2);
    }

    void FireSecondary()
    {
        GameObject projectileInstance = Instantiate(weaponType[1], firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * bulletSpeed);

        Destroy(projectileInstance, 0.5f);
    }
}
