using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerPicasso : MonoBehaviour
{
    public TMP_Text timeCanvas;                  // Canvas' text that shows the time used for the player in resolving the puzzle.
    private float _currentTime;                  // Variable that contains the time used by the player for resolving the puzzle.
    private bool _hasStarted;                   // Variable that controls if the game has started or not.
    private bool _hasFinished;                  // Variable that controls if the game is running or not.

    void Start()
    {
        _hasFinished = false;
        _hasStarted = false;
        _currentTime = 0.0f;
        timeCanvas.text = "00:00";
    }

    void Update()
    {
        // While the user has not resolving the puzzle ....
        if  (_hasStarted && !_hasFinished)
        {
            // ...increment the time
            _currentTime += Time.deltaTime; 
            UpdateTimer(_currentTime);
        }


    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timeCanvas.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // Function created to make the timer starts once the player has picked up the first piece of the table.
    public void GameStarts()
    {
        _hasStarted = true;
    }

    // Function created to make the timer stops one the player has placed every piece of the canvas correctly.
    public void GameEnds()
    {
        _hasFinished = true;
    }

}
