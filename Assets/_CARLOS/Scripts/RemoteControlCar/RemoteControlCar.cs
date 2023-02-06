using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlCar : MonoBehaviour
{
    
    [SerializeField] private LayerMask _coinLayer;
    [SerializeField] private LayerMask _startLineLayer;
    [SerializeField] private LayerMask _finishLineLayer;

    [SerializeField] private ScriptableEvent _startRaceTimeEvent;
    [SerializeField] private ScriptableEvent _endRaceTimeEvent;
    [SerializeField] private ScriptableEvent _getCoinEvent;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private float _speed = 0.0f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void UpdateDirection(float angle)
    {
        //var vRotation = new Vector3(0.0f, angle, 0.0f);
        //_transform.rotation = Quaternion.Euler(vRotation);
        _transform.Rotate(0.0f, angle, 0.0f, Space.Self);
    }

    public void UpdateSpeed(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        _rigidbody.velocity = _transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_coinLayer == (1 << other.gameObject.layer | _coinLayer))
        {
            other.gameObject.SetActive(false);
            _getCoinEvent.Raise();
            Debug.Log("Coge moneda");
        }
        if (_startLineLayer == (1 << other.gameObject.layer | _startLineLayer))
        {
            _startRaceTimeEvent.Raise();
            Debug.Log("Empieza circuito");
        }
        if (_finishLineLayer == (1 << other.gameObject.layer | _finishLineLayer))
        {
            _endRaceTimeEvent.Raise();
            Debug.Log("Acaba circuito");
        }
    }
}
