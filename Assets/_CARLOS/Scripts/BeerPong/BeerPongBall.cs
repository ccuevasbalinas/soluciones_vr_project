using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BeerPongBall : MonoBehaviour
{
    [SerializeField] private bool _isPlayerBall = false;
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private LayerMask _floorLayer;
    [SerializeField] private LayerMask _controlLayer;

    [SerializeField] private ScriptableEvent _endOfPlayerTurnEvent;
    [SerializeField] private ScriptableEvent _endOfRivalTurnEvent;
    [SerializeField] private ScriptableEvent _enterPlayerCupEvent;
    [SerializeField] private ScriptableEvent _enterRivalCupEvent;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private bool _flag = false;
    private float _controlTime = 0.0f;
    private float _time = 0.0f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void EndOfTurn()
    {
        if(_isPlayerBall)
        {
            _endOfPlayerTurnEvent.Raise();
        }
        else
        {
            _endOfRivalTurnEvent.Raise();
        }
        gameObject.SetActive(false);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_targetLayer == (1 << other.gameObject.layer | _targetLayer))
        {
            if(_isPlayerBall)
            {
                _enterRivalCupEvent.Raise();
            }
            else
            {
                _enterPlayerCupEvent.Raise();
            }
            other.gameObject.transform.parent.gameObject.SetActive(false);
            EndOfTurn();
        }
        if (_floorLayer == (1 << other.gameObject.layer | _floorLayer))
        {
            EndOfTurn();
        }
        if (_controlLayer == (1 << other.gameObject.layer | _controlLayer))
        {
            if(!_isPlayerBall)
            {
                _flag = true;
                _controlTime = 0.0f;
                _time = Time.time;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_controlLayer == (1 << other.gameObject.layer | _controlLayer))
        {
            if (!_isPlayerBall)
            {
                _flag = false;
                _controlTime = 0.0f;
                _time = 0.0f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_flag)
        {
            _controlTime = Time.time - _time;
            if (_controlTime == 15.0f)
            {
                _flag = false;
                _controlTime = 0.0f;
                _time = 0.0f;
                EndOfTurn();
            }
        }
    }

    public void ResetBall()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _transform.position = _ballSpawn.position;
        _transform.rotation = _ballSpawn.rotation;
    }

    public void ParabolicLaunch()
    {
        var angle = Random.Range(30.0f, 50.0f);
        var force = Random.Range(3.0f, 5.0f);
        var direction = Quaternion.AngleAxis(angle, _transform.right) * _transform.forward;
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }

}
