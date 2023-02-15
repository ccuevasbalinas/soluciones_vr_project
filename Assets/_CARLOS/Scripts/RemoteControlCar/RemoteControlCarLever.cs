using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlCarLever : MonoBehaviour
{
    [SerializeField] private bool _isVelocityLever = false;

    [SerializeField] private RemoteControlCar _remoteControlCar;

    [SerializeField] private LayerMask _lever1Layer;
    [SerializeField] private LayerMask _lever2Layer;
    [SerializeField] private LayerMask _lever3Layer;
    [SerializeField] private LayerMask _lever4Layer;
    [SerializeField] private LayerMask _lever5Layer;

    private float _angle = 0.0f;
    private float _speed = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (_lever1Layer == (1 << other.gameObject.layer | _lever1Layer))
        {
            if(_isVelocityLever)
            {
                Debug.Log("Velocity Lever 1");
                _speed = 0.0f;
                _remoteControlCar.UpdateSpeed(_speed);
            }
            else
            {
                Debug.Log("Direction Lever 3");
                //_angle = 90.0f;
                _angle = 0.0f;
                _remoteControlCar.UpdateDirection(_angle);
            }
        }
        if (_lever2Layer == (1 << other.gameObject.layer | _lever2Layer))
        {
            if (_isVelocityLever)
            {
                Debug.Log("Velocity Lever 2");
                _speed = 1.0f;
                _remoteControlCar.UpdateSpeed(_speed);
            }
            else
            {
                Debug.Log("Direction Lever 2");
                //_angle = 112.5f;
                _angle = 22.5f;
                _remoteControlCar.UpdateDirection(_angle);
            }
        }
        if (_lever3Layer == (1 << other.gameObject.layer | _lever3Layer))
        {
            if (_isVelocityLever)
            {
                Debug.Log("Velocity Lever 3");
                _speed = 2.0f;
                _remoteControlCar.UpdateSpeed(_speed);
            }
            else
            {
                Debug.Log("Direction Lever 3");
                //_angle = 135.0f;
                _angle = 45.0f;
                _remoteControlCar.UpdateDirection(_angle);
            }
        }
        if (_lever4Layer == (1 << other.gameObject.layer | _lever4Layer))
        {
            if (_isVelocityLever)
            {
                Debug.Log("Velocity Lever 4");
                _speed = 3.0f;
                _remoteControlCar.UpdateSpeed(_speed);
            }
            else
            {
                Debug.Log("Direction Lever 4");
                //_angle = 67.5f;
                _angle = -22.5f;
                _remoteControlCar.UpdateDirection(_angle);
            }
        }
        if (_lever5Layer == (1 << other.gameObject.layer | _lever5Layer))
        {
            if (_isVelocityLever)
            {
                Debug.Log("Velocity Lever 5");
                _speed = 4.0f;
                _remoteControlCar.UpdateSpeed(_speed);
            }
            else
            {
                Debug.Log("Direction Lever 5");
                _angle = -45.0f;
                _remoteControlCar.UpdateDirection(_angle);
            }
        }
        

    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetAngle()
    {
        return _angle;
    }

}
