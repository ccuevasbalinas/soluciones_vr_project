using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool _hasFalled;                // Boolean used for controlling if the bowl has fallen or not.
    public ScriptableEvent PinFallenEvent;  // Reference to a scriptable event when the pin's fallen.

    void Start()
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
            PinFallenEvent.Raise();
            if (!_hasFalled) { StartCoroutine(HitABowlCoroutine()); }
        }
            
    }

    // Coroutine that handles the trigger process of the player's ball when collides with a bowl.
    private IEnumerator HitABowlCoroutine()
    {
        // If so, increment the score and show it on the screen ...
        _hasFalled = true;
        AddScoreAndDisplayIt();
        yield return null;
    }

    // Function that incremnts the score and shows by using two digits.
    private void AddScoreAndDisplayIt()
    {
        BowlingGameManager.score++;
    }
}
