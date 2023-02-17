using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlCarCoin : MonoBehaviour
{
    private Transform _transform;
    private float _rotationSpeed;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rotationSpeed = Random.Range(30.0f, 50.0f);
    }

    private void Update()
    {
        _transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
    }

}
