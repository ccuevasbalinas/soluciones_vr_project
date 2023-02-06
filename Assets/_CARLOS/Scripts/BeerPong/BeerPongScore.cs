using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongScore : MonoBehaviour
{
    private int _playerScore = 0;
    private int _rivalScore = 0;
    
    public void IncrementPlayerScore()
    {
        _playerScore = _playerScore + 1;
    }

    public void IncremnetRivalScore()
    {
        _rivalScore= _rivalScore + 1;
    }

    public void ResetScore()
    {
        _playerScore = 0;
        _rivalScore= 0;
    }

    public void ShowScore()
    {
        Debug.Log("Score of game: " + _playerScore + "-" + _rivalScore);
    }

}
