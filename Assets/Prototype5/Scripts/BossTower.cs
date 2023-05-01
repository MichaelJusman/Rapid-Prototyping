using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossTower : GameBehaviour
{
    [Header("Health")]
    public int health = 100;
    public int currentHealth;
    public bool isDefeated;

    [Header("Body")]
    public GameObject turretHead;
    public GameObject redGlow;
    public GameObject greenGlow;

    [Header("UI")]
    public TMP_Text heathText;
    public Slider healthBarSlider;

    public void Start()
    {
        currentHealth = health;
        turretHead.SetActive(true);
        redGlow.SetActive(true);
        greenGlow.SetActive(false);
        SetMaxValueSlider(currentHealth);
        UpdateHealthBar(currentHealth);
        UpdateHealthText(currentHealth);
        isDefeated = false;
    }

    public void Update()
    {
        if (currentHealth <= 0 && !isDefeated)
        {
            Defeat();
            isDefeated = true;
            _GM5.OnGameEnd();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Number1"))
        {
            TakeDamage(20);
            UpdateHealthBar(currentHealth);
            UpdateHealthText(currentHealth);
            Destroy(collision.gameObject);

        }

        if (collision.collider.CompareTag("Number2"))
        {
            TakeDamage(2);
            UpdateHealthBar(currentHealth);
            UpdateHealthText(currentHealth);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
    }

    public void Defeat()
    {
        turretHead.SetActive(false);
        redGlow.SetActive(false);
        greenGlow.SetActive(true);
        Debug.Log("I am defeated");
    }

    public void UpdateHealthBar(int _health)
    {
        healthBarSlider.value = _health;
    }

    public void SetMaxValueSlider(int _health)
    {
        healthBarSlider.maxValue = _health;
    }

    public void UpdateHealthText(int _health)
    {
        heathText.text = _health.ToString();
    }
}
