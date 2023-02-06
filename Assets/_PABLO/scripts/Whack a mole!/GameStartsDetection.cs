using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartsDetection : MonoBehaviour
{
    public ScriptableEvent onMoleGameStarts;        // Reference to a scriptable event when the game starts.

    // Funtion that handles when the player is in the game area to hit the mole. In this case, the timer is gonna 
    // start decreasing
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) onMoleGameStarts.Raise();
    }
}
