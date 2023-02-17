using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPigeonShootingDisparator : MonoBehaviour
{
    
    [SerializeField] private GameObject  _prefab;

    private PoolManager _pool;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _pool = FindObjectOfType<PoolManager>();
        _pool.Load(_prefab,5);
    }

    public void StartDiskShootingCoroutine()
    {
        StartCoroutine(ShootDiskCoroutine());
    }

    public void StopDiskShootingCoroutine()
    {
        StopCoroutine(ShootDiskCoroutine());
    }

    private void ShootDisk()
    {
        _pool.Spawn(_prefab, _transform.position, _prefab.transform.rotation);
    }

    private IEnumerator ShootDiskCoroutine()
    {
        while(true)
        {
            var t = Random.Range(1.0f, 4.0f);
            yield return new WaitForSeconds(t);
            ShootDisk();
        }
    }


}
