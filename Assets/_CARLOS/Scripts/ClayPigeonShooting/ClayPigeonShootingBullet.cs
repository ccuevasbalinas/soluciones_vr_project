using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPigeonShootingBullet: MonoBehaviour
{

    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _bulletForce = 5.0f;

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

    private void OnTriggerEnter(Collider other)
    {
        if (_targetLayer == (1 << other.gameObject.layer | _targetLayer))
        {
            _pool.Despawn(gameObject);
        }
    }

    private void OnEnable()
    {
        _rigidbody.AddForce(_transform.forward * _bulletForce, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
