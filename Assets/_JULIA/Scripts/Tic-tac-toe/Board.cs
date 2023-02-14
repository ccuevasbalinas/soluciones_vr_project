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
    [SerializeField] GameObject xWin;
    [SerializeField] GameObject oWin;
    private Collider[,] matrixBoard = new Collider[3, 3]; //matriz 3x3 tablero
    [SerializeField] List<GameObject> pieces; //lista de piezas
    private Collider currentBoardLocation; //collider del cubo del tablero actual
    private Collider pieceCollider;
    private string [] tagRow = new string [3]; //vector de string que almacena tag de la fila
    private string[] tagCol = new string[3]; //vector de string que almacena tag de la columna
    private string[,] tagDia = new string[3,3]; //matriz 3x3 que almacena tag de la diagonal
    private Vector3 piecePosition;

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
                        tagRow[i] = pieceCollider.tag;
                        tagCol[j] = pieceCollider.tag;
                        tagDia[i,j] = pieceCollider.tag;
                    }
                }
            }
        }

        //CONDICIONES PARA GANAR LA PARTIDA
        //si la fila tiene la misma pieza
        if (tagRow[0] == "X" && tagRow[1] == "X" && tagRow[2] == "X")
        {
            Debug.Log("Gana fila de X");
            xWin.SetActive(true);
        }

        if (tagRow[0] == "O" && tagRow[1] == "O" && tagRow[2] == "O")
        {
            Debug.Log("Gana fila de O");
            oWin.SetActive(true);
        }
        //si la columna tiene la misma pieza
        if (tagCol[0] == "X" && tagCol[1] == "X" && tagCol[2] == "X")
        {
            Debug.Log("Gana columna de X");
            xWin.SetActive(true);
        }
        if (tagCol[0] == "O" && tagCol[1] == "O" && tagCol[2] == "O")
        {
            Debug.Log("Gana columna de O");
            oWin.SetActive(true);
        }
        //si la diagonal tiene la misma pieza 
        if (tagDia[0,0] == "X" && tagDia[1, 1] == "X" && tagDia[2, 2] == "X")
        {
            Debug.Log("Gana diagonal de X");
            xWin.SetActive(true);
        }
        if (tagDia[0, 0] == "O" && tagDia[1, 1] == "O" && tagDia[2, 2] == "O")
        {
            Debug.Log("Gana diagonal de O");
            oWin.SetActive(true);
        }
        if (tagDia[0, 2] == "X" && tagDia[1, 1] == "X" && tagDia[2, 0] == "X")
        {
            Debug.Log("Gana diagonal de X");
            xWin.SetActive(true);
        }
        if (tagDia[0, 2] == "O" && tagDia[1, 1] == "O" && tagDia[2, 0] == "O")
        {
            Debug.Log("Gana diagonal de O");
            oWin.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //comprueba la etiqueta que tiene el collider que entra dentro
        if (other.CompareTag("X"))
        {
            Debug.Log("Cruz");
            piecePosition = other.transform.position;
            
        }
        if(other.CompareTag("O"))
        {
            Debug.Log("Circulo");
            
        }
    }
}
