using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sharedMaterial.mainTexture = null;
    }

}
