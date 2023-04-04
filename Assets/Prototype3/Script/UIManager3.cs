using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager3 : GameBehaviour<UIManager3>
{

    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text waveText;
    public TMP_Text finalScoreText;

    public GameObject gameOverPanel;
    public GameObject pausePanel;

    public Slider mouthSlider;




    void Start()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);

    }
    public void Update()
    {

    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateFinalScoreText(int _score)
    {
        finalScoreText.text = "Score: " + _score;
    }

    public void UpdateWave(int _wave)
    {
        waveText.text = "Wave: " + _wave;
    }

    public void UpdateHeath(int _heath)
    {
        healthText.text = "Heath: " + _heath;
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

    public void CallEndGame()
    {
        _GM3.OnGameEnd();
    }

    public void UpdateMouthSlider(int _mouth)
    {
        mouthSlider.value = _mouth;
    }
}
