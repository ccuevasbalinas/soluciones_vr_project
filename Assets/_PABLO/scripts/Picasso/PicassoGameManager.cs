using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.SceneManagement;

public class PicassoGameManager : MonoBehaviour
{
    public static int idPiecePlacedCorrectly = 0;   // Last piece' id placed correctly.
    public static List<int> idPiecesPlaced;         // List that allocates the pieces that has been placed.
    public TMP_Text piecesPlacedCorrectlyCanvas;    // Canvas' text that shows the number of pieces placed correctly.
    public TMP_Text totalPiecesCanvas;              // Canvas' text that shows the total number of pieces to place.
    public GameObject[] piecesGameObject;            // Array that contains all pieces of the puzzle.
    public GameObject[] socketPiecesGameObject;      // Array that contains all sockets' pieces of the puzzle.
    public ScriptableEvent onTimeIsUp;               // Reference to a scriptable event when time's up.

    private int piecesPlacedCorrectly = 0;          // Counter of the number of pieces placed correctly.
    [SerializeField] private string _sceneToTeleport; // String that allocates te name of the main scene in order to be teleported.    


    void Start()
    {
        idPiecesPlaced = new List<int>();
        totalPiecesCanvas.text = piecesGameObject.Length.ToString();
    }


    // Function that put the correct piece of the puzzle in the canvas.
    public void UpdateCanvas()
    {
        // Increment the number of pieces placed correctly.
        piecesPlacedCorrectly++;
        piecesPlacedCorrectlyCanvas.text = piecesPlacedCorrectly.ToString();

        // This piece is now on the list of pieces placed.
        idPiecesPlaced.Add(idPiecePlacedCorrectly);

        // Disability the game object in order not to be grabbed anymore.
        // (note: idPiecePlacedCorrectly goes from 1 to N. But the array must go from 0 to N-1).
        FixPieceOnCanvas();

        // In case all the pieces from the canvas has been put on there, the game has finished:
        if (piecesPlacedCorrectly == piecesGameObject.Length) AllPiecesPlaced();
    }


    private void FixPieceOnCanvas()
    {
        piecesGameObject[idPiecePlacedCorrectly - 1].SetActive(false);
        socketPiecesGameObject[idPiecePlacedCorrectly - 1].GetComponent<MeshRenderer>().enabled = true;
        socketPiecesGameObject[idPiecePlacedCorrectly - 1].GetComponent<XRSocketInteractor>().enabled = false;
    }


    // Function that, in case the cancas has been completed, finish the game, show you the time used for doing it teleport to the 
    // main scene.
    public void AllPiecesPlaced()
    {
        onTimeIsUp.Raise();
    }

    // Function that finish the game by calling a coroutine that adds 5 extra seconds between the finishing of the
    // game and the teleporting process to the main scene.
    public void GameEnds()
    {
        StartCoroutine(GameEndsCoroutine());
    }

    private IEnumerator GameEndsCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(_sceneToTeleport);
    }
}