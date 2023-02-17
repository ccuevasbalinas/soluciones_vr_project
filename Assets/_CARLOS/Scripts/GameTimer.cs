using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private bool countTime = true;
    private float _startTime;
    private float _gameTime;

    void OnEnable()
    {
        Debug.Log("Counting time...");
        _startTime = Time.time;
        _gameTime = 0.0f;
    }

    void Update()
    {
        if(countTime == true)
        {
            _gameTime = Time.time - _startTime;
        } 
    }

    public void StopCountingTime()
    {
        countTime= false;
    }

    public string FormatTime()
    {
        var minutes = (int)_gameTime / 60;
        var seconds = (int)_gameTime % 60;
        var timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timeString;
    }

}
