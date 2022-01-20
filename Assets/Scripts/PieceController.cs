using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    // this script moves the player's piece
    // attached to the blue pawn
    private DiceController _dice;
    public int stepsTaken;
    void Start()
    {
        _dice = FindObjectOfType<DiceController>();
    }

    void Update()
    {
        if (_dice.diceRolled && _dice.movePiece &&_dice.playersTurn && stepsTaken < 15)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MovePiece();
                stepsTaken++;
            }
        }
    }

    public void MovePiece() // moves piece one field
    {
        transform.Translate(new Vector3(0.105f, 0, 0), Space.World);
    }
}
