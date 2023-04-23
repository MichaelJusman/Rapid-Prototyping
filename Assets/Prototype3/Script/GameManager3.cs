using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : GameBehaviour<GameManager3>
{
    public int score;
    public int scoreMultiplier = 1;

    public int currentScore = 0;
    public int bestScore = 0;
    public int mouthScore = 0;

    public bool isPlaying;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        _GSM.ChangeGameState(GameState.Instruction);
    }

    // Update is called once per frame
    void Update()
    {
        if (_GSM.gameState == GameState.Playing || _GSM.gameState == GameState.Instruction)
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
            OnPaused();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            OnResume();
        }
    }

    public void OnPaused()
    {
        _GSM.ChangeGameState(GameState.Pause);
        Time.timeScale = 0;
        _UI3.OnPause();
    }

    public void OnResume()
    {
        _GSM.ChangeGameState(GameState.Playing);
        Time.timeScale = 1;
        _UI3.OnResume();
    }

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI3.UpdateScore(score);
        

    }

    public void DecreaseScore(int _score)
    {
        if(score>0)
        {
            score -= _score * scoreMultiplier;
            _UI3.UpdateScore(score);
        }
    }

    public void AddMouthValue(int _mouth)
    {
        if(mouthScore < 3)
        {
            mouthScore += _mouth;
        }

        if(mouthScore > 3)
        {
            mouthScore = 3;
        }

        _UI3.UpdateMouthSlider(mouthScore);
    }

    public void RemoveMouthValue()
    {
        mouthScore = 0;
        _UI3.UpdateMouthSlider(mouthScore);
    }

    public void ConvertMouthToScore()
    {
        if(mouthScore == 3)
        {
            score += mouthScore;
            RemoveMouthValue();
            _UI3.UpdateScore(score);
            _PM1.Heal(1);
        }
        else
        {
            score += mouthScore;
            RemoveMouthValue();
            _UI3.UpdateScore(score);
        }
        
    }

    public void OnGameEnd()
    {
        _GSM.ChangeGameState(GameState.GameOver);
        _UI3.OnGameEnd();
        _UI3.UpdateFinalScoreText(score);
    }

    public void RestartPlay()
    {
        _GSM.ChangeGameState(GameState.GameOver);
    }
}
