using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCheck : MonoBehaviour
{
    // this script keeps track of the times the player cheated
    // attached to opponent body
    private OpponentBehaviour _opponentBehaviour;
    private DiceController _diceController;
    private PieceController _pieceController;
    private AudioManager _audioManager;
    [SerializeField] private GameObject leftEyebrow;
    [SerializeField] private GameObject rightEyebrow;
    public int timesCaught = 0;
    public int perceivedSteps = 0;

    void Awake()
    {
        _opponentBehaviour = FindObjectOfType<OpponentBehaviour>();
        _diceController = FindObjectOfType<DiceController>();
        _pieceController = FindObjectOfType<PieceController>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (_opponentBehaviour.lookingForward == true && _opponentBehaviour.gotCaught == false)
        {
            if (_pieceController.stepsTaken > perceivedSteps)  //catches you when turning back his head
            {
                StartCoroutine(GettingCaught());
            }
        }
    }

    IEnumerator GettingCaught()
    {
        leftEyebrow.transform.Rotate(new Vector3(0, 0, -20), Space.Self);
        rightEyebrow.transform.Rotate(new Vector3(0, 0, 20), Space.Self);

        timesCaught++;

        for (int i = (_pieceController.stepsTaken - perceivedSteps); i > 0; i--) //sets the players piece back after getting caught cheating
            {
                _pieceController.MovePieceBack();
            }

        perceivedSteps = _pieceController.stepsTaken;

        _opponentBehaviour.gotCaught = true;
        _audioManager.AngrySound();
        
        yield return new WaitForSeconds(4);

        leftEyebrow.transform.Rotate(new Vector3(0, 0, 20), Space.Self);
        rightEyebrow.transform.Rotate(new Vector3(0, 0, -20), Space.Self);
    }
}
