using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //settingsMenu

    public GameObject settingsCanvas;
    public GameObject mainMenuCanvas;

    public void settingsMenuUI(){

        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);

    }
    public void mainMenuUI()
    {

        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);

    }
    public void gameExit()
    {
        //Debug.Log("Game is exiting");
        Application.Quit();
    }
}
