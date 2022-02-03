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
        leftEyebrow.transform.Rotate(new Vector3(0, 0, -20), Space.Self); // facial expression changes to looking angry
        rightEyebrow.transform.Rotate(new Vector3(0, 0, 20), Space.Self);

        timesCaught++;

        // sets the player's piece back after getting caught cheating, but somehow creates a bug where you get caught even tho you're not cheating 
        /*for (int i = (_pieceController.stepsTaken - perceivedSteps); i > 0; i--)
            {
                _pieceController.MovePieceBack();
            }*/

        perceivedSteps = _pieceController.stepsTaken; // resets perceivedSteps so you don't immediately get caught again

        _opponentBehaviour.gotCaught = true;
        _audioManager.AngrySound();
        
        yield return new WaitForSeconds(4);

        leftEyebrow.transform.Rotate(new Vector3(0, 0, 20), Space.Self); // facial expression changes back to normal
        rightEyebrow.transform.Rotate(new Vector3(0, 0, -20), Space.Self);
    }
}
