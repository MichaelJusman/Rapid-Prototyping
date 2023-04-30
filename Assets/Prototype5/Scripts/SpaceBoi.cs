using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameBehaviour;

public class SpaceBoi : GameBehaviour
{
    [Header("Movement")]
    public CharacterController controller;
    public Animator anim;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float turnSpeed = 0.15f;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    [Header("Heath")]
    public int health = 100;
    public int currentHealth;
    public bool isDying;


    public void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        currentHealth = health;
        isDying = false;
        _UI5.SetMaxValueSlider(currentHealth);
        _UI5.UpdateHealthBar(currentHealth);
        _UI5.UpdateHealthText(currentHealth);
    }

    void Update()
    {
        //Check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        controller.Move(move * speed * Time.deltaTime);

        //turn the character on the direction its moving
        if (move.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }

        //Play the running animation while moving
        if (move.magnitude > 0 && isGrounded)
        {
            anim.SetTrigger("Run");
        }
        else
        {
            anim.SetTrigger("Idle");
        }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Play the jumping animation while in the air
        if(!isGrounded)
        {
            anim.SetTrigger("Jump");
            anim.ResetTrigger("Idle");
        }

        if(currentHealth <= 0 && !isDying)
        {
            OnDeath();
            isDying = true;
        }
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Damager"))
        {
            TakeDamage(10);
            _UI5.UpdateHealthBar(currentHealth);
            _UI5.UpdateHealthText(currentHealth);
            Destroy(collision.gameObject);
        }

        if (collision.collider.CompareTag("Deathplane"))
        {
            OnOutOfBounds();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Deathplane"))
        {
            OnOutOfBounds();
        }
    }

    public void OnOutOfBounds()
    {
        Debug.Log("im falin'");
        ExecuteAfterSeconds(2, () => Die());
    }

    public void OnDeath()
    {
        anim.SetTrigger("Die");
        ExecuteAfterFrames(20, () => Die());
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
