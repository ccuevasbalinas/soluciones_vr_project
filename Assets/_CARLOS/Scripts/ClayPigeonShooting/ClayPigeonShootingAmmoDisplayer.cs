using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ClayPigeonShootingAmmoDisplayer : MonoBehaviour
{
    [SerializeField] private ClayPigeonShootingWeapon _weapon;
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        if (_weapon.Magazine == null)
        {
            _text.text = "0";
            return;
        }
        _text.text = _weapon.Magazine.remainingAmmo.ToString();
    }
}
