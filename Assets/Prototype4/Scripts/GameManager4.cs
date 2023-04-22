using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager4 : GameBehaviour<GameManager4>
{
    public int score;
    public int scoreMultiplier = 1;
    public int money = 10;

    public int materialCost = 5;
    public int materialCostIncrease = 2;

    public bool isPlaying;
    public bool isPaused;

    public List<CubeNumber> cubeNumbers;
    public List<CubeSymbols> cubeSymbols;

    public void Start()
    {
        materialCost = 5;
        _UI4.UpdateMoney(money);
        _UI4.UpdateScore(score);
        _UI4.UpdateCost(materialCost);
        _GSM.ChangeGameState(GameState.Playing);
    }

    public void Update()
    {
        if (_GSM.gameState == GameState.Playing)
        {
            if (Input.GetKeyDown(KeyCode.L))
                ResetAllCubes();

            //if (score <= 0)
            //{
            //    OnGameEnd();
            //}
        }

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
            OnPaused();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            OnResume();
        }

        if (money < materialCost)
        {
            _UI4.UpdateEndGame();
            _UI4.UpdateButtonText();
        }

        if (money > materialCost)
        {
            _UI4.UpdateCost(materialCost);
            _UI4.ResetButtonText();
        }

    }

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI4.UpdateScore(score);
    }

    public void DecreaseScore(int _score)
    {
        if (score >= 0)
        {
            score -= _score * scoreMultiplier;
            _UI3.UpdateScore(score);
        }
        
        if (score < 0)
        {
            ExecuteAfterSeconds(2, () => OnGameEnd());
        }
    }

    public void AddMoney(int _money)
    {
        money += _money;
        _UI4.UpdateMoney(money);
    }

    public void OnCorrectAnswer()
    {
        _UI4.OnCorrectAnswer();
    }

    public void OnWrongAnswer()
    {
        _UI4.OnWrongAnswer();
    }

    public void ResetAllCubes()
    {
        if (money >= materialCost)
        {
            money -= materialCost;
            _UI4.UpdateMoney(money);

            foreach (var cube in cubeNumbers)
            {
                cube.ResetCube();
            }

            foreach (var cube in cubeSymbols)
            {
                cube.ResetCube();
            }

            IncreaseCost();

            

            Debug.Log("money: " + money.ToString() + ", cost: " + materialCost.ToString());
        }
        else
        {
            OnGameEnd();
        }
    }

    public void IncreaseCost()
    {
        materialCost++;
        _UI4.UpdateCost(materialCost);
    }

    public void OnGameEnd()
    {
        _GSM.ChangeGameState(GameState.GameOver);
        _UI4.OnGameEnd();
        _UI4.UpdateFinalScore(score);
    }

    public void OnPaused()
    {
        _GSM.ChangeGameState(GameState.Pause);
        Time.timeScale = 0;
        _UI4.OnPause();
    }

    public void OnResume()
    {
        _GSM.ChangeGameState(GameState.Playing);
        Time.timeScale = 1;
        _UI4.OnResume();
    }
}
