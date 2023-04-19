using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaving : GameBehaviour
{
    int score = 0;
    int highscore = 0;

    private void Start()
    {
        print("Score :" + score);
        highscore = PlayerPrefs.GetInt("HighScore");
        print("High Score :" + highscore);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            print("Score :" + score);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
    }

    void GameOver()
    {
        if(score > highscore)
        {
            highscore = score;
            print("New High Score! " + highscore);
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
