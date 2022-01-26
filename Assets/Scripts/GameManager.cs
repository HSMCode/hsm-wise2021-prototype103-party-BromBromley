using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // the game manager
    // attached to the empty object GameManager
    private DiceController _diceController;
    private UIManager _uiManager;
    private PieceController _pieceController;
    private OpponentBehaviour _opponentBehaviour;
    private CheatCheck _cheatCheck;
    private OpponentPiece _opponentPiece;
    private AudioManager _audioManager;
    private ReloadScene _reloadScene;
    public bool isRunning = false;

    void Awake()
    {
        _diceController = FindObjectOfType<DiceController>();
        _uiManager = FindObjectOfType<UIManager>();
        _opponentBehaviour = FindObjectOfType<OpponentBehaviour>();
        _pieceController = FindObjectOfType<PieceController>();
        _cheatCheck = FindObjectOfType<CheatCheck>();
        _opponentPiece = FindObjectOfType<OpponentPiece>();
        _audioManager = FindObjectOfType<AudioManager>();
        _reloadScene = FindObjectOfType<ReloadScene>();
    }

    void Start()
    {
        _audioManager.StartMusic();
    }

    void Update()
    {

        if (isRunning == false && _diceController.playersTurn == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
        if (isRunning)
        {
            if (_pieceController.stepsTaken >= 15)
            {
                _uiManager.WonGame();
                _audioManager.PlayEvilLaughter();
                isRunning = false;
                _opponentBehaviour.countdown = false;
            }

            if (_opponentPiece.opponentScore >= 15)
            {
                _uiManager.LostGame();
                _audioManager.LoseSound();
                isRunning = false;
                _opponentBehaviour.countdown = false;
            }

            if (_cheatCheck.timesCaught >= 2)
            {
                _uiManager.CaughtCheating();
                _audioManager.LoseSound();
                isRunning = false;
                _opponentBehaviour.countdown = false;
            }
        }

        if (_uiManager.gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            _reloadScene.RestartScene();
        }

        /*if (Input.GetKeyDown(KeyCode.Escape) && isRunning == false)
        {
            QuitGame();
        }*/
    }

    public void StartGame()
    {
        _uiManager.StartingGame();
        StartCoroutine(OnStartGame());
    }

    IEnumerator OnStartGame()
    {
        yield return new WaitForSeconds(1);
        isRunning = true;

        _opponentBehaviour.countdown = true;
        _diceController.playersTurn = true;
        _diceController.instructionsText.text = "[space] to roll the dice";
    }
    
    /*public void QuitGame()
    {
        Application.Quit();
    }*/
}
