using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
    private bool[] position = new bool[9];

    [SerializeField] private TicTacToeGameManager gameManager;
    private bool turnoEnemigo = false;
    private int enemyIndex;
    [SerializeField] private GameObject enemyPiece;
    private List<Vector3> positionsList = new List<Vector3>();

    public ScriptableEvent onEnemyTurn;
    private bool checkingPiece = false;
    private int numPiecesPlaced = 0;
    private bool gameFinished = false;

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

        for(int i = 0; i<9; i++)
        {
            position[i] = false;
        }

        positionsList.Add(upLeft.transform.position);
        positionsList.Add(upMid.transform.position);
        positionsList.Add(upRight.transform.position);
        positionsList.Add(midLeft.transform.position);
        positionsList.Add(midMid.transform.position);
        positionsList.Add(midRight.transform.position);
        positionsList.Add(downLeft.transform.position);
        positionsList.Add(downMid.transform.position);
        positionsList.Add(downRight.transform.position);
    }





    // Update is called once per frame
    void Update()
    {
        if (!gameFinished)
        {
            if (numPiecesPlaced < 6)
            {
                foreach (GameObject go in pieces)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            currentBoardLocation = matrixBoard[i, j];
                            //si los limites del collider contienen la posicion de la pieza
                            if (currentBoardLocation.bounds.Contains(go.transform.position) && position[Int16.Parse(currentBoardLocation.name) - 1] == false)
                            {
                                pieceCollider = go.GetComponent<Collider>();
                                OnTriggerEnter(pieceCollider);
                                tagRow[i] = pieceCollider.tag;
                                tagCol[j] = pieceCollider.tag;
                                tagDia[i, j] = pieceCollider.tag;

                                if (!turnoEnemigo) positionCheck(Int16.Parse(currentBoardLocation.name));
                                turnoEnemigo = true;
                                numPiecesPlaced++;
                                currentBoardLocation.enabled = false;

                                go.GetComponent<XRGrabInteractable>().enabled = false;
                                go.transform.position = currentBoardLocation.transform.position;
                            }
                        }
                    }
                }

                if (turnoEnemigo)
                {
                    enemyIndex = UnityEngine.Random.Range(0, 8);

                    if (position[enemyIndex] == false)
                    {
                        Debug.Log("Enemigo: " + enemyIndex);
                        Instantiate(enemyPiece);
                        enemyPiece.transform.position = positionsList[enemyIndex];
                        position[enemyIndex] = true;
                        turnoEnemigo = false;
                        numPiecesPlaced++;
                    }
                }
            }

            if (numPiecesPlaced == 6)
            {
                gameFinished = true;
                //CONDICIONES PARA GANAR LA PARTIDA
                if ((tagRow[0] == "X" && tagRow[1] == "X" && tagRow[2] == "X") ||
                (tagCol[0] == "X" && tagCol[1] == "X" && tagCol[2] == "X") ||
                (tagDia[0, 0] == "X" && tagDia[1, 1] == "X" && tagDia[2, 2] == "X") ||
                (tagDia[0, 2] == "X" && tagDia[1, 1] == "X" && tagDia[2, 0] == "X"))
                {
                    Debug.Log("x win");
                    xWin.SetActive(true);
                    TicTacToeGameManager.Xcounter += 1;
                    TicTacToeGameManager.Xtext.text = string.Format("{0:0}", TicTacToeGameManager.Xcounter);
                }
                else if ((tagRow[0] == "O" && tagRow[1] == "O" && tagRow[2] == "O") ||
                    (tagCol[0] == "O" && tagCol[1] == "O" && tagCol[2] == "O") ||
                    (tagDia[0, 0] == "O" && tagDia[1, 1] == "O" && tagDia[2, 2] == "O") ||
                    (tagDia[0, 2] == "O" && tagDia[1, 1] == "O" && tagDia[2, 0] == "O"))
                {
                    Debug.Log("o win");
                    oWin.SetActive(true);
                    TicTacToeGameManager.Ocounter += 1;
                    TicTacToeGameManager.Otext.text = string.Format("{0:0}", TicTacToeGameManager.Ocounter);
                }
                else
                {
                    Debug.Log("nobody wins");
                }

                gameManager.TeleportToMainscene();
            }
        }
    }

    private void positionCheck(int posCurrentBoardLocation)
    {
        position[posCurrentBoardLocation - 1] =  true;
        Debug.Log("Current board location = " + (posCurrentBoardLocation - 1));
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //comprueba la etiqueta que tiene el collider que entra dentro
        if (other.CompareTag("X"))
        {
            //Debug.Log("Cruz");
        }
        if (other.CompareTag("O"))
        {
            //Debug.Log("Circulo");

        }
    }


}
