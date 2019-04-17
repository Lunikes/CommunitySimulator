using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    public void saveViaJson()
    {
        Debug.Log("kkkk");
        go = GameObject.FindGameObjectsWithTag("fool");//to find out all gameobject which with tag ("fool"), that one is to find out the gameobjec which player created
        saveddata data = new saveddata();//the class which hold the data
        List<Vector3> positionls = new List<Vector3>();//object position
        List<string> path = new List<string>();//object prefab file location
        List<Vector3> rotals = new List<Vector3>();//objcet rotation
        List<Vector3> scales = new List<Vector3>();//objcet scale

        //for lopp to save each element which player created
        foreach (var g in go)
        {
            Vector3 position = new Vector3();
            Vector3 rota = new Vector3();
            Vector3 sca = new Vector3();

            position = g.transform.position;
            rota = g.transform.eulerAngles;
            sca = g.transform.localScale;

            //to check the object's name and  take out the "(clone)"
            var pos = g.name.IndexOf("(");
            string ojname;
            if (pos < 0)
            {
                ojname = g.name;
            }
            else
            {
                ojname = g.name.Substring(0, pos);

            }
            //Debug.Log(sca);
            path.Add(ojname);
            rotals.Add(rota);
            scales.Add(sca);
            positionls.Add(position);
        }

        data.go = positionls;
        data.path = path;
        data.rotation = rotals;
        data.scale = scales;
        data.xlength = GameObject.FindGameObjectWithTag("floorplan").GetComponent<GridSpawner>().xLength;
        data.zlength = GameObject.FindGameObjectWithTag("floorplan").GetComponent<GridSpawner>().zLength;
        //creat a json file to save the game data
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void loadViaJson()
    {     //delete the gameobject which haved save in the file
        go = GameObject.FindGameObjectsWithTag("fool");
        foreach (var g in go)
        {
            Destroy(g);
        }

        //read the .json file and change to readable saved data
        string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        saveddata saved = JsonUtility.FromJson<saveddata>(json);

        //to load the saved data
        int count = 0;
        string floorpath = "Assets/Prefab/";
        //for loop to load the data
        foreach (var g in saved.path)
        {

            string pathname = floorpath + g + ".prefab";
            var grid = Resources.Load(pathname, typeof(GameObject));//for build
                //AssetDatabase.LoadAssetAtPath(pathname, typeof(GameObject));//for unity editor 
            GameObject pre = Instantiate((GameObject)grid, saved.go[count], Quaternion.identity);
            pre.transform.SetParent(GameObject.FindGameObjectWithTag("floorplan").transform);
            pre.transform.eulerAngles = saved.rotation[count];
           pre.transform.localScale = saved.scale[count];
            if (g == "GroundGridCube")
            {
                pre.GetComponentInChildren<GroundCube>().SetBuildSystem(bs);
            }

            count++;
        }

        GameObject.FindGameObjectWithTag("floorplan"). GetComponent<GridSpawner>().xLength = saved.xlength;
        GameObject.FindGameObjectWithTag("floorplan"). GetComponent<GridSpawner>().zLength = saved.zlength;



    }

    /// <summary>
    /// the class to hold the saved data
    /// </summary>
    [System.Serializable]
    public class saveddata
    {
        public List<Vector3> go;
        public List<string> path;
        public List<Vector3> rotation;
        public List<Vector3> scale;
        public int xlength;
        public int zlength;

    }


    /*this is the old version fo the savefile
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
        else
        {
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
    */
}