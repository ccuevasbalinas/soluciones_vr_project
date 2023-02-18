using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    #region Variables
    #region Variables · Public Variables
    public static int round = 0;                    // Number of the round of the game.
    public static int maxRounds = 10;               // Number of maximum round of the game.
    public ScriptableEvent onTimeIsUp;              // Reference to a scriptable event when time's up.
    #endregion 

    #region Variables · Private Variables
    private bool _hasFinished;                      // Boolean used for controlling if a game has finished.
    [SerializeField] private string _sceneToTeleport; // String that allocates te name of the main scene in order to be teleported.   
    #endregion
    #endregion

    #region Methods
    void Start()
    {
        _hasFinished = false;
    }

    void Update()
    {
        // Constantly we're studying if the game has finished or not.
        if (round > maxRounds && !_hasFinished) { GameFinshed();}
    }

    // Function used to manage the end of the game.
    private void GameFinshed()
    {
        // If all rounds has completed, the game has finished and we come back to the main scene.
        _hasFinished = true;
        Debug.Log("fin");
        onTimeIsUp.Raise();
    }

    // Function that finish the game by calling a coroutine that adds 5 extra seconds between the finishing of the
    // game and the teleporting process to the main scene
    public void GameEnds()
    {
        StartCoroutine(GameEndsCoroutine());
    }

    // Coroutine created for adding five seconds after finishing the game to teleport to the main scene.
    private IEnumerator GameEndsCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(_sceneToTeleport);
    }
    #endregion
}