using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : GameBehaviour<UIManager2>
{
    
    public Slider speedSlider;
    public TMP_Text speedText;
    public float speedValue;

    public TMP_Text scoreText;
    public TMP_Text currentScoreText;

    public GameObject gameOverPanel;
    public GameObject pausePanel;


    public GameObject lostPanel;
    public GameObject strandedPanel;


    void Start()
    {
        lostPanel.SetActive(false);
        strandedPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);

    }
    public void Update()
    {
        speedSlider.onValueChanged.AddListener((v) => 
        { speedText.text = v.ToString("F0"); });
        speedSlider.onValueChanged.AddListener((v) =>
        { speedValue = v; });

    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateCurrentScore(int _score)
    {
        currentScoreText.text = "Your Score: " + _score;
    }

    //public void UpdateBestScore(int _score)
    //{
    //    bestScoreText.text = "Best Score: " + _score;
    //}

    public void OnMapExit()
    {
        lostPanel.SetActive(true);
    }

    public void OnStranded()
    {
        strandedPanel.SetActive(true);
    }

    public void OnGameEnd()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void OnPause()
    {
        pausePanel.SetActive(true);
    }

    public void OnResume()
    {
        pausePanel.SetActive(false);
    }

    public void callEndGame()
    {
        _GM2.OnGameEnd();
    }

}
