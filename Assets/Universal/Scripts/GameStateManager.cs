using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : GameBehaviour<GameStateManager>
{
    public GameState gameState;

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
        Setup();
    }

    public void Setup()
    {
        switch (gameState)
        {
            case GameState.Instruction:
                Time.timeScale = 0;
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                break;

        }
    }
}
