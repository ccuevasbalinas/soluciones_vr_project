using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utad.XRInteractionUtad.Scripts;

public class ClayPigeonShootingWeapon : MonoBehaviour
{
    public IWeaponMagazine Magazine { get; private set; }

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnTranform;
    [SerializeField] private AudioSource _audioSource;

    private PoolManager _pool;

    public void LoadMagazine(IWeaponMagazine mag)
    {
        Magazine = mag;
        Debug.Log($"{Magazine.magazineType.name} loaded on {name} with {Magazine.remainingAmmo} rounds");
    }

    private void Start()
    {
        _pool = FindObjectOfType<PoolManager>();
        _pool.Load(_bulletPrefab, 10);
    }

    public void UnloadMagazine()
    {
        Magazine = null;
    }

    public void Shoot()
    {
        if (Magazine == null)
        {
            Debug.Log("I need a magazine");
            return;
        }
        if (Magazine.UseAmmo())
        {
            _pool.Spawn(_bulletPrefab, _bulletSpawnTranform.position, _bulletSpawnTranform.rotation);
            _audioSource.Play();
            Debug.Log("FIRE");
        }
        else
        {
            Debug.Log("Out of ammo");
        }
    }
}
