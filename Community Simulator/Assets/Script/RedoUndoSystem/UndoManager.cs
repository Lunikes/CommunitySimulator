using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    private int steps = 0;
    public UndoObjectSystem system = new UndoObjectSystem();
    public LayerMask ActiveLayer;
    private GameObject currentObj;
    public float DelayTime = .5f;
    private float CurTime;
    private float setTimer;
    public bool Ifundo = false;
    // Start is called before the first frame update
    void Start()
    {
        system = new UndoObjectSystem();
        CurTime = DelayTime;
        setTimer = DelayTime / 4;

       
    }


    // Update is called once per frame
    void Update()
    {
     Undo();      
    }
    public void Undo() {
        if (Ifundo = true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ActiveLayer))
            {
                currentObj = hit.collider.gameObject;
                system.Store(currentObj, steps);
                steps = system.spot;
            }
        }

    }

}
