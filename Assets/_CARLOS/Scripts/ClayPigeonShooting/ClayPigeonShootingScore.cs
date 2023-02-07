using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClayPigeonShootingScore : MonoBehaviour
{
    private int _score = 0;

    [SerializeField] private TextMeshProUGUI _scoreText;

    public void IncrementScore()
    {
        _score = _score + 1;
    }

    public void ResetScore()
    {
        _score= 0;
    }

    public void UpdateCanvas()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }

    public void ShowScore()
    {
        Debug.Log("Puntuación obtenida: " + _score);
    }
}
