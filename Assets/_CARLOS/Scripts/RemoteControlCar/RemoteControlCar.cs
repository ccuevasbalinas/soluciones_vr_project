using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlCar : MonoBehaviour
{
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private LayerMask _coinLayer;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void UpdateForward(Transform t)
    {
        _transform.forward = t.forward;
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
            // Increment score 
        }
    }
}
