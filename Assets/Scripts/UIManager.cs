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
        StartCoroutine(WaitForWinScreen());
        StartCoroutine(WaitForRetry());
    }

    public void LostGame()
    {
        StartCoroutine(WaitForLoseScreen());
        StartCoroutine(WaitForRetry());
    }

    public void CaughtCheating()
    {
        StartCoroutine(WaitForCheatScreen());
        StartCoroutine(WaitForRetry());
    }


    // makes the screens/buttons appear a couple of seconds after getting triggered
    IEnumerator WaitForRetry()
    {
        yield return new WaitForSeconds(3);

        retryButton.SetActive(true);
        gameOver = true;
    }

    IEnumerator WaitForWinScreen()
    {
        yield return new WaitForSeconds(1);

        HUD.SetActive(false);
        WinScreen.SetActive(true);
    }

    IEnumerator WaitForLoseScreen()
    {
        yield return new WaitForSeconds(1);

        HUD.SetActive(false);
        LoseScreen.SetActive(true);
    }

    IEnumerator  WaitForCheatScreen()
    {
        yield return new WaitForSeconds(1);

        HUD.SetActive(false);
        LoseScreenCaught.SetActive(true);
    }

}
