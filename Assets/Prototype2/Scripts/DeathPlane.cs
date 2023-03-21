using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : GameBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        _RT.DelayedDeath();
        _UI2.OnMapExit();
    }
}
