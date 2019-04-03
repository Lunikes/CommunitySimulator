using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //settingsMenu

    public GameObject settingsCanvas;
    public GameObject mainMenuCanvas;
    public GameObject LoginPanel;

    public void settingsMenuUI(){
        LoginPanel.SetActive(false);
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);

    }
    public void mainMenuUI()
    {
        LoginPanel.SetActive(false);
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);

    }

    public void OnlineLogin() {
        LoginPanel.SetActive(true);
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void gameExit()
    {
        //Debug.Log("Game is exiting");
        Application.Quit();
    }
}
