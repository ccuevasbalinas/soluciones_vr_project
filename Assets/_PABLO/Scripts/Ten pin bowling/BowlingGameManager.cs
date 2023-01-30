using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class BowlingGameManager : MonoBehaviour
{
    public GameObject[] ballGameObjects;            // Array that contains all balls' game objects.
    public static int score = 0;                    // Amount of points scored by the player.
    public TMP_Text scoreCanvas;                    // Canvas' text where the score is displayed.
    public TMP_Text roundCanvas;                    // Canvas' text where the round is displayed.
    private int _round;                             // Number of the round of the game.
    private bool _hasFinished;                      // Variable that controls if the game is running or not.
    private List<Transform> ballOrginalTransforms;  // List that contains the original transforms of the ball in order to be reseted.

    void Awake()
    {
        ballOrginalTransforms = new List<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _round = 1;
        _hasFinished = false;

        // Positions of the ball & bowls must be collected in order to be reseted after a round.
        for (int i = 0; i < ballGameObjects.Length; i++) { ballOrginalTransforms.Add(ballGameObjects[i].transform); }
    }

    // Update is called once per frame.
    void Update()
    {
        scoreCanvas.text = score.ToString();
        roundCanvas.text = _round.ToString();

        // Constantly, we are checking the ball selected.
        CheckBallSelected();



    }

    // Function that checks which ball has been selected
    private void CheckBallSelected()
    {
        // First we need to see which of the balls has been selected. Is the ball moving or not?
        GameObject ballSelected = new GameObject();
        for (int i = 0; i < ballGameObjects.Length; i++)
            if (ballGameObjects[i].GetComponent<XRGrabInteractable>().isSelected) { CheckIfBallHasBeenThrown(ballGameObjects[i]); }
    }

    // Function that checks if the ball selected is not moving after being thrown into the scenario.
    private void CheckIfBallHasBeenThrown(GameObject ballSelected)
    {
        // First, we need to
        Debug.Log(ballSelected.GetComponent<Rigidbody>().velocity);
    }

    // Function that resets the balls and bouls to its original position.
    private void BallsAndBowls()
    {
        // For every ball, reset its position (rotation we do not care because they're balls.)
        int i = 0;
        foreach (Transform ballOriginalTransform in ballOrginalTransforms)
        {
            ballGameObjects[i].transform.position = ballOriginalTransform.position; 
            i++;
        }
        
    }
}
