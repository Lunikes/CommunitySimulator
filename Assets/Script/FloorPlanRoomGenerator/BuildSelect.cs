using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSelect : MonoBehaviour
{
    public GameObject buildPanel;
    public BuildSystem buildsystem;
    bool showPanel = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startBuild(GameObject cube) {
        buildsystem.NewBuild(cube);
        SwitchOnOffPanel();   
            }
    public void SwitchOnOffPanel() {
        showPanel = !showPanel;
      //  buildPanel.SetActive(showPanel);
    }
}
