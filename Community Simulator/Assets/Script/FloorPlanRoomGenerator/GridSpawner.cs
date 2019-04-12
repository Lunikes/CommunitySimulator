using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GridSpawner : MonoBehaviour
{
    public int xLength;
    public int zLength;
    public GameObject cubePrefab;
    public BuildSystem buildSystem;
    public InputField xva;
    public InputField zva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameam
    void Update()
    {
        
    }
    public void setXValue() {
     
        xLength = int.Parse(xva.text); ;
        
        Debug.Log("xLength is now" + xLength);
    }
    public void setZvalue() {
        zLength = int.Parse(zva.text);
        ;

        Debug.Log("zLenght is now" + zLength);
    }
    public void ApplayChange() {
        for (int x = 0; x < xLength; x++)
        {
            for (int z = 0; z < zLength; z++)
            {
                Vector3 position = new Vector3(x, 0, z);//Off set the grid a bit so it will round to whole interger by building system so everything will line up to the edge of the cube
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);//So the actual instantiated gameObject are not rotating to anywhere
                cube.GetComponent<GroundCube>().SetBuildSystem(buildSystem);
                cube.transform.SetParent(GameObject.FindGameObjectWithTag("floorplan").transform);
            }

        }
    }
    public void Reolad() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
            }
}
