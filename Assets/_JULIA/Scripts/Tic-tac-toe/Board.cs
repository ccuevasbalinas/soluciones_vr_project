using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] Collider upLeft;
    [SerializeField] Collider upMid;
    [SerializeField] Collider upRight;
    [SerializeField] Collider midLeft;
    [SerializeField] Collider midMid;
    [SerializeField] Collider midRight;
    [SerializeField] Collider downLeft;
    [SerializeField] Collider downMid;
    [SerializeField] Collider downRight;

    //[SerializeField] Transform cross1;
    //[SerializeField] Transform cross2;
    //[SerializeField] Transform cross3;
    //[SerializeField] Transform circle1;
    //[SerializeField] Transform circle2;
    //[SerializeField] Transform circle3;
    //private bool isFull = false;
    //private bool isRed = false;

    private Vector3[,] matrixBoard = new Vector3[3, 3]; //matriz 3x3 tablero
    [SerializeField] List<GameObject> pieces;
    private GameObject currentBoardLocation; //cubo del tablero actual
    private Collider pieceCollider;
    private bool cross;

    //[SerializeField] Collider _collider;
    private void Start()
    {
        //Guarda la posicion de los colliders en una matriz como si fuese un tablero
        matrixBoard[0, 0] = upLeft.transform.position;
        matrixBoard[0, 1] = upMid.transform.position;
        matrixBoard[0, 2] = upRight.transform.position;
        matrixBoard[1, 0] = midLeft.transform.position;
        matrixBoard[1, 1] = midMid.transform.position;
        matrixBoard[1, 2] = midRight.transform.position;
        matrixBoard[2, 0] = downLeft.transform.position;
        matrixBoard[2, 1] = downMid.transform.position;
        matrixBoard[2, 2] = downRight.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                currentBoardLocation = this.gameObject;
                foreach (GameObject go in pieces)
                {
                    if (go.transform.position == currentBoardLocation.transform.position)
                    {
                        Debug.Log("Found a matching position!");
                        pieceCollider = go.GetComponent<Collider>();
                        OnTriggerEnter(pieceCollider);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //comprueba la etiqueta que tiene el collider que entra dentro
        if (other.CompareTag("X"))
        {
            Debug.Log("Cruz");
            cross = true;
        }
        if(other.CompareTag("O"))
        {
            Debug.Log("Circulo");
            cross = false;
        }
    }
}
