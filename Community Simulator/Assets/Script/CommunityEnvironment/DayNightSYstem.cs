using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DayNightSYstem : MonoBehaviour
{
    public float time;
    public TimeSpan currentTime;
    public Transform SunMovement;
    public Light Sun;
    public Text timeNum;
    public int days;

    public float intensity;
    public Color fogD = Color.grey;
    public Color fogN = Color.black;

    public int speed;
  

    // Update is called once per frame
    void Update()
    {
        ChangeTime();
    }
    public void ChangeTime() {
        time += Time.deltaTime * speed;
        if (time>86400) {
            days += 1;
            time = 0;
        }
        currentTime = TimeSpan.FromSeconds(time);
        string[] tempTime = currentTime.ToString().Split(":"[0]);
        timeNum.text = tempTime[0] + ":" + tempTime[1];

        SunMovement.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 0, 0));
        if (time < 43200) {
            intensity = 1 - (43200 - time) / 43200;
        }
        else {
            intensity = 1 - ((43200 - time) / 43200*-1);

        }
        RenderSettings.fogColor = Color.Lerp(fogN, fogD, intensity * intensity);

        Sun.intensity = intensity;

    }
}
