using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager3 : GameBehaviour<UIManager3>
{

    public TMP_Text scoreText;
    public TMP_Text healthText;

    public GameObject gameOverPanel;
    public GameObject pausePanel;




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

    public void callEndGame()
    {
        //_GM3.OnGameEnd();
    }
}
