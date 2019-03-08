using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideui : MonoBehaviour
{
    public GameObject menuDes;
    public GameObject menuWall;
    public GameObject canhide;
    public GameObject uitog;

    public void hideWall()
    {
        menuWall.SetActive(true);
        canhide.SetActive(false);
        uitog.SetActive(false);
    }
    public void hideDes()
    {
        menuDes.SetActive(true);
        canhide.SetActive(false);
        uitog.SetActive(false);
    }




}
