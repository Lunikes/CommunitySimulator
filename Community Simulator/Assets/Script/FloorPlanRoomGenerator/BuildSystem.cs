using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Camera camare;
    public LayerMask layer;

    public GameObject fps;
    bool fpsbool = false;

    public BuildSelect selector;

    GameObject previewObj;
    Preview preview;

    bool isBuilding = false;

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

        if (Input.GetButtonDown("Cancel"))
        {
            fpsbool = !fpsbool;
            fps.SetActive(false);
        }
    }
  public void NewBuild(GameObject cube) {
        previewObj = Instantiate(cube, Vector3.zero, Quaternion.identity);
       
        preview = previewObj.GetComponent<Preview>();
        isBuilding = true;
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
