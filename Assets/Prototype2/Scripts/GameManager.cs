using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class GameManager : GameBehaviour
    {
        public GameState gameState;

        public void ChangeGameState(GameState _gameState)
        {
            gameState = _gameState;
        }

        public void Update()
        {
            if (_GMS.gameState != GameState.Playing)
                return;
        }
    }




}

