using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : GameBehaviour<GameStateManager>
{
    public GameState gameState;

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }
}
