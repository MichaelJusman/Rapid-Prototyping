using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager5 : GameBehaviour<GameManager5>
{

    public int enemyCount;

    public bool isPlaying;
    public bool isPaused;


    void Start()
    {
        _GSM.ChangeGameState(GameState.Instruction);
        _UI5.UpdateEnemyCount(enemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (_GSM.gameState == GameState.Playing)
        {
            isPlaying = true;
            isPaused = false;
            enemyCount = FindObjectsOfType<EnemyTurret>().Length;
            _UI5.UpdateEnemyCount(enemyCount);
        }


        if (_GSM.gameState == GameState.Pause)
        {
            isPlaying = false;
            isPaused = true;
        }
    }
}
