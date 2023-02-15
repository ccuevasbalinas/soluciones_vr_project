using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    #region Variables
    #region Variables · Public Variable
    public Vector3 endPosition;                  // The offset of the mole to show it. Its a vector according to the number of holes there is.
    #endregion

    #region Variables · Private Variables
    private Vector3 startPosition;               // The offset of the mole to hide it.           
    private float _minimumShowDuration = 0.5f;   // Minimum time it takes to show a mole.
    private float _maximumShowDuration = 1.0f;   // Maximum time it takes to show a mole.
    private float _minimumDuration = 0.5f;       // Minimum time the mole is being visible at the surface.
    private float _maximumDuration = 2.0f;       // Maximum time the mole is being visible at the surface.
    private bool _gameEnds;                     // Private boolean used for controlling if the game has finished.
    #endregion
    #endregion

    #region Methods
    void Start()
    {
        _gameEnds = false;
    }

    void OnEnable()
    {
        startPosition = endPosition - new Vector3(0.0f, 0.2f, 0.0f);
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    // Coroutine that handles the appearance/disappearance of a mole at the surface.
    private IEnumerator ShowHide(Vector3 start, Vector3 end)
    {
        while(!_gameEnds)
        {
            
            // Make sure we start at the start.
            transform.localPosition = start;

            // Show the mole.
            float elapsed = 0.0f;
            float showDuration = Random.Range(_minimumShowDuration, _maximumShowDuration);
            while (elapsed < showDuration)
            {
                transform.localPosition = Vector3.Lerp(start, end, elapsed/showDuration);
                // Update at max framerate.
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Make sure we're exactly at the end.
            transform.localPosition = end;

            if (_gameEnds) break;

            // Wait for duration to pass.
            yield return new WaitForSeconds(Random.Range(_minimumDuration, _maximumDuration));

            // Hide the mole.
            elapsed = 0.0f;
            showDuration = Random.Range(_minimumShowDuration, _maximumShowDuration);
            while (elapsed < showDuration)
            {
                transform.localPosition = Vector3.Lerp(end, start, elapsed/showDuration);
                // Update at max framerate.
                elapsed += Time.deltaTime;
                yield return null;
            }
        }   
    }

    // Function called by a scriptable event when the game has finished in order to stop the coroutine.
    public void GameEnds()
    {
        _gameEnds = true;
    }
    #endregion
}