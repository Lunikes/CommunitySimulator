using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    GameObject floor;
    GameObject players;
    GameObject[] go;
    bool isGameObjectExit;
    public BuildSystem bs;
    string floorpath = "Assets/Prefab/savedPrefab/floorpanel.prefab";
    string playercreatedpath = "Assets/Prefab/savedPrefab/playercreated.prefab";


    public void save()//save the gameobject which player created
    {
        go = GameObject.FindGameObjectsWithTag("fool");
        foreach (var g in go)
        {
            g.transform.SetParent(GameObject.FindGameObjectWithTag("playersaved").transform);

        }
        floor = AssetDatabase.LoadAssetAtPath(floorpath, typeof(GameObject)) as GameObject;//check the prefab exit or not
        if (floor == null)
        {
            isGameObjectExit = false;
            floor = GameObject.FindGameObjectWithTag("playersaved");
            PrefabUtility.CreatePrefab(floorpath, floor);
        }
        else {
            GameObject prefab = GameObject.FindGameObjectWithTag("playersaved");
            PrefabUtility.CreatePrefab(floorpath, prefab);

        }
        Debug.Log("Save function work");





    }
    public void load()//load the gameobject which player saved last time
    {
        Debug.Log("Load function work");
        floor = AssetDatabase.LoadAssetAtPath(floorpath, typeof(GameObject)) as GameObject;
        Vector3 position = GameObject.FindGameObjectWithTag("playersaved").transform.position;
        //find the previous savedData, and delete it
        GameObject saved = GameObject.FindGameObjectWithTag("playersaved");
        Destroy(saved);
        GameObject pre = Instantiate(floor, position, Quaternion.identity);
        pre.GetComponentInChildren<GroundCube>().SetBuildSystem(bs);

        //to set the groundcud's buildSystem
        Component[] hingeJoints;
        hingeJoints = pre.GetComponentsInChildren<GroundCube>();

        foreach (GroundCube joint in hingeJoints)
        { joint.SetBuildSystem(bs); }
        //rotate the angles of the prefab
        pre.transform.eulerAngles = new Vector3(GameObject.FindGameObjectWithTag("playersaved").transform.rotation.eulerAngles.x, 0, 0);
    }
        
    
}
