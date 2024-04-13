using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{

    public int row;
    public int col;

    public Sprite xSprite;
    public Sprite oSprite;

    private Image image;
    private Button button;

    private Board board;


    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        board = FindAnyObjectByType<Board>();

    }
    public void ChangeSprite(string s)
    {
        if(s == "x")
        {
            image.sprite = xSprite;
        }else
        {
            image.sprite = oSprite;
        }
        button.enabled = false;
    }

    public void OnClick()
    {
        ChangeSprite(board.currentTurn);

        if (board.Check(this.row, this.col, board.currentTurn))
            Debug.Log(board.currentTurn + " win");

        if (board.currentTurn.Equals("x"))
        {
            board.currentTurn = "o";
        }
        else
        {
            board.currentTurn = "x";
        }
    }

}
