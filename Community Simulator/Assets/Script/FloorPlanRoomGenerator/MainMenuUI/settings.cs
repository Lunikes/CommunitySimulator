using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{

    bool screenFill = true;
    public Dropdown m_Dropdown;

    public void screenFillFun()
    {
        screenFill = !screenFill;
        Screen.fullScreen = screenFill;
    }



    public void screenRez()
    {
        int chosenInt = m_Dropdown.GetComponent<Dropdown>().value;
        //Debug.Log(chosenInt);
        if(chosenInt == 0)
        {
            Screen.SetResolution(1920, 1080, screenFill);
        }
        else if(chosenInt == 1)
        {
            Screen.SetResolution(1366, 768, screenFill);
        }
        else if (chosenInt == 2)
        {
            Screen.SetResolution(1280, 720, screenFill);
        }
        else if (chosenInt == 3)
        {
            Screen.SetResolution(1024, 768, screenFill);
        }
    }
}

