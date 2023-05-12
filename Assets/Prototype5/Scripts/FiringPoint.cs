using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : GameBehaviour<FiringPoint>
{
    [Header("Weapon Type")]
    public GameObject[] weaponType;
    public Transform firingPoint;

    [Header("Cannon")]
    public float cannonSpeed = 300;
    public float cannonAmmo = 10;
    public float cannonLife = 1f;

    [Header("Bullet")]
    public float bulletSpeed = 1000;
    public float bulletRate = 10f;
    public float bulletCounter;

    public void Start()
    {
        _UI5.UpdateAmmoCount(cannonAmmo);
    }

    public void Update()
    {
        if(cannonAmmo < 10)
        {
            cannonAmmo += Time.deltaTime;
            _UI5.UpdateAmmoCount(cannonAmmo);
        }
        
        if(_GSM.gameState == GameState.Playing)
        {
            if (Input.GetButtonDown("Fire1") && cannonAmmo > 1)
            {
                FireWeapon();
                cannonAmmo --;
                _UI5.UpdateAmmoCount(cannonAmmo);
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


    /// <summary>
    /// Firing a slow moving orb
    /// </summary>
    void FireWeapon()
    {
        GameObject projectileInstance = Instantiate(weaponType[0], firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * cannonSpeed);

        Destroy(projectileInstance, cannonLife);
    }

    /// <summary>
    /// Firing a SMG like bullet
    /// </summary>
    void FireSecondary()
    {
        GameObject projectileInstance = Instantiate(weaponType[1], firingPoint.position, firingPoint.rotation);

        projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * bulletSpeed);

        Destroy(projectileInstance, 0.5f);
    }
}
