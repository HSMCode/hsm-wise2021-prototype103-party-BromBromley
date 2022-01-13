using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceController : MonoBehaviour
{
    // this script manages the player's input and changes the HUD texts
    public TextMeshProUGUI dieRollText;
    public TextMeshProUGUI instructionsText;
    public TextMeshProUGUI timerText;

    public int dieRoll;
    public int score;
    public bool diceRolled;
    public bool movePiece;
    public bool playersTurn;

    private float timer = 11;
    void Start()
    {
        diceRolled = false;
        movePiece = false;
        playersTurn = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playersTurn)
        {
            if (diceRolled == false && movePiece == false) // player rolls the dice
            {
                int dieRoll = Random.Range(1, 6);
                dieRollText.text = "You rolled a " + dieRoll;
                score += dieRoll;

                instructionsText.text = "Press 'Space' for each step you want to take";

                movePiece = true;
            }
            if (diceRolled == true && movePiece == false) // start next turn
            {
                dieRollText.text = " ";
                instructionsText.text = "Press 'Space' to roll the dice";

                diceRolled = false;
            }
        }

        TimeToMove();

        if (timer <= 0) // checks when timer runs out and initiates the opponent's turn
            {
                movePiece = false;
                playersTurn = false;

                timerText.text = " ";
                dieRollText.text = " ";
                instructionsText.text = "Wait for your turn";

                timer = 11;
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
