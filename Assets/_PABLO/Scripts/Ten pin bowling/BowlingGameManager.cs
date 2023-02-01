using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class BowlingGameManager : MonoBehaviour
{
    public GameObject[] ballGameObjects;            // Array that contains all balls' game objects.
    public GameObject[] pinGameObjects;             // Array that contains all pins' game objects.
    public static int indexBallSelected = -1;        // Integer that contains the index of the ball that has been selected.
    public static int score = 0;                    // Amount of points scored by the player.
    public TMP_Text scoreCanvas;                    // Canvas' text where the score is displayed.
    public TMP_Text roundCanvas;                    // Canvas' text where the round is displayed.
    private List<Vector3> ballOrginalPositions;      // List that contains the original positions of the ball in order to be reseted.
    private List<Vector3> pinOrginalPositions;      // List that contains the original positions of the pins in order to be reseted.

    void Awake()
    {
        RoundManager.round = 1;
        ballOrginalPositions = new List<Vector3>();
        pinOrginalPositions = new List<Vector3>();

        // Positions of the balls & pins must be collected in order to be reseted after a round.
        for (int i = 0; i < ballGameObjects.Length; i++) { ballOrginalPositions.Add(ballGameObjects[i].transform.position); }
        for (int j = 0; j < pinGameObjects.Length; j++) { pinOrginalPositions.Add(pinGameObjects[j].transform.position); }

    }


    // Update is called once per frame.
    void Update()
    {
        scoreCanvas.text = score.ToString();
        roundCanvas.text = RoundManager.round.ToString();
        // Constantly, we are checking if the ball selected has been thrown into the scenario.
        // From the BallDetection.cs, we obtain the index of the ball that has been thrown. Now we have to see
        // if is moving or not.
        if (RoundManager.round <= 3 && indexBallSelected != -1) {CheckIfBallHasBeenThrown(ballGameObjects[indexBallSelected - 1]);}
            
    }

    // Function that checks if the ball selected is not moving after being thrown into the scenario.
    private void CheckIfBallHasBeenThrown(GameObject ballSelected)
    {
        // If the ball is not moving, that means two things: has reached the end of the scenario so must be reset
        // the balls and pins, or the speed was not enough so it is needed to be reset too again.
        if(ballSelected.GetComponent<Rigidbody>().velocity.magnitude < 0.1f) { ResetBallsAndPins(); }
    }
    

    // Function that resets the balls and bouls to its original position.
    private void ResetBallsAndPins()
    {
        // For every ball, reset its position (rotation we do not care because they're balls.)
        for (int i = 0; i < ballGameObjects.Length; i++)
            ballGameObjects[i].transform.position = ballOrginalPositions[i]; 

        // For every pin, reset the position and rotation as well.
        for (int j = 0; j < pinGameObjects.Length; j++)
        {
            pinGameObjects[j].transform.position = pinOrginalPositions[j]; 
            pinGameObjects[j].transform.rotation = Quaternion.Euler(90, 0, 90);
        }

        // Because the round has finished, it must be incremented one.
        if (RoundManager.round < 3) { RoundManager.round++; }
        indexBallSelected = -1;
    }
}
