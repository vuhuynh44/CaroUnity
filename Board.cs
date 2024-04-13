using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Board : MonoBehaviour
{
    public GameObject cellPrefab;
    public Transform board;
    public GridLayoutGroup grid;
    public string currentTurn = "x";
    public GameObject panel;
    public TextMeshProUGUI announce;

    public int boardSize;
    public string[,] matrix;
    private void Start()
    {
        matrix = new string[boardSize+1,boardSize+1];
        grid.constraintCount = boardSize;
        CreateBoard();
    }

    private void CreateBoard()
    {
        for(int i =0; i <= boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Cell cell = Instantiate(cellPrefab, board).GetComponent<Cell>();
                cell.row = i;
                cell.col = j;
                matrix[i, j] = "";
            }
        }
    }

    public bool Check(int row, int col, string currentTurn)
    {
        matrix[row, col] = currentTurn;
        bool result = false;

        // Check hang doc
        int count = 0;
        for (int i = row - 1; i >= 0; i--) // tren
        {
            if (matrix[i, col] == currentTurn) count++;
            else break;
        }
        for (int i = row + 1; i < boardSize; i++) //duoi
        {
            if (matrix[i, col] == currentTurn) count++;
            else break;
        }
        if (count == 4)
        {
            result = true;
            announce.SetText("The winner is " + currentTurn);
            panel.SetActive(true);
        };

        // Check hang ngang
        count = 0;
        for (int i = col - 1; i >= 0; i--) //trai
        {
            if (matrix[row, i] == currentTurn) count++;
            else break;
        }
        for (int i = col + 1; i < boardSize; i++) //phai
        {
            if (matrix[row, i] == currentTurn) count++;
            else break;
        }
        if (count == 4)
        {
            result = true;
            announce.SetText("The winner is " + currentTurn);
            panel.SetActive(true);
        };

        // Check hang cheo 1
        count = 0;
        for (int i = 1; i <= Mathf.Min(row, col); i++)
        {
            if (matrix[row - i, col - i] == currentTurn) count++;
            else break;
        }
        for (int i = 1; i < Mathf.Min(boardSize - row, boardSize - col); i++)
        {
            if (matrix[row + i, col + i] == currentTurn) count++;
            else break;
        }
        if (count == 4)
        {
            result = true;
            announce.SetText("The winner is " + currentTurn);
            panel.SetActive(true);
        };

        // Check hang cheo 2
        count = 0;
        for (int i = 1; i <= Mathf.Min(row, boardSize - col - 1); i++)
        {
            if (matrix[row - i, col + i] == currentTurn) count++;
            else break;
        }
        for (int i = 1; i < Mathf.Min(boardSize - row, col + 1); i++)
        {
            if (matrix[row + i, col - i] == currentTurn) count++;
            else break;
        }
        if (count == 4) 
        { 
            result = true;
            announce.SetText("The winner is " + currentTurn);
            panel.SetActive(true);
        };

        return result;
    }



}
