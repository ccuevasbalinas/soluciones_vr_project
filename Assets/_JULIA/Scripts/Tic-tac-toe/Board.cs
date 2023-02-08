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
    private Collider[,] matrixBoard = new Collider[3, 3]; //matriz 3x3 tablero
    [SerializeField] List<GameObject> pieces; //lista de piezas
    private Collider currentBoardLocation; //collider del cubo del tablero actual
    private Collider pieceCollider;
    private bool cross = false;
    private bool circle = false;

    private void Start()
    {
        
        //Guarda los colliders en una matriz como si fuese un tablero
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
        foreach (GameObject go in pieces)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    currentBoardLocation = matrixBoard[i, j]; 
                    //si los limites del collider contienen la posicion de la pieza
                    if (currentBoardLocation.bounds.Contains(go.transform.position))
                    {
                        pieceCollider = go.GetComponent<Collider>();
                        OnTriggerEnter(pieceCollider);

                        //si la fila tiene la misma pieza linea
                        //si la columna tiene la misma pieza linea
                        //si la diagonal tiene la misma pieza linea
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
            circle = true;
        }
    }
}
