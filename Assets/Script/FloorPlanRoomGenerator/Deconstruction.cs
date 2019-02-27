using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deconstruction : MonoBehaviour
{

    bool isactive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isactive = false;
        }
        if (isactive)
        {
            deletionMode();
        }
        else {
            
        }
     
    }
    public void deletionMode()
    {
       
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    BoxCollider cube = hit.collider as BoxCollider;
                    if (cube != null)
                    {

                        Destroy(cube.gameObject);

                    }
                }
            }
        }
    public void Trigger()
    {
        isactive = !isactive;
    }
    public void fastExit() {
      
    }

}


