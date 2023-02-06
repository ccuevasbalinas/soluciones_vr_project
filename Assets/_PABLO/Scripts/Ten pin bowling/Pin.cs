using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public ScriptableEvent onPinFallen;     // Reference to a scriptable event when the pin's fallen.
    public ScriptableEvent onUpdateScore;   // Reference to a scriptable event when the pin's fallen and the score must be incremented.
    private bool _hasFalled;                // Boolean used for controlling if the bowl has fallen or not.


    void Start()
    {
        _hasFalled = false;
    }

    void OnEnable()
    {
        _hasFalled = false;
    }

    // Function that handles the colision between the ball and the bowl.
    void OnCollisionEnter(Collision collision)
    {
        // It is needed to check if the triggerer object is the ball used for bowling. Also other type of collision
        // can be between pins.
        if (collision.gameObject.CompareTag("BallBowling") || collision.gameObject.CompareTag("Pin"))
        {
            // Raise the scriptable event of falling a pin for the sound because of it..
            onPinFallen.Raise();

            // And increment the score by raising another scriptable event.
            if (!_hasFalled)
            { 
                onUpdateScore.Raise(); 
                _hasFalled = true;
            }
        }     
    }


}