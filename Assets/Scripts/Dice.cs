using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public TextMeshProUGUI dieRollText;
    public TextMeshProUGUI instructionsText;
    public int dieRoll;
    public int score;
    public bool diceRolled;
    void Start()
    {
        diceRolled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (diceRolled == false)
            {
                int dieRoll = Random.Range(1, 6);
                dieRollText.text = "You rolled a " + dieRoll;
                score += dieRoll;

                instructionsText.text = "Press 'Space' for each step you want to take";

                diceRolled = true;
            }
            else
            {
                dieRollText.text = " ";
                instructionsText.text = "Press 'Space' to roll the dice";
                Debug.Log("Imagine the piece is moving " + dieRoll + " spaces now");

                diceRolled = false;
            }
        }
    }
}
