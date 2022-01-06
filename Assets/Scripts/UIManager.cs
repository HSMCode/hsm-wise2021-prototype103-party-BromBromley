using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;
    
    public void StartGame()
    {
        MainMenu.SetActive(false);
        HUD.SetActive(true);
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
}
