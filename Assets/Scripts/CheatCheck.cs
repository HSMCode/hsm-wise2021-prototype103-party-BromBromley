using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCheck : MonoBehaviour
{
    // this script keeps track of the times the player cheated
    private OpponentBehaviour _opponentBehaviour;
    private DiceController _diceController;
    private PieceController _pieceController;
    public int timesCaught = 0;

    void Awake()
    {
        _opponentBehaviour = FindObjectOfType<OpponentBehaviour>();
        _diceController = FindObjectOfType<DiceController>();
        _pieceController = FindObjectOfType<PieceController>();
    }

    void Update()
    {
        if (_opponentBehaviour.lookingForward == true)
        {
            if (_pieceController.stepsTaken > _diceController.score)  //catches you when turning back his head
            {
                timesCaught++;
            }
        }
    }
}
