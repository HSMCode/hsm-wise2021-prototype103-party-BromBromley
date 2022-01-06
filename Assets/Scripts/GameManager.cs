using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dice _dice;
    private UIManager _uiManager;

    void Awake()
    {
        _dice = FindObjectOfType<Dice>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (_dice.score >= 16)
        {
            _uiManager.WonGame();
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
