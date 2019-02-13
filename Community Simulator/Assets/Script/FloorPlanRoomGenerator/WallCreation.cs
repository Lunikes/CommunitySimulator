using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreation : MonoBehaviour
{
    public Camera camare;
    public GameObject startPole;
    public GameObject endPole;
    public GameObject wallPrefab;
    private GameObject wall;
    bool creates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }
    void getInput() {
        if (Input.GetMouseButtonDown(0)) {
            createStart();
        } else if (Input.GetMouseButtonUp(0)) {
            createEnd();
        }
        else{
            if (creates) {
                adjust();
            }
        }
    }
    void createStart() {
        creates = true;
        startPole.transform.position = getPosition();
        wall = Instantiate(wallPrefab, startPole.transform.position, Quaternion.identity);

    }
    void createEnd() {
        creates = false;
        endPole.transform.position = getPosition();
    }
    void adjust() {
        endPole.transform.position = getPosition();
        adjustwall();
    }
    void adjustwall() {
        startPole.transform.LookAt(endPole.transform.position);
        endPole.transform.LookAt(startPole.transform.position);
        float distanceBetweenPole = Vector3.Distance(startPole.transform.position, endPole.transform.position);
        wall.transform.position = startPole.transform.position + distanceBetweenPole/2 *startPole.transform.forward;
        wall.transform.rotation = startPole.transform.rotation;
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, distanceBetweenPole);
    }

    Vector3 getPosition() {
        Ray ray = camare.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            return hit.point;
        }
        return Vector3.zero;
    }
}
