using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : GameBehaviour<GameManager>
{
    public int score;
    public int scoreMultiplier = 1;

    public float tweenTime = 0.2f;

    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        _TIMER.StartTimer(0, TimerDirection.CountUp);
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.C))
        //    _TIMER.ChangeTimerDirection(TimerDirection.CountDown);
        //if (Input.GetKeyDown(KeyCode.U))
        //    _TIMER.ChangeTimerDirection(TimerDirection.CountUp);
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    if (_TIMER.IsTiming())
        //        _TIMER.PauseTimer();
        //    else
        //        _TIMER.ResumeTimer();
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (_TIMER.IsTiming())
            {
                _TIMER.PauseTimer();
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
            else
            {
                _TIMER.ResumeTimer();
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
        }


        if (_TIMER.TimeExpired())
        {
            Debug.Log("Time Expired");
        }
    }

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplier;
        _UI.UpdateScore(score);
    }

    public void ShakeCamera()
    {
        Camera.main.DOShakePosition(tweenTime / 2, 1.2f);
    }

    public void ResumeGame()
    {
        _TIMER.ResumeTimer();
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
