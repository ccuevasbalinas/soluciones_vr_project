using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterTimeElapsed : MonoBehaviour
{

    [SerializeField] private float _time = 6.0f;
    private PoolManager _poolManager;
    
    private void Awake()
    {
        _poolManager = FindObjectOfType<PoolManager>();
    }

    private void OnEnable()
    {
        Invoke("Despawn", _time);
    }

    private void Despawn()
    {
        _poolManager.Despawn(gameObject);
    }

}
