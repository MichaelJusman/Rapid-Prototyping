using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager5 : GameBehaviour<UIManager5>
{
    [Header("Panels")]
    public GameObject ingamePanel;
    public GameObject pausePanel;
    public GameObject endPanel;
    public GameObject fallPanel;
    public GameObject diePanel;

    [Header("IngameUI")]
    public Slider healthBarSlider;
    public TMP_Text healthText;
    public TMP_Text enemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        ingamePanel.SetActive(true);
        pausePanel.SetActive(false);
        endPanel.SetActive(false);
        fallPanel.SetActive(false);
        diePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameEnd()
    {
        ingamePanel.SetActive(false);
        endPanel.SetActive(true);
    }

    public void OnDeath()
    {
        diePanel.SetActive(true);
        ExecuteAfterSeconds(2, () => _GM5.OnGameEnd());
    }

    public void OnOutOfBounds()
    {
        fallPanel.SetActive(true);
        ExecuteAfterSeconds(2, () => _GM5.OnGameEnd());
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
        healthText.text = _health.ToString();
    }

    public void UpdateEnemyCount(int _enemy)
    {
        enemyCountText.text = "Enemy Left: " + _enemy.ToString();
    }

    public void OnPause()
    {
        pausePanel.SetActive(true);
    }

    public void OnResume()
    {
        pausePanel.SetActive(false);
    }
}
