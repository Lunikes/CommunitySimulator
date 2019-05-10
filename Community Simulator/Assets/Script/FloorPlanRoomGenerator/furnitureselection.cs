using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class furnitureselection : MonoBehaviour
{
    private List<Transform> models;

    public GameObject hideObject;
    public GameObject hideObjectCamera;

    bool onOff = false;

    public void furnitureModelMode()
    {
        onOff = !onOff;
        hideObject.SetActive(!onOff);
        hideObjectCamera.SetActive(!onOff);
        unHideObject.SetActive(onOff);
        arrowR.SetActive(onOff);
        arrowL.SetActive(onOff);
    }



    int select = 0;

    public void Selector(int num)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var model = transform.GetChild(i);
            models.Add(model);
            model.gameObject.SetActive(i == select);
        }
    }




    public void Awake()
    {
        models = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var model = transform.GetChild(i);
            models.Add(model);

            model.gameObject.SetActive(i == 0);
        }
    }
}

}
