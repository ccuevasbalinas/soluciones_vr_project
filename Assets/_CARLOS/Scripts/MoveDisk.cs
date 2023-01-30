using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDisk : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _rigidbody.velocity = _transform.forward* _speed;
    }
}
