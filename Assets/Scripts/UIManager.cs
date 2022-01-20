using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // this script manages all of the UI screens
    // attached to the User Interface canvas
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private GameObject LoseScreenCaught;
    [SerializeField] private GameObject retryButton;
    public bool gameOver = false;
    
    public void StartingGame()
    {
        MainMenu.SetActive(false);
        HUD.SetActive(true);
    }
    
    public void WonGame()
    {
        HUD.SetActive(false);
        WinScreen.SetActive(true);
        StartCoroutine(WaitForRetry());
    }

    public void LostGame()
    {
        HUD.SetActive(false);
        LoseScreen.SetActive(true);
        StartCoroutine(WaitForRetry());
    }

    public void CaughtCheating()
    {
        HUD.SetActive(false);
        LoseScreenCaught.SetActive(true);
        StartCoroutine(WaitForRetry());
    }

    IEnumerator WaitForRetry()
    {
        yield return new WaitForSeconds(2);

        retryButton.SetActive(true);
        gameOver = true;
    }

}
