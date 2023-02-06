using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponMagazine : MonoBehaviour, IWeaponMagazine
{
    [field: SerializeField] public WeaponMagazineObject magazineType { get; private set; }
    [field: SerializeField] public UnityEvent OnMagazineEmpty { get; private set; }
    public int remainingAmmo { get; private set; }

    private void Awake()
    {
        remainingAmmo = magazineType.ammo;
    }

    public bool UseAmmo()
    {
        if(remainingAmmo <= 0)
        {
            return false;
        }
        remainingAmmo = remainingAmmo - 1;
        Debug.Log($"Ammo used, {remainingAmmo} remaining");
        if(remainingAmmo <= 0)
        {
            OnMagazineEmpty.Invoke();
        }
        return true;
    }
}
