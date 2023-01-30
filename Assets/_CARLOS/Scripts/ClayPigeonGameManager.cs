using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPigeonGameManager : MonoBehaviour
{
    public DiskShooter _diskShooter;

    private void Awake()
    {
        _diskShooter.ClayPigeonShot();
    }
}
