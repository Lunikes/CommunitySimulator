using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerrotation3d : MonoBehaviour
{
    public float CameraMovingSpeed = 20f;
    public float CameraToTheEdgeOfScreen = 10f;
    public Vector2 Generatorlimits;
    public float zoomSpeed = 1000f;
    void Update()
    {
        Vector3 camPos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - CameraToTheEdgeOfScreen)
        {
            camPos.z += CameraMovingSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= CameraToTheEdgeOfScreen)
        {
            camPos.z -= CameraMovingSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= CameraToTheEdgeOfScreen)
        {
            camPos.x -= CameraMovingSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - CameraToTheEdgeOfScreen)
        {
            camPos.x += CameraMovingSpeed * Time.deltaTime;
        }
        /*
                bool zoomIn = Input.GetKeyDown(KeyCode.Plus);
                bool zoomOut = Input.GetKeyDown(KeyCode.Minus);

                if (zoomIn) {
                    camPos.y += -1 * zoomSpeed * Time.deltaTime;

                }
                if (zoomOut)
                    {
                        camPos.y += 1 * zoomSpeed * Time.deltaTime;
                    }

            */
        /*

            if (RR) {
                camPos.y += -1 * zoomSpeed * Time.deltaTime;

            }
            if (zoomOut)
                {
                    camPos.y += 1 * zoomSpeed * Time.deltaTime;
                }

        */
        float Mousescroll = Input.GetAxis("Mouse ScrollWheel");
        camPos.y += Mousescroll * zoomSpeed * Time.deltaTime;

        camPos.x = Mathf.Clamp(camPos.x, -Generatorlimits.x, Generatorlimits.x);
        camPos.z = Mathf.Clamp(camPos.z, -Generatorlimits.y, Generatorlimits.y);

        transform.position = camPos;
    }

    int cameraTog = 0;
    public void cameraR()
    {

        if (cameraTog == 1)
        {
            transform.Rotate(new Vector​3(-45.0f, 0.0f, 0.0f));
            cameraTog = 0;
        }
        else
        {
            transform.Rotate(new Vector​3(45.0f, 0.0f, 0.0f));
            cameraTog = 1;
        }
    }

}

}
