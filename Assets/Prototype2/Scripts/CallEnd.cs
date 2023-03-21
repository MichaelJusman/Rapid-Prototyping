using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnd : GameBehaviour
{
    public void callEndGame()
    {
        _GM2.OnGameEnd();
    }
}
