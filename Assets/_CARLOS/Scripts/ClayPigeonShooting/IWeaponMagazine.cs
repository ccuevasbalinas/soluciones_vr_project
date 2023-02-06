using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IWeaponMagazine 
{
    WeaponMagazineObject magazineType { get; }
    int remainingAmmo { get; }
    bool UseAmmo();
    UnityEvent OnMagazineEmpty { get; }
}
