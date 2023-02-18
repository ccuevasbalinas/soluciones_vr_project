using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoteControlCarGameManager : MonoBehaviour
{
    [SerializeField] private RemoteControlCar _remoteControlCar;
    [SerializeField] private RemoteControlCarLever _velocityLever;
    [SerializeField] private RemoteControlCarLever _directionLever;

    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private TextMeshProUGUI _textTime;

    [SerializeField] private List<GameObject> coins;

    private bool _gameOn = false;
    private float _carDirectionAngle = 0.0f;
    private float _carSpeed = 0.0f;

    private int _playerScore = 0;
    private float _playerTime = 0.0f;
    private float _startTime = 0.0f;

    void Update()
    {
        if (_gameOn)
        {
            _playerTime = Time.time - _startTime;
        }
    }

    public void SetStartTime()
    {
        _startTime = Time.time;
    }

    public void SetOnGame()
    {
        _gameOn = true;
    }

    public void SetOffGame()
    {
        _gameOn = false;
    }

    public void RestartGame()
    {
        _playerScore = 0;
        _playerTime = 0.0f;
        _startTime = 0.0f;
        foreach (GameObject c in coins) 
        {
            c.SetActive(true);
        }
    }

    public void IncrementPlayerScore()
    {
        _playerScore = _playerScore + 1;
    }

    public void ShowScore()
    {
        Debug.Log("Remote control car score: coins -> " + _playerScore + " in time -> " + _playerTime );
    }

    public void UpdateCanvas()
    {
        _textScore.text = "Coins: " + _playerScore.ToString();
        _textTime.text = "Time: " + FormatTime();
    }

    public string FormatTime()
    {
        var minutes = (int)_playerTime / 60;
        var seconds = (int)_playerTime % 60;
        var timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timeString;
    }

}
