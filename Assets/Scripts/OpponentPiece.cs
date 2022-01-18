using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentPiece : MonoBehaviour
{
    // this script lets the opponent's piece move when it's their turn
    // attached to the green pawn
    private DiceController _diceController;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    private int dieRoll;
    public int opponentScore;
    void Awake()
    {
        _diceController = FindObjectOfType<DiceController>();
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (_diceController.playersTurn ==  false && _gameManager.isRunning)
        {
            dieRoll = Random.Range(3, 6); //randomized die roll
            opponentScore += dieRoll;
            _audioManager.DiceSound();

            for (int i = 0; i < dieRoll; i++) // moves the piece accordingly
            {
                transform.Translate(new Vector3(0.105f, 0, 0), Space.World);

                _diceController.instructionsText.text = "Your turn! Press 'Space' to roll the dice";
                _diceController.playersTurn = true;
                _diceController.diceRolled = false;
            }
        }
    }
}
