using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimerDirection { CountUp, CountDown }
public class Timer : GameBehaviour<Timer>
{
    public TimerDirection timerDirection;
    public float startTime = 20f;
    float currentTime;
    bool isTiming = false;
    bool hasTimeLimit = false;
    float timeLimit = 0f;

    private void Start()
    {
        
    }

    void Update()
    {
        if(!isTiming)
            return;

        //if timerDirection == TimerDirection.CountDown, increment the current time, else decrement the current time
        currentTime = timerDirection == TimerDirection.CountUp ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;

        //if (currentTime < 0 && !hasTimeLimit)
        //{
        //    currentTime = 0;
        //    StopTimer();
        //}

        if (hasTimeLimit && currentTime == timeLimit)
        {
            StopTimer();
        }


    }

    /// <summary>
    /// Start timer
    /// </summary>
    /// <param name="_startTime">The start of the timer. Default to 0</param>
    /// <param name="_direction">The direction of the timer. Defaults to CountUp.</param>
    public void StartTimer(float _startTime = 0, TimerDirection _direction = TimerDirection.CountUp)
    {
        timerDirection = _direction;
        startTime = _startTime;
        isTiming = true;   
    }

    /// <summary>
    /// Starts timer
    /// </summary>
    /// <param name="_startTime">what the time to start at</param>
    /// <param name="_timeLimit">what the time limit of the timer</param>
    /// <param name="_hasTimeLimit">Use a time limit</param>
    /// /// <param name="_direction">The direction of the timer. Defaults to CountUp.</param>
    public void StartTimer(float _startTime = 0, float _timeLimit = 0, bool _hasTimeLimit = true, TimerDirection _direction = TimerDirection.CountUp)
    {
        timerDirection = _direction;
        hasTimeLimit = _hasTimeLimit;
        startTime = _startTime;
        timeLimit = _timeLimit;
        isTiming = true;
    }

    /// <summary>
    /// Resume timer
    /// </summary>
    public void ResumeTimer()
    {
        isTiming = true;
    }

    /// <summary>
    /// Pause timer
    /// </summary>
    public void PauseTimer()
    {
        isTiming = false;
    }

    /// <summary>
    /// Stop timer
    /// </summary>
    public void StopTimer()
    {
        isTiming = false;
    }

    /// <summary>
    /// Increment our timer
    /// </summary>
    /// <param name="_increment">The increment amount to the timer</param>
    public void IncrementTimer(float _increment)
    {
        currentTime += _increment;
    }

    /// <summary>
    /// Decrement our timer
    /// </summary>
    /// <param name="_decrement">The decrement amount to the timer</param>
    public void DecrementTumer(float _decrement)
    {
        currentTime -= _decrement;
    }

    /// <summary>
    /// Check if time has expired
    /// </summary>
    /// <returns>if time has expired</returns>
    public bool TimeExpired()
    {
        if (!hasTimeLimit)
            return false;

        return timerDirection == TimerDirection.CountDown ? currentTime < timeLimit : currentTime > timeLimit;
    }

    /// <summary>
    /// Get current time
    /// </summary>
    /// <returns>the current time</returns>
    public float GetTime()
    {
        return currentTime;
    }

    /// <summary>
    /// Check if we are timing or not
    /// </summary>
    /// <returns>if we are timing</returns>
    public bool IsTiming()
    {
        return isTiming;
    }

    /// <summary>
    /// Change the direction of the timer
    /// </summary>
    /// <param name="_direction">direction to change to</param>
    public void ChangeTimerDirection(TimerDirection _direction)
    {
        timerDirection = _direction;
    }
}
