using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayPigeonShootingScore : MonoBehaviour
{
    private int _score = 0;

    public void IncrementScore()
    {
        _score = _score + 1;
    }

    public void ResetScore()
    {
        _score= 0;
    }

    public void ShowScore()
    {
        Debug.Log("Puntuación obtenida: " + _score);
    }
}
