using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;

    public GameObject turretHead;
    public GameObject redGlow;
    public GameObject greenGlow;

    public void Start()
    {
        currentHealth = health;
    }

    public void Update()
    {
        if(health <= 0)
        {
            Defeat();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Number1"))
        {
            TakeDamage(20);
        }

        if (collision.collider.CompareTag("Number1"))
        {
            TakeDamage(2);
        }
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
    }

    public void Defeat()
    {

    }
}
