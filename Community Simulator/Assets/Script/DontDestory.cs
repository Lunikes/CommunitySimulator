using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace desz
{
    public class DontDestory : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            Debug.Log("yashila");
        }
    }
}