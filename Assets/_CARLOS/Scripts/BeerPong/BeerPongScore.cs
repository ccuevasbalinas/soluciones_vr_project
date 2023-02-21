using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeerPongScore : MonoBehaviour
{
    private int _playerScore = 0;
    private int _rivalScore = 0;
    private string _gameTime;

    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private TextMeshProUGUI _textPlayerScore;
    [SerializeField] private TextMeshProUGUI _textRivalScore;
    [SerializeField] private TextMeshProUGUI _textGameTime;
    
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
        _gameTime = "";
    }

    public void SetTimeValue()
    {
        _gameTime = _gameTimer.GetTime();
    }

    public void UpdateCanvas()
    {
        _textPlayerScore.text = "Player Score: " + _playerScore.ToString();
        _textRivalScore.text = "Rival Score: " + _rivalScore.ToString();
        _textGameTime.text = "Time: " + _gameTime;
    }

    public void ShowScore()
    {
        Debug.Log("Score of game: " + _playerScore + "-" + _rivalScore);
    }

}
