using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager4 : GameBehaviour<GameManager4>
{
    public int score;
    public int scoreMultiplier = 1;

    public int currentScore = 0;
    public int bestScore = 0;
    public int mouthScore = 0;

    public bool isPlaying;
    public bool isPaused;

    public List<CubeNumber> cubeNumbers;
    public List<CubeSymbols> cubeSymbols;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            ResetAllCubes();
    }

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI4.UpdateScore(score);
    }

    public void OnCorrectAnswer()
    {
        _UI4.OnCorrectAnswer();
    }

    public void OnWrongAnswer()
    {
        _UI4.OnWrongAnswer();
    }

    public void ResetAllCubes()
    {
        foreach (var cube in cubeNumbers)
        {
            cube.ResetCube();
        }

        foreach (var cube in cubeSymbols)
        {
            cube.ResetCube();
        }
    }
}
