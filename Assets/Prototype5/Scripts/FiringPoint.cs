using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{

    public GameObject[] weaponType;
    public Transform firingPoint;
    public float projectileSpeed = 1000;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }

        if (Input.GetButton("Fire1"))
        {
            FireSecondary();
        }
    }

    void FireWeapon()
    {
        GameObject projectileInstance = Instantiate(weaponType[0], firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);

        Destroy(projectileInstance, 2);
    }

    void FireSecondary()
    {
        GameObject projectileInstance = Instantiate(weaponType[0], firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);

        Destroy(projectileInstance, 2);
    }
}
