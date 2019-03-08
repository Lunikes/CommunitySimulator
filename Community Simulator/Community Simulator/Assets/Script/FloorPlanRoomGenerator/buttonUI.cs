using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class buttonUI : MonoBehaviour
{

    public GameObject CanBeHide;
    int onOff = 1;

    public void uiTog() {
   
        if (onOff == 0)
        {
            CanBeHide.SetActive(true);
            onOff = 1;
        }
        else
        {
            CanBeHide.SetActive(false);
            onOff = 0;
        }
    }
}
