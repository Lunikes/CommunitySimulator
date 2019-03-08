using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
   
    public List<float[]> gridposition;
   public SavedData(List<float[]> position)
    {
        this.gridposition = position;
    }
}
