using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : GameBehaviour
{

    public int score;
    public int highScore;
    public string playTime;

    GameDataManager _DATA;

    void Start()
    {
        _DATA = GameDataManager.INSTANCE;


        score = 0;
        highScore = _DATA.GetHighestScore();
        playTime = _DATA.GetTimeFormatted();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score++;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
    }

    void Save()
    {
        _DATA.SetScore(score);
        _DATA.SetTimePlayed();
        _DATA.SaveData();
    }
}
