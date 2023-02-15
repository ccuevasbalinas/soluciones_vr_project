using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponMagazineObject", menuName = "New Weapon Magazine Object", order = 0)]
public class WeaponMagazineObject : ScriptableObject
{
    [field: SerializeField] public string name { get; private set; }
    [field: SerializeField] public int ammo { get; private set; }
}
