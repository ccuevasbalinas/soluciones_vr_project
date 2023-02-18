using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    #region Variables
    #region Variables · Public Variables
    public GameObject[] firstDigitGameObjects;        // Array that contains the '0-9' digits for the first number.
    public GameObject[] secondDigitGameObjects;       // Array that contains the '0-9' digits for the second number.
    public ScriptableEvent onTimeIsUp;                // Reference to a scriptable event when time's up.
    #endregion

    #region Variables · Private Variables
    [SerializeField] private float _timeLeft;         // Variable that contains the time left of te mole's game.
    private bool _hasStarted;                         // Variable that controls if the game has started or not.
    private bool _hasFinished;                        // Variable that controls if the game is running or not.
    [SerializeField] private string _sceneToTeleport; // String that allocates te name of the main scene in order to be teleported.    
    #endregion
    #endregion

    #region Methods
    void Start()
    {
        _hasFinished = false;
        _hasStarted = false;
    }

    void OnEnable()
    {
        _timeLeft = 30.0f;
    }

    void Update()
    {
        if (_hasStarted && !_hasFinished)
        {
            if (_timeLeft > 0.0f) 
            {
                _timeLeft -= Time.deltaTime; 
                UpdateTimer(_timeLeft);
            }
            else
            {
                onTimeIsUp.Raise();
                _timeLeft = 0.0f;
                _hasFinished = true;
            }
        }
    }

    // Function that updates the time left of the game.
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

    // Function that makes the game starts
    public void GameStarts()
    {
        _hasStarted = true;
    }

    // Function that finish the game by calling a coroutine that adds 5 extra seconds between the finishing of the
    // game and the teleporting process to the main scene.
    public void GameEnds()
    {
        StartCoroutine(GameEndsCoroutine());
    }

    private IEnumerator GameEndsCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(_sceneToTeleport);
    }
    #endregion
}