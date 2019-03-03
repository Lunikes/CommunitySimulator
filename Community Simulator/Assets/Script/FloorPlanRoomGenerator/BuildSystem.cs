using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Camera camare;
    public LayerMask layer;

    public GameObject fps;
    bool fpsbool = false;


    public GameObject uiwheel;
    public GameObject CanBeHidefps;
    public GameObject CanBeHide;
    public GameObject uiToggle;

    public BuildSelect selector;

    GameObject previewObj;
    Preview preview;
    Deconstruction deletion;

    int pauser = 0;

    bool isBuilding = false;
    bool fortut = true;
    bool forqwheel = false;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0)&&isBuilding&&preview.canItBuild()) {
            Build();
        }
        if (Input.GetMouseButtonDown(1)&&isBuilding) {
            StopBuild();
        }
        if (Input.GetKeyDown(KeyCode.R)&&isBuilding) {
            preview.transform.Rotate(0, 45f, 0);
        }
        if (isBuilding) {
            Ray();
        }

        if (Input.GetButtonDown("o"))
        {
            float rotateX = Random.Range(0, 50);
            transform.eulerAngles = new Vector3(0, 0, rotateX);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            fpsbool = !fpsbool;
            fps.SetActive(false);
            CanBeHidefps.SetActive(false);
            CanBeHide.SetActive(true);
            uiToggle.SetActive(true);
        }
        if (Input.GetButtonDown("t"))
        {
            fortut = !fortut;
            CanBeHidefps.SetActive(fortut);
        }
        if (Input.GetButtonDown("p"))
        {
            pauseFun();
        }
        if (Input.GetButtonDown("q"))
        {
            forqwheel = !forqwheel;
            uiwheel.SetActive(forqwheel);
        }
    }
  public void NewBuild(GameObject cube) {
        previewObj = Instantiate(cube, Vector3.zero, Quaternion.identity);
       
        preview = previewObj.GetComponent<Preview>();
        isBuilding = true;
    }

    public void pauseFun()
    {
        if (pauser == 0)
        {
            Time.timeScale = 0;
            pauser = 1;
        }
        else
        {
            Time.timeScale = 1;
            pauser = 0;
        }

    }

    void StopBuild() {
        Destroy(previewObj);
        preview = null;
        previewObj = null;
        isBuilding = false;
        selector.SwitchOnOffPanel();
    }
    void Build() {
        preview.build();
        StopBuild();
    }
    public void switchFpsModelOn()
    {
        fpsbool = !fpsbool;
        fps.SetActive(true);
        CanBeHidefps.SetActive(true);
        CanBeHide.SetActive(false);
        uiToggle.SetActive(false);

    }
 
    public void BuildCharacter(GameObject cube) {
        previewObj = Instantiate(cube, Vector3.zero, Quaternion.identity);

        preview = previewObj.GetComponent<Preview>();
        isBuilding = true;

    }
    void Ray() {
        Ray ray = camare.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layer))
        {
            PositionObj(hit.point);
        }
    }
    void PositionObj(Vector3 position) {
        Vector3 realposition = preview.transform.position;
        realposition = Vector3.Lerp(realposition, position, 50f);
        previewObj.transform.position = new Vector3(Mathf.Round(realposition.x), Mathf.Round(realposition.y)+1, Mathf.Round(realposition.z));
    }
    public bool GetIsBuilding() {
        return isBuilding;
    }
   
   
}
