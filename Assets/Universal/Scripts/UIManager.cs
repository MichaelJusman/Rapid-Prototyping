using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GameBehaviour<UIManager>
{

    public TMP_Text scoreText;
    int score = 0;
    int scoreBonus = 50;
    public Ease scoreEase;

    public Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    //Update is called once per frame
    public void TweenScore()
    {
        DOTween.To(() => score, x => score = x, score + scoreBonus, 1).SetEase(scoreEase).OnUpdate(() =>
        {
            scoreText.text = "Score: " + score.ToString();
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
}
