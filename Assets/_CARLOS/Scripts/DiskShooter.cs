using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskShooter : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private float _minRotationAngle = -20.0f;
    [SerializeField] private float _maxRotationAngle = -60.0f;
    [SerializeField] private int _numberOfDisks = 10;
    [SerializeField] private Transform _diskShoterTransform;
    [SerializeField] private GameObject _diskPrefab;

    private PoolManager _poolManager;
    private Transform _transform;
    private int _disks;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _poolManager = FindObjectOfType<PoolManager>();
        _disks = _numberOfDisks;
        _poolManager.Load(_diskPrefab, 10);
    }

    public void ClayPigeonShot()
    {
        while(_numberOfDisks > 0)
        {
            StartCoroutine(WaitTimeCoroutine(3.0f));
            RotateCanyon();
            //StartCoroutine(WaitTimeCoroutine(2.0f));
            //ShotDisk();
            //StartCoroutine(WaitTimeCoroutine(1.0f));
        }
    }

    public void ShotDisk()
    {
        _poolManager.Spawn(_diskPrefab,_diskShoterTransform.position,_diskShoterTransform.rotation);
        _numberOfDisks = _numberOfDisks - 1;
    }

    public void RotateCanyon()
    {
        Debug.Log("Entra en rotate canyon");
        var angle = GetRandomRotationAngle();
        SmoothRotationX(angle);
    }

    private float GetRandomRotationAngle()
    {
        Debug.Log("Entra en random angle");
        var randomAngle = Random.Range(_minRotationAngle, _maxRotationAngle);
        return randomAngle;
    }

    private void SmoothRotationX(float angle)
    {
        Debug.Log("Entra en smootRotation x");
        //_transform.Rotate(Vector3.right * angle * _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator WaitTimeCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public void ResetCanyon()
    {
        _numberOfDisks = _disks;
    }

}
