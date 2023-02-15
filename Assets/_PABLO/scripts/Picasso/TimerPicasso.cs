using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerPicasso : MonoBehaviour
{
    #region Variables
    #region Variables · Public Variable
    public TMP_Text timeCanvas;                  // Canvas' text that shows the time used for the player in resolving the puzzle.
    public TMP_Text bestTimeCanvas;             // Canvas' text that shows the best record resolving the game.
    public static float bestTime = 3599.00f;     // Float that allocates the best time used for the player for resolving the puzzle.
    #endregion

    #region Variables · Private Variables
    private float _currentTime;                  // Variable that contains the time used by the player for resolving the puzzle.
    private bool _hasStarted;                   // Variable that controls if the game has started or not.
    private bool _hasFinished;                  // Variable that controls if the game is running or not.
    #endregion
    #endregion

    #region Methods
    void Start()
    {
        _hasFinished = false;
        _hasStarted = false;
        _currentTime = 0.0f;
        timeCanvas.text = "00:00";
        UpdateTimer(bestTime, bestTimeCanvas);
    }

    void Update()
    {
        // While the user has not resolving the puzzle ....
        if  (_hasStarted && !_hasFinished)
        {
            // ...increment the time
            _currentTime += Time.deltaTime; 
            UpdateTimer(_currentTime, timeCanvas);
        }
    }

    // Function that updates a canvas' time used for the player.
    private void UpdateTimer(float currentTime, TMP_Text canvas)
    {
        currentTime += 1;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        canvas.text = minutes.ToString("00") + ":" + seconds.ToString("00");
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

        // The game has finished. Check if the time used for the playuer is less than best time
        if (_currentTime < bestTime)
        {
            bestTime = _currentTime;
            bestTimeCanvas.text = bestTime.ToString();
        }
    }
    #endregion
}
