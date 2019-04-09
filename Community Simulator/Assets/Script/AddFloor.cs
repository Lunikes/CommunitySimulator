using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFloor : MonoBehaviour
{
    GameObject[] go;
    float largestY  = -200;
    int totalfloor = 1;

    public GameObject cubePrefab;
    public BuildSystem buildSystem;

    public InputField xInput;
    public InputField zInput;

    float getyposition() {
        go = GameObject.FindGameObjectsWithTag("fool");

        foreach (var g in go)
        {

            if (largestY < g.transform.position.y)
            {
                largestY = g.transform.position.y;
            }

        }
        Debug.Log("largest Y : " + largestY);
        return largestY;

    }


    public void addFloor()
    {
        totalfloor++;
        float y = getyposition();
        // xlength = GetComponent<GridSpawner>().xLength;
        // zlength = GetComponent<GridSpawner>().zLength;


        int xlength = int.Parse(xInput.text);
        int zlength = int.Parse(zInput.text);
        for (int x = 0; x < xlength; x++)
        {
            for (int z = 0; z < zlength; z++)
            {
                Vector3 position = new Vector3(x, y+1, z);//Off set the grid a bit so it will round to whole interger by building system so everything will line up to the edge of the cube
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);//So the actual instantiated gameObject are not rotating to anywhere
                //cube.GetComponent<GroundCube>().SetBuildSystem(buildSystem);
                cube.transform.SetParent(GameObject.FindGameObjectWithTag("playersaved").transform);
            }

        }



    }
}
