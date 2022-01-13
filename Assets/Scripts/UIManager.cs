using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // this script manages all of the UI elements and different screens
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private GameObject LoseScreenCaught;

    private GameManager _GameManager;

    void Awake()
    {
        _GameManager = FindObjectOfType<GameManager>();
    }
    
    public void StartingGame() //triggered by pressing the Start Game button
    {
        MainMenu.SetActive(false);
        HUD.SetActive(true);
        _GameManager.isRunning = true;
        _GameManager.StartGame();
    }
    
    public void WonGame()
    {
        HUD.SetActive(false);
        WinScreen.SetActive(true);
    }

    public void LostGame()
    {
        HUD.SetActive(false);
        LoseScreen.SetActive(true);
    }

    public void CaughtCheating()
    {
        HUD.SetActive(false);
        LoseScreenCaught.SetActive(true);
    }

}
