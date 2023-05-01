using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : GameBehaviour
{

    public GameObject[] weaponType;
    public Transform firingPoint;
    public float cannonSpeed = 300;
    public float bulletSpeed = 1000;

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
                FireSecondary();
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

        Destroy(projectileInstance, 2);
    }
}
