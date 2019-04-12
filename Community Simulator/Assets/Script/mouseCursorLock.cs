using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursorLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

}
