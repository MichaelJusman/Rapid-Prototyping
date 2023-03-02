using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GameBehaviour<UIManager>
{

    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text enemyCounterText;
    int score = 0;
    int scoreBonus = 50;
    public Ease scoreEase;

    public Slider healthBarSlider;

    public GameObject losePanel;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        losePanel.SetActive(false);
    }

    private void Update()
    {
        timerText.text = _TIMER.GetTime().ToString("F3");
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateEnemyCounter(int _enemy)
    {
        enemyCounterText.text = _enemy + " Targets Left";
    }

    //Update is called once per frame
    public void TweenScore(int _score)
    {
        DOTween.To(() => score, x => score = x, score + scoreBonus, 1).SetEase(scoreEase).OnUpdate(() =>
        {
            scoreText.text = "Score: " + _score.ToString();
        });
    }

    public void SetMaxHealth(int _health)
    {
        healthBarSlider.maxValue = _health;
        healthBarSlider.value = _health;
    }

    public void UpdateHealthBar(int _health)
    {
        healthBarSlider.value = _health;
    }

    public void ActivateLosePanel()
    {
        losePanel.SetActive(true);
    }
}
