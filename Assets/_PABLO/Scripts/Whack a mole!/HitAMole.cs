using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* Script that handles the handling of points when the player's mallet hits a mole, increasing the global 
variable and making the mole disappear. */
public class HitAMole : MonoBehaviour
{
    public GameObject[] firstDigitGameObjects;  // Array that contains the '0-9' digits for the first number.
    public GameObject[] secondDigitGameObjects;  // Array that contains the '0-9' digits for the second number.
    public ScriptableEvent moleHit;              // Reference to a scriptable event for hitting a mole.
    private int _score = 0;                      // Amount of points scored by the player.
    private float _minimumDisableTime = 3.0f;    // Minimum time the mole is 'dead' until he reappears again.
    private float _maximumDisableTime = 7.0f;    // Minimum time the mole is 'dead' until he reappears again.

    void Start()
    {
        //Reset();
    }

    void OnTriggerEnter(Collider other)
    {
        // It is needed to check if the triggerer object is a mole.
        if (other.CompareTag("Mole")) { StartCoroutine(HitAMoleCoroutine(other)); }
    }

    // Coroutine that handles the trigger process of the player's mallet when collides with a mole.
    private IEnumerator HitAMoleCoroutine(Collider mole)
    {
        // If so, increment the score and show it on the screen ...
        Reset();
        AddScoreAndDisplayIt();

        // ... and disable the mole from the screen during a few seconds.
        MoleHit();
        mole.gameObject.SetActive(false);
        yield return new WaitForSeconds(Random.Range(_minimumDisableTime, _maximumDisableTime));
        mole.gameObject.SetActive(true);
    }

    // Function that incremnts the score and shows by using two digits.
    private void AddScoreAndDisplayIt()
    {
        // note: the maximum score player can achieve is 99.
        if (_score < 99) { _score++; }
        Debug.Log("Score: " + _score);
        
        // In case the score is more than 10, the first digit must be '1' and the second one is '0'. 
        // So we need to divide both numbers.
        int[] scoreByDigitsArray = new int[2];
        scoreByDigitsArray = GetDigitsArrayFromScore(_score);
        Debug.Log("Digits: " + scoreByDigitsArray[0] + "-" + scoreByDigitsArray[1]);
        for (int i = 0; i < firstDigitGameObjects.Length; i++) {
            if (i == scoreByDigitsArray[0]) { firstDigitGameObjects[i].SetActive(true); } 
            if (i == scoreByDigitsArray[1]) { secondDigitGameObjects[i].SetActive(true); } 
        }
    }

    // Function that divides the score into two separate digits.
    private int[] GetDigitsArrayFromScore(int score)
    {
        int[] listOfInts = new int[2];
        int i = 1;
        while (score > 0)
        {
            listOfInts[i] = score % 10;
            score = score / 10;
            i = i - 1;
        }
        return listOfInts;
    }

    // Function that clears the score for achieving new points or also for a new game.
    private void Reset()
    {
        for (int i = 0; i < firstDigitGameObjects.Length; i++) { 
            firstDigitGameObjects[i].SetActive(false); 
            secondDigitGameObjects[i].SetActive(false); 
        }
    }

    // Function that works with the scritable event once the mole has been hit.
    void MoleHit()
    {
        moleHit.Raise();
    }
}