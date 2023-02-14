using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalMovement : MonoBehaviour
{
    [SerializeField] Transform upLeft;
    [SerializeField] Transform upMid;
    [SerializeField] Transform upRight;
    [SerializeField] Transform midLeft;
    [SerializeField] Transform midMid;
    [SerializeField] Transform midRight;
    [SerializeField] Transform downLeft;
    [SerializeField] Transform downMid;
    [SerializeField] Transform downRight;
    private Transform[,] matrixBoard = new Transform[3, 3]; //matriz 3x3 tablero

    // Start is called before the first frame update
    void Start()
    {
        matrixBoard[0, 0] = upLeft;
        matrixBoard[0, 1] = upMid;
        matrixBoard[0, 2] = upRight;
        matrixBoard[1, 0] = midLeft;
        matrixBoard[1, 1] = midMid;
        matrixBoard[1, 2] = midRight;
        matrixBoard[2, 0] = downLeft;
        matrixBoard[2, 1] = downMid;
        matrixBoard[2, 2] = downRight;
    }

    // Update is called once per frame
    void Update()
    {
        if 
    }
}
