﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Text textshown = null;
    public int page = 0;

    public void changetext(int num)
    {
        page = page + num;
        if (page < 1)
        {
            page = 1;
        }
        if (page > 4)
        {
            page = 4;
        }
        if (page == 1)
        {
            textshown.text = "You can use the esc key to exit first person mode";
        }
        if (page == 2)
        {
            textshown.text = "you can click the toggle button to enable the default ui";
        }
        if (page == 3)
        {
            textshown.text = "you can open and close this tutorial with the t key";
        }
        if (page == 4)
        {
            textshown.text = "In order to open the fps menu click the \"q\" key";
        }
    }
}
