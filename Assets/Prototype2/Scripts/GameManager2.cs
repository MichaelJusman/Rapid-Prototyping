using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager2 : GameBehaviour<GameManager2>
{

    public int score;
    public int scoreMultiplier = 1;

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI2.UpdateScore(score);

    }

    
}
