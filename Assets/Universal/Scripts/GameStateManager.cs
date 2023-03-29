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
                break;
            case GameState.Pause:
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                break;

        }
    }
}
