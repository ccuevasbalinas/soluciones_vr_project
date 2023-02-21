using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DigitalClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        _text.text = DateTime.Now.ToString("HH:mm");
    }
}
