using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPigeonShootingDisparator : MonoBehaviour
{
    
    [SerializeField] private GameObject  _prefab;

    private PoolManager _pool;
    private Transform _transform;

    private bool _shootFlag = false;

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
        _shootFlag = true;
        StartCoroutine(ShootDiskCoroutine());
    }

    public void StopDiskShootingCoroutine()
    {
        _shootFlag = false;
        StopCoroutine(ShootDiskCoroutine());
    }

    private void ShootDisk()
    {
        _pool.Spawn(_prefab, _transform.position, _prefab.transform.rotation);
    }

    private IEnumerator ShootDiskCoroutine()
    {
        while(_shootFlag == true)
        {
            var t = Random.Range(1.0f, 4.0f);
            yield return new WaitForSeconds(t);
            ShootDisk();
            if (_shootFlag == false)
            {
                break;
            }
        }
    }


}
