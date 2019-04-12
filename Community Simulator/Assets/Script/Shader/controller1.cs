using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller1 : MonoBehaviour
{

    public Texture[] textures;
    public int currentTexture;
    public Texture textureSelected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                textC(hit.transform.gameObject);
            }
        }
    }

    public void shadeSelect(int num)
    {
        currentTexture = num;
    }

    public void textC(GameObject rend)
    {
        rend.GetComponent<Renderer>().sharedMaterial.mainTexture = textures[currentTexture];
    }
}

