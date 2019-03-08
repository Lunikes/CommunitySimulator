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
    public GameObject uiDes;
    public GameObject uiWall;

    public BuildSelect selector;

    
    GameObject previewObj;
    float y ;
    float x;
    float z;
    Preview preview;
    Deconstruction deletion;

    int pauser = 0;

    bool isBuilding = false;
    bool fortut = true;
    bool forqwheel = false;

    public WallCreation wallc;

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

        if (Input.GetButtonDown("R"))
        {
            
        }

        if (Input.GetButtonDown("Cancel"))
        {
            fpsbool = !fpsbool;
            fps.SetActive(false);
            CanBeHide.SetActive(true);
            uiToggle.SetActive(true);
            uiWall.SetActive(false);
            uiDes.SetActive(false);
            wallc.enabled = false;
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
        y = previewObj.transform.position.y;
        x = previewObj.transform.position.x;
        z = previewObj.transform.position.z;
        Vector3 realposition = preview.transform.position;
        realposition = Vector3.Lerp(realposition, position, 50f);
        previewObj.transform.position = new Vector3(Mathf.Round(realposition.x), Mathf.Round(realposition.y)+1, Mathf.Round(realposition.z));
    }
    public bool GetIsBuilding() {
        return isBuilding;
    }
    public void enableWallc()
    {
        wallc.enabled = true;
    }


    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }


}
