using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoObjectSystem : System.Object
{
    public List<UndoObjectInfo> StoredObject = new List<UndoObjectInfo>();
    private bool NewObject;
    public int spot = 1;

    GameObject CreateObj(int Slot)
    {
        GameObject obj = new GameObject();
        if (!string.IsNullOrEmpty(StoredObject[Slot].Name))
            obj.name = StoredObject[Slot].Name;

        obj.transform.position = StoredObject[Slot].Position;

        obj.transform.rotation = StoredObject[Slot].Rotation;

        obj.transform.localScale = StoredObject[Slot].Scale;

        obj.AddComponent<Renderer>();
        if (StoredObject[Slot].Material)
            obj.GetComponent<Renderer>().material = StoredObject[Slot].Material;
        if (StoredObject[Slot].Mesh)
        {
            obj.AddComponent<MeshFilter>();
            obj.GetComponent<MeshFilter>().mesh = StoredObject[Slot].Mesh;
        }
        return obj;
    }

    public void Store(GameObject gameObj, int spot)
    {
        NewObject = false;
        UndoObjectInfo obj = new UndoObjectInfo();
        obj.Object = gameObj;
        obj.Name = gameObj.name;
        obj.Position = gameObj.transform.position;
        obj.Scale = gameObj.transform.localScale;
        obj.Rotation = gameObj.transform.rotation;

        if (gameObj.GetComponent<Renderer>())
            obj.Material = gameObj.GetComponent<Renderer>().material;

        if (gameObj.GetComponent<MeshFilter>())
            obj.Mesh = gameObj.GetComponent<MeshFilter>().mesh;

        NewObject = IsNew(obj, spot);

        if (NewObject == true)
        {
            spot = SetSpot(spot);
            StoredObject.Insert(spot - 1, obj);

        }
    }
    public int SetSpot(int set)
    {
        if (set < StoredObject.Count)
        {
            set = set + 1;
            return set++;

        }
        else
        {
            return StoredObject.Count + 1;
        }
    }

        bool IsNew(UndoObjectInfo obj, int spot)
        {
            if (StoredObject.Count <= 0)
                return true;

            UndoObjectInfo LastObj = StoredObject[spot - 1];
            if (LastObj.Object == obj.Object)
            {
                if (LastObj.Name.Equals(obj.Name) &&
                    LastObj.Position == obj.Position &&
                    LastObj.Rotation == obj.Rotation &&
                    LastObj.Material == obj.Material)
                {
                    return false;
                }
                else
                    return true;
            }
            else
            {
                return true;
            }
        }
    

        public void Call(int Slot)
        {
            GameObject obj = StoredObject[Slot].Object;
            if (!string.IsNullOrEmpty(StoredObject[Slot].Name))
                obj.name = StoredObject[Slot].Name;

            obj.transform.position = StoredObject[Slot].Position;

            obj.transform.rotation = StoredObject[Slot].Rotation;

            obj.transform.localScale = StoredObject[Slot].Scale;

            if (StoredObject[Slot].Material)
                obj.GetComponent<Renderer>().material = StoredObject[Slot].Material;
        }

        // Update is called once per frame
        void Update()
        {

        }
    
}
