using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    public GameObject[] spaces = new GameObject[9];
    private int[] board = new int[9];
    private int currentPlayer = 1;

    private void Update()
    {
        int winner = GetWinner();
        if (winner == 1)
        {
            Debug.Log("Player 1 wins!");
        }
        else if (winner == 2)
        {
            Debug.Log("Player 2 wins!");
        }
    }

    private int GetWinner()
    {
        // Check rows
        for (int i = 0; i < 9; i += 3)
        {
            if (board[i] == board[i + 1] && board[i + 1] == board[i + 2] && board[i] != 0)
            {
                return board[i];
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] && board[i] != 0)
            {
                return board[i];
            }
        }

        // Check diagonals
        if (board[0] == board[4] && board[4] == board[8] && board[0] != 0)
        {
            return board[0];
        }
        if (board[2] == board[4] && board[4] == board[6] && board[2] != 0)
        {
            return board[2];
        }

        return 0;
    }

    public void SpaceClicked(int index)
    {
        if (board[index] == 0)
        {
            board[index] = currentPlayer;
            spaces[index].GetComponent<Renderer>().material.color = currentPlayer == 1 ? Color.red : Color.blue;
            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }
    }
}

