using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeSettings : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject mainMenuCanvas;

    public void settingsMenuUI()
    {
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
