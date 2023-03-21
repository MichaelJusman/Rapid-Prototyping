using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : GameBehaviour
{

    public void CloseInstructions()
    {
        _GSM.ChangeGameState(GameState.Playing);
    }
}
