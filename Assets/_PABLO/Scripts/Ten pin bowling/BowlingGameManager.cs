using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class BowlingGameManager : MonoBehaviour
{
    public GameObject[] ballGameObjects;            // Array that contains all balls' game objects.
    public GameObject[] pinGameObjects;             // Array that contains all pins' game objects.
    public ScriptableEvent onPinResetPhysics;       // Reference to a scriptable event when the pin's been reset.
    public ScriptableEvent onStartNewRound;         // Reference to the scritable event that handless the process of starting a new round.
    public ScriptableEvent onPinsReset;             // Reference to the scritable event that reset the transform of the pins.
    public ScriptableEvent onBallsReset;            // Reference to the scritable event that reset the transform of the balls.
    public static int indexBallSelected = -1;        // Integer that contains the index of the ball that has been selected.
    public static int score = 0;                    // Amount of points scored by the player.
    public TMP_Text scoreCanvas;                    // Canvas' text where the score is displayed.
    public TMP_Text[] scoreRoundCanvas;             // Canvas' text where the score is displayed per round.
    public TMP_Text roundCanvas;                    // Canvas' text where the round is displayed.
    public TMP_Text maximumRoundsCanvas;            // Canvas' text where the maximum number of rounds is displayed.

    private List<Vector3> _ballOrginalPositions;      // List that contains the original positions of the ball in order to be reseted.
    private List<Vector3> _pinOrginalPositions;      // List that contains the original positions of the pins in order to be reseted.
    private float _tolerance = 0.3f;                 // Minimum magnitude value that will make that a new round starts.
    private int _scoreRound;                        // Private variable int that allocated the number of pins fallen in a round.

    void Awake()
    {
        maximumRoundsCanvas.text = RoundManager.maxRounds.ToString();
        RoundManager.round = 1;
        _ballOrginalPositions = new List<Vector3>();
        _pinOrginalPositions = new List<Vector3>();

        // Positions of the balls & pins must be collected in order to be reseted after a round.
        for (int i = 0; i < ballGameObjects.Length; i++) { _ballOrginalPositions.Add(ballGameObjects[i].transform.position); }
        for (int j = 0; j < pinGameObjects.Length; j++) { _pinOrginalPositions.Add(pinGameObjects[j].transform.position); }

        _scoreRound = 0;
    }


    void Update()
    {
        // While we have not surpassed the maximum number of rounds ...
        if (RoundManager.round <= RoundManager.maxRounds)
        { 
            scoreCanvas.text = score.ToString();
            scoreRoundCanvas[RoundManager.round - 1].text = _scoreRound.ToString();
            
            // ... update the round's canvas to the actual one.
            roundCanvas.text = RoundManager.round.ToString(); 

            // Constantly, we are checking if the ball selected has been thrown into the scenario.
            // From the BallDetection.cs, we obtain the index of the ball that has been thrown. Now we have to see
            // if is moving or not.
            if (indexBallSelected != -1)
            {
                // Just not to make the player to use two or more balls, desactivate the 'XRGrabInteractable' of the other
                // balls.
                for (int i = 0; i < ballGameObjects.Length; i++)
                {
                    if (i != (indexBallSelected - 1))
                        ballGameObjects[i].GetComponent<XRGrabInteractable>().enabled = false;
                }

                // And now, we can check if the ball is moving or not.
                CheckIfBallIsMoving(ballGameObjects[indexBallSelected - 1]);
            }  
        }
    }

    // Function that checks if the ball selected is not moving after being thrown into the scenario.
    private void CheckIfBallIsMoving(GameObject ballSelected)
    {
        // If the ball is not moving, that means two things: has reached the end of the scenario so must be reset
        // the balls and pins, or the speed was not enough so it is needed to be reset too again.
        if(ballSelected.GetComponent<Rigidbody>().velocity.magnitude < _tolerance) { onStartNewRound.Raise(); }
    }
    

    // Function that resets the balls and bouls to its original position for a new round.
    public void StartNewRound()
    {
        // Reset the balls every round.
        onBallsReset.Raise();

        // As the real bowling game, you have like per round onther oportunity to throw the ball and see if you
        // can make all pins fall. So, if we have 10 rounds, after the 2nd, 4th, 6th, 8th and 10th round, the pins are 
        // reset. The other posibility is that you have make a strike. So, in odd rounds all pins are reset too.
        if (RoundManager.round % 2 == 0 || _scoreRound == pinGameObjects.Length) { onPinsReset.Raise(); }

        // Because the round has finished, it must be incremented one.
        RoundManager.round++;
        indexBallSelected = -1;
        _scoreRound = 0;
    }

    // Function that reset the transform of the balls due to the start of a new round.
    public void BallsReset()
    {
        // For every ball, reset its position (rotation we do not care because they're balls.) and make it them grabable.
        for (int i = 0; i < ballGameObjects.Length; i++)
        {
            ballGameObjects[i].transform.position = _ballOrginalPositions[i]; 
            ballGameObjects[i].GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    // Function that reset the transform of the pins due to the start of a new round.
    public void PinsReset()
    {
        // For every pin, reset the position and rotation as well. Also  "freeze" the physics of the pins during the time the round is 
        // being reseting, just for controling they do not collide each other.
        for (int j = 0; j < pinGameObjects.Length; j++)
        {
            pinGameObjects[j].SetActive(false);
            pinGameObjects[j].GetComponent<Rigidbody>().isKinematic = true;
            pinGameObjects[j].transform.position = _pinOrginalPositions[j]; 
            pinGameObjects[j].transform.rotation = Quaternion.Euler(90, 0, 90);
        }

        // Once the pins has been placed correctly, let's give to them its phyisics, ny this scriptable event.
        onPinResetPhysics.Raise();
    }

    // Function that resets the physics of the pins due to the start of a new round.
    public void PinsResetPhysics()
    {
        for (int j = 0; j < pinGameObjects.Length; j++)
        {
            pinGameObjects[j].GetComponent<Rigidbody>().isKinematic = false;
            pinGameObjects[j].SetActive(true);
        } 
    }

    // Function that increments the score.
    public void UpdateScore()
    {
        score++;
        _scoreRound++;
    }
}
