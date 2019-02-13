using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWallCreation : MonoBehaviour
{
    bool iswallc = false;
   public WallCreation wallc;
    // Start is called before the first frame update
    void Start()
    {
        wallc = GetComponent<WallCreation>();
        wallc.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void toggle()
    {
        iswallc = !iswallc;
        if (iswallc) {
          
            wallc.enabled = true;
        } else {
            wallc.enabled = !wallc.enabled ;
        }
    }
}
