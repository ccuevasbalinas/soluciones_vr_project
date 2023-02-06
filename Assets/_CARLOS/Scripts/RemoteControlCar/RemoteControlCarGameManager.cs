using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlCarGameManager : MonoBehaviour
{
    [SerializeField] private RemoteControlCar _remoteControlCar;
    [SerializeField] private RemoteControlCarLever _velocityLever;
    [SerializeField] private RemoteControlCarLever _directionLever;

    [SerializeField] private List<GameObject> coins;

    private bool _gameOn = false;
    private float _carDirectionAngle = 0.0f;
    private float _carSpeed = 0.0f;

    private int _playerScore = 0;
    private float _playerTime = 0.0f;
    private float _startTime = 0.0f;

    void Update()
    {
        //UpdateCarProperties();
        if (_gameOn)
        {
            _playerTime = Time.time - _startTime;
        }
    }

    void UpdateCarProperties()
    {
        _carDirectionAngle = _directionLever.GetAngle();
        _remoteControlCar.UpdateDirection(_carDirectionAngle);
        _carSpeed = _velocityLever.GetSpeed();
        _remoteControlCar.UpdateSpeed(_carSpeed);
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

}
