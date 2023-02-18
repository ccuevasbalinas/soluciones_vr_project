using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPigeonShootingDisk : MonoBehaviour
{

    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private LayerMask _despawnLayer;
    [SerializeField] private LayerMask _bulletLayer;
    [SerializeField] private ScriptableEvent BulletDestroyDiskEvent;

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
        _rigidbody.velocity= Vector3.zero;
        _rigidbody.angularVelocity= Vector3.zero;
        _rigidbody.AddForce(_transform.forward * _speed,ForceMode.Impulse);
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_despawnLayer == (1 << other.gameObject.layer | _despawnLayer))
        {
            _pool.Despawn(gameObject);
        }
        if (_bulletLayer == (1 << other.gameObject.layer | _bulletLayer))
        {
            BulletDestroyDiskEvent.Raise();
            _pool.Despawn(gameObject);
            _pool.Despawn(other.gameObject);
        }
    }
}
