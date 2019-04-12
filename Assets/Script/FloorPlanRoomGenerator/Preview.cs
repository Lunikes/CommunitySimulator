using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    List<GameObject> obj = new List<GameObject>();
    List<GroundCube> Cubes = new List<GroundCube>();

    public Material Buildable;
    public Material UnBuildable;
    public GameObject cubePrefab;

    private MeshRenderer myRend;
    private bool canBuild = false;
    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Building"||other.tag=="Wall") {
            obj.Add(other.gameObject);
        }
        if (other.tag=="GroundCube") {
            GroundCube gc = other.GetComponent<GroundCube>();
            Cubes.Add(gc);
            gc.Selection();
        }
        ChangeColor();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building" || other.tag == "Wall")
        {
            obj.Remove(other.gameObject);
        }
        if (other.tag == "GroundCube")
        {
            GroundCube gc = other.GetComponent<GroundCube>();
            Cubes.Remove(gc);
            gc.Selection();
        }
        ChangeColor();
    }
    void ChangeColor() {
        if (obj.Count == 0)
        {
            myRend.material = Buildable;
            canBuild = true;
        }
        else {
            myRend.material = UnBuildable;
            canBuild = false;
        }
    }
    public void build() {
        for (int i =0; i<Cubes.Count;i++) {
            Cubes[i].Selection();
        }
        GameObject pre = Instantiate(cubePrefab, transform.position, transform.rotation);
        pre.transform.SetParent(GameObject.FindGameObjectWithTag("playersaved").transform);
        Destroy(gameObject);
    }
    public bool canItBuild() {
        return canBuild;
    }
}
