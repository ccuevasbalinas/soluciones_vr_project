using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlCarGameManager : MonoBehaviour
{
    [SerializeField] private RemoteControlCar _remoteControlCar;
    [SerializeField] private Transform _steeringCarWheelTransform;
    //[SerializeField] private S

    private bool _gameOn = false;


    public void SetOnGame()
    {
        _gameOn = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOn)
        {
            _remoteControlCar.UpdateForward(_steeringCarWheelTransform);
            //_remoteControlCar.UpdateSpeed();
        }
    }
}
