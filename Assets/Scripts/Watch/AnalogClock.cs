using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    [SerializeField] private Transform _hourHand;
    [SerializeField] private Transform _minuteHand;
    [SerializeField] private Transform _secondHand;


    void Update()
    {
        var currentTime = System.DateTime.Now;
        float hour = currentTime.Hour;
        float minute = currentTime.Minute;
        float second = currentTime.Second;

        _hourHand.localRotation = Quaternion.Euler(0, 0, hour/12*360);
        _minuteHand.localRotation = Quaternion.Euler(0, 0, minute/60*360);
        _secondHand.localRotation = Quaternion.Euler(0,0, second/60*360);
    }
}
