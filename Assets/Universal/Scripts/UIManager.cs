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
    public TMP_Text lastingText;
    public TMP_Text endscoreText;
    public TMP_Text speedText;
    public TMP_Text Info1;
    public TMP_Text Info2;
    public TMP_Text Info3;
    public TMP_Text Info4;
    public TMP_Text Info5;
    int score = 0;
    int scoreBonus = 50;
    public Ease scoreEase;
    float lasted;

    public Slider healthBarSlider;

    public GameObject losePanel;
    public GameObject IngameUI;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        losePanel.SetActive(false);
        IngameUI.SetActive(true);
        StartCoroutine(DisableInfo());
        Info4.enabled = false;
        Info5.enabled = false;
    }

    private void Update()
    {
        timerText.text = _TIMER.GetTime().ToString("F3");
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateEndScore(int _score)
    {

        endscoreText.text = "Score :" + _score;
    }

    public void UpdateLasting()
    {
        lasted = _TIMER.GetTime();
        lastingText.text = "Lasted :" + lasted.ToString("F3");
    }

    public void UpdateEnemyCounter(int _enemy)
    {
        enemyCounterText.text = _enemy + " Targets Left";
    }

    //public void UpdateSpeed(float _speed)
    //{
    //    speedText.text = "Speed :" + _speed.ToString("F3");
    //}

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

    public void DeactivateIngameUI()
    {
        IngameUI.SetActive(false);
    }

    public void OnGameLoss()
    {
        ActivateLosePanel();
        UpdateEndScore(_GM.score);
        UpdateLasting();
        DeactivateIngameUI();
    }

    IEnumerator DisableInfo()
    {
        yield return new WaitForSeconds(7);
        Info1.enabled = false;
        Info2.enabled = false;
        Info3.enabled = false;
        Info4.enabled = true;
        Info5.enabled = true;
        yield return new WaitForSeconds(7);
        Info4.enabled = false;
        Info5.enabled = false;
    }
}
