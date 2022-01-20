using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceController : MonoBehaviour
{
    // this script manages the player's input and changes the HUD texts
    // attached to the empty object DiceManager
    public TextMeshProUGUI dieRollText;
    public TextMeshProUGUI instructionsText;
    public TextMeshProUGUI timerText;

    public int dieRoll;
    public int score;
    public bool diceRolled;
    public bool movePiece;
    public bool playersTurn;
    private float timer = 5;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    private CheatCheck _cheatCheck;
    private PieceController _pieceController;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        _cheatCheck = FindObjectOfType<CheatCheck>();
        _pieceController = FindObjectOfType<PieceController>();
    }
    void Start()
    {
        diceRolled = false;
        movePiece = false;
        playersTurn = false;
    }

    void Update()
    {
        if (playersTurn && _gameManager.isRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space) && diceRolled == false && movePiece == false) // player rolls the dice
            {
                int dieRoll = Random.Range(1, 6);
                dieRollText.text = "You rolled a " + dieRoll;
                score += dieRoll;
                _cheatCheck.perceivedSteps += dieRoll;

                instructionsText.text = "[space] for each step you want to take";

                _audioManager.DiceSound();

                movePiece = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && diceRolled == true && movePiece == false) // start next turn
            {
                dieRollText.text = " ";
                instructionsText.text = "[space] to roll the dice";

                diceRolled = false;
            }
        }

        TimeToMove();

        if (timer <= 0) // checks when timer runs out and initiates the opponent's turn
            {
                movePiece = false;
                playersTurn = false;

                _cheatCheck.perceivedSteps += _pieceController.stepsTaken;

                timerText.text = " ";
                dieRollText.text = " ";
                instructionsText.text = "Wait for your turn";

                timer = 3;
            }
    }

    void TimeToMove() // timer for moving the piece
    {
        if (movePiece)
        {
            diceRolled = true;
            timer -= Time.deltaTime;

            float seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", 0, seconds);
        }
    }
}
