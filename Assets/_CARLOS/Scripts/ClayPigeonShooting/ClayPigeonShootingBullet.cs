using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClayPigeonShootingBullet: MonoBehaviour
{

    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _bulletForce = 10.0f;

    private PoolManager _pool;
    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _pool = FindObjectOfType<PoolManager>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.AddForce(_transform.forward * _bulletForce, ForceMode.Impulse);
        Invoke("DespawnBullet", 15);
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void DespawnBullet()
    {
        _pool.Despawn(gameObject);
    }
}
