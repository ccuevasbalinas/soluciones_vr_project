using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAnimation : MonoBehaviour
{
    private float orientation = 11.0f;            // Orentation of the letters during the animation.
    private float _showDuration = 2.5f;           // How long it takes to show the duration.
    private float _duration = 0.25f;              // How long the animation must last.

    void Start()
    {
        Vector3 actualRotation = transform.eulerAngles;
        Quaternion startRotationQ = Quaternion.Euler(actualRotation.x, (actualRotation.y + orientation), actualRotation.z);
        Quaternion endRotationQ = Quaternion.Euler(actualRotation.x, (actualRotation.y - orientation), actualRotation.z);
        StartCoroutine(MakeLetterAnimation(startRotationQ, endRotationQ));
    }


    // Coroutine that handles the animation of the letters "as a canvas".
    private IEnumerator MakeLetterAnimation(Quaternion start, Quaternion end)
    {
        while(true)
        {
            // Make sure we start at the start.
            transform.rotation = start;

            // Show the mole.
            float elapsed = 0.0f;
            while (elapsed < _showDuration)
            {
                transform.rotation = Quaternion.Slerp(start, end, elapsed/_showDuration);
                // Update at max framerate.
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Make sure we're exactly at the end.
            transform.rotation = end;

            // Wait for duration to pass.
            yield return new WaitForSeconds(_duration);

            // Hide the mole.
            elapsed = 0.0f;
            while (elapsed < _showDuration)
            {
                transform.rotation = Quaternion.Slerp(end, start, elapsed/_showDuration);
                // Update at max framerate.
                elapsed += Time.deltaTime;
                yield return null;
            }
        }   
    }
}
