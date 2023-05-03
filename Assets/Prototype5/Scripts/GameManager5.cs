using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager5 : GameBehaviour<GameManager5>
{

    public int enemyCount;

    public bool isPlaying;
    public bool isPaused;

    //public GameObject warpPortal;


    void Start()
    {
        _GSM.ChangeGameState(GameState.Instruction);
        _UI5.UpdateEnemyCount(enemyCount);
        //warpPortal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyTurret>().Length;
        _UI5.UpdateEnemyCount(enemyCount);


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

        if (_GSM.gameState == GameState.GameOver)
        {
            Time.timeScale = 0;
        }

        //if(enemyCount <= 0)
        //{
        //    warpPortal.SetActive(true);
        //}

    }

    public void OnPaused()
    {
        _GSM.ChangeGameState(GameState.Pause);
        Time.timeScale = 0;
        _UI5.OnPause();
    }

    public void OnResume()
    {
        _GSM.ChangeGameState(GameState.Playing);
        Time.timeScale = 1;
        _UI5.OnResume();
    }

    public void OnOutOfBounds()
    {
        _UI5.OnOutOfBounds();
    }

    public void OnDeath()
    {
        _UI5.OnDeath();
    }

    public void OnGameEnd()
    {
        _UI5.OnGameEnd();
        _GSM.ChangeGameState(GameState.GameOver);
    }

}
