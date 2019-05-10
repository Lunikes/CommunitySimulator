using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    { 
        
    }
     
    // Update is called onc e per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Cam era.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {

                    Rigidbody rb;

                    if (rb = hit.transform.GetComponent<Rigidbody>())
                    {
                        OnMouseDrag();
                        
                    }
                }
            }
        }
    }
    private void PrintName(GameObject cube)
    {
        Debug.Log(cube.name);
    }
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);
    }
}
