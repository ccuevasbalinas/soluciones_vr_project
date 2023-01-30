using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject[] firstDigitGameObjects;  // Array that contains the '0-9' digits for the first number.
    public GameObject[] secondDigitGameObjects;  // Array that contains the '0-9' digits for the second number.
    public ScriptableEvent timerEvent;            // Reference to a scriptable event when time's up.

    [SerializeField]
    private float _timeLeft;                     // Variable that contains the time left of te mole's game.
    private bool _hasFinished;                  // Variable that controls if the game is running or not.
    

    void Start()
    {
        _hasFinished = false;
    }

    void OnEnable()
    {
        _timeLeft = 30.0f;
    }

    void Update()
    {
        if (!_hasFinished)
        {
            if (_timeLeft > 0.0f) 
            {
                _timeLeft -= Time.deltaTime; 
                UpdateTimer(_timeLeft);
            }
            else
            {
                timerEvent.Raise();
                _timeLeft = 0.0f;
                _hasFinished = true;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // In case the timer is more than 10, the first digit must be '1' and the second one is '0'. 
        // So we need to divide both numbers.
        int[] timeByDigitsArray = new int[2];
        timeByDigitsArray = GetDigitsArrayFromTime(seconds);
        Reset();
        for (int i = 0; i < firstDigitGameObjects.Length; i++) {
            if (i == timeByDigitsArray[0]) { firstDigitGameObjects[i].SetActive(true); } 
            if (i == timeByDigitsArray[1]) { secondDigitGameObjects[i].SetActive(true); } 
        }
    }

    // Function that divides the time into two separate digits.
    private int[] GetDigitsArrayFromTime(int seconds)
    {
        int[] listOfInts = new int[2];
        int i = 1;
        while (seconds > 0)
        {
            listOfInts[i] = seconds % 10;
            seconds = seconds / 10;
            i = i - 1;
        }
        return listOfInts;
    }

    // Function that clears the timer every second. Thus it gives the sensation is being updating.
    private void Reset()
    {
        for (int i = 0; i < firstDigitGameObjects.Length; i++) { 
            firstDigitGameObjects[i].SetActive(false); 
            secondDigitGameObjects[i].SetActive(false); 
        }
    }
}
