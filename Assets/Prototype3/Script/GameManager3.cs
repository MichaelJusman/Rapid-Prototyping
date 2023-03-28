using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : GameBehaviour<GameManager3>
{
    public int score;
    public int scoreMultiplier = 1;

    public int currentScore = 0;
    public int bestScore = 0;

    public bool isPlaying;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        _GSM.ChangeGameState(GameState.Instruction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI3.UpdateScore(score);

    }
}
