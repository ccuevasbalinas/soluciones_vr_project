using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        // It is needed to check if the triggerer object is the ball used for bowling. Also other type of collision
        // can be between bowls.
        if (collision.gameObject.CompareTag("BallBowling"))
            StartCoroutine(HitABowlCoroutine());
         
    }

    // Coroutine that handles the trigger process of the player's ball when collides with a bowl.
    private IEnumerator HitABowlCoroutine()
    {
        // If so, increment the score and show it on the screen ...
        AddScoreAndDisplayIt();
        yield return null;
    }

    // Function that incremnts the score and shows by using two digits.
    private void AddScoreAndDisplayIt()
    {
        BowlingGameManager.score++;
        Debug.Log("Score: " + BowlingGameManager.score);
    }
}
