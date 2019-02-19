using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    CharacterController TheyHave;
    public float speed = 5f;
    // Start is called before the first frame update
    float y = 0;
    public float Gravity = -10f;
    public Transform camera;
    float pitch = 0;

    [Range(5, 15)]
    float mouseSensitivity = 10f;

    [Range(45, 85)]
    float pitchrange = 45f;

   
    void Start()
    {

        TheyHave = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name=="CameraTwo") {
          
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        if (TheyHave.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                y = 10f;
            }
            else
            {
                y = Gravity * Time.deltaTime;
            }
        }
        else {
            y += Gravity * Time.deltaTime;
        }

        TheyHave.Move((move + new Vector3(0, y, 0)) * Time.deltaTime);
        float xMouse = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0,xMouse,0);
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -pitchrange, pitchrange);
        Quaternion cameraRotation = Quaternion.Euler(pitch, 0, 0);
        camera.localRotation = cameraRotation;
    }
}
