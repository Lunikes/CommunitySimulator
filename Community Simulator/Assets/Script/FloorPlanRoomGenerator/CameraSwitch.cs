using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera cameraOne;
    public Camera cameraTwo;

    private int tog =0;

    // Use this for initialization
    void Start()
    {
        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
           // cameraOne.SetActive(true);


           // cameraTwo.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            //cameraTwo.SetActive(true);



           // cameraOne.SetActive(false);
        }

    }

    public void changeCamera()
    {
        if (tog == 0)
        {
            cameraTwo.enabled = true;
            cameraOne.enabled = false;
            tog = 1;
        }
        else
        {
            cameraTwo.enabled = false;
            cameraOne.enabled = true;
            tog = 0;
        }
        
    }
}
