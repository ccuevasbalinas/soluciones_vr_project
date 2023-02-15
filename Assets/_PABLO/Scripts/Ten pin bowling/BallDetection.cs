using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection : MonoBehaviour
{
    #region Method
    /* Funtion that handles when the ball's selected has been thrown. How? By a invisible wall. If the ball triggers
    this wall, it means that has been thrown. */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallBowling"))
        {
            string[] parts = other.gameObject.name.Split(' ');
            BowlingGameManager.indexBallSelected = int.Parse(parts[2]);
        }
    }
    #endregion
}
