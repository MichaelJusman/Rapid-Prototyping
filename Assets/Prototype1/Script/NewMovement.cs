using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewMovement : GameBehaviour
{

    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;
    public float speed = 5f;

    public bool hasPowerup;
    public bool hasSpeedforce;

    private float powerupStrenght = 15.0f;

    public GameObject powerupIndicator;
    public GameObject SpeedforceIndicator;

    public int maxHeatlh = 10;
    public int heal = 1;
    public int bonusHealth = 0;
    public int currentHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.FindWithTag("Plane").GetComponent<Collider>();
        currentHealth = maxHeatlh + bonusHealth;
        _UI.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                rb.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }
        rb.AddForce(transform.forward * speed);

        if (hasSpeedforce == true)
            speed = 10;
        else
            speed = 5;

        if (transform.position.y < -10 || transform.position.y > 30)
        {
            Die();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("Speedforce"))
        {
            hasSpeedforce = true;
            Destroy(other.gameObject);
            StartCoroutine(SpeedforceCountdownRoutine());
            SpeedforceIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("Heal"))
        {
            Heal(1);
            Destroy(other.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
        }

        if (collision.collider.CompareTag("Damager"))
        {
            TakeDamage();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Im hit, i have" + currentHealth + " health left");
            rb.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
        }

        if (collision.collider.CompareTag("Deathplane"))
        {
            Die();
        }
    }

    public void Heal(int _heal)
    {
        if (currentHealth < maxHeatlh)
        {
            currentHealth += _heal;
            _UI.UpdateHealthBar(currentHealth);
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        _UI.UpdateHealthBar(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        _UI.ActivateLosePanel();
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator SpeedforceCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasSpeedforce = false;
        SpeedforceIndicator.gameObject.SetActive(false);
    }
}
