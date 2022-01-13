using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DiceController _dice;
    private UIManager _uiManager;
    private PieceController _pieceController;
    private OpponentBehaviour _opponentBehaviour;
    private CheatCheck _cheatCheck;
    private OpponentPiece _opponentPiece;
    public bool isRunning = false;

    void Awake()
    {
        _dice = FindObjectOfType<DiceController>();
        _uiManager = FindObjectOfType<UIManager>();
        _opponentBehaviour = FindObjectOfType<OpponentBehaviour>();
        _pieceController = FindObjectOfType<PieceController>();
        _cheatCheck = FindObjectOfType<CheatCheck>();
        _opponentPiece = FindObjectOfType<OpponentPiece>();


    }

    void Update()
    {
        if (isRunning)
        {
            if (_pieceController.stepsTaken >= 15)
            {
                _uiManager.WonGame();
                isRunning = false;
            }

            if (_opponentPiece.opponentScore >= 15)
            {
                _uiManager.LostGame();
                isRunning = false;
            }

            if (_cheatCheck.timesCaught >= 3)
            {
                _uiManager.CaughtCheating();
                isRunning = false;
            }
        }
    }

    public void StartGame()
    {
        isRunning = true;
        _opponentBehaviour.countdown = true;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
