﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    public void changeResolution()
    {
        Screen.SetResolution(800, 600, false);
    }
}
