using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Camera camare;
    public LayerMask layer;

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
    void Ray() {
        Ray ray = camare.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layer))
        {
            PositionObj(hit.point);
        }
    }
    void PositionObj(Vector3 position) {
        float x = Mathf.RoundToInt(position.x);
        float z = Mathf.RoundToInt(position.z);
        float y = Mathf.RoundToInt(position.y+1);

        previewObj.transform.position = new Vector3(x, y, z);
    }
    public bool GetIsBuilding() {
        return isBuilding;
    }
}
