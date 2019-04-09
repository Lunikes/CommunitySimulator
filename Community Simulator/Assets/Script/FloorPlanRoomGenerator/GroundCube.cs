using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCube : MonoBehaviour
{
    public Color hightlightColor;
    private Color normalColor;
    private Color currentColor;

    private MeshRenderer myRend;
    private bool isSelected;

    private BuildSystem buildSystem;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        normalColor = myRend.material.color;
        currentColor = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBuildSystem(BuildSystem bs) {
        buildSystem = bs;
      
    }/*
    public void OnMouseEnter()
    {
        if (!buildSystem.GetIsBuilding()) {
            Selection();
        }
    }
    public void OnMouseExit()
    {      
         
        if (!buildSystem.GetIsBuilding())
        {
            Selection();
        }
    }*/
    public void Selection() {
        isSelected = !isSelected;//toggle boolean for select and de-select
        if (isSelected)
        {
            currentColor = hightlightColor;
        }
        else {
            currentColor = normalColor;
        }
        myRend.material.color = currentColor;
    }
}
