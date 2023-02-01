using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static int round = 0;                  // Number of the round of the game.
    private bool _hasFinished;                      // Boolean used for controlling if a game has finished.
    public ScriptableEvent timerEvent;              // Reference to a scriptable event when time's up.
    
    // Function that controls if the game has finished or not.

    void Update()
    {
        // Constantly we're studying if the game has finished or not.
        if (round > 3 && !_hasFinished) { GameFinshed();}
    }

    // Function used to manage the end of the game.
    private void GameFinshed()
    {
        // If all rounds has completed, the game has finished.
        _hasFinished = true;
        Debug.Log("fin");
        timerEvent.Raise();
        // todo: change to main scene.
    }
}
