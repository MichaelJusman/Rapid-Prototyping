using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager2 : GameBehaviour<GameManager2>
{

    public int score;
    public int scoreMultiplier = 1;

    public int currentScore = 0;
    public int bestScore = 0;

    public bool isPlaying;
    public bool isPaused;

    public void Start()
    {
        _GSM.ChangeGameState(GameState.Instruction);
    }

    public void Update()
    {
        if (_GSM.gameState == GameState.Playing)
        {
            isPlaying = true;
            isPaused = false;
        }


        if (_GSM.gameState == GameState.Pause)
        {
            isPlaying = false;
            isPaused = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPlaying)
        {
            _GSM.ChangeGameState(GameState.Pause);
            Time.timeScale = 0;
            _UI2.OnPause();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            _GSM.ChangeGameState(GameState.Playing);
            Time.timeScale = 1;
            _UI2.OnResume();
        }

    }

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI2.UpdateScore(score);

    }
    
    public void OnGameEnd()
    {
        _GSM.ChangeGameState(GameState.GameOver);

        _UI2.OnGameEnd();

        currentScore = score;
        _UI2.UpdateCurrentScore(currentScore);

        if (currentScore >= bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("BestTime", bestScore);
            //_UI2.UpdateBestScore(bestScore);


            //bestTime = currentTime;
            //PlayerPrefs.SetFloat("BestTime" + sceneController.GetSceneName(), bestTime);
            //bestTimeResult.text = bestTime.ToString("F3") + " !! NEW BEST !!";
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _GSM.ChangeGameState(GameState.Playing);
        _UI2.OnResume();
    }

}
