using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    CharacterController TheyHave;
    public float speed;
    // Start is called before the first frame update
    float y = 0;
    public float Gravity = -10f;
    public Transform camera;
    float pitch = 0;

    [Range(5, 15)]
    float mouseSensitivity = 10f;

    [Range(45, 85)]
    float pitchrange = 45f;

    float xInput = 0f;
    float zInput = 0f;

    float xMouse = 0f;
    float yMouse = 0f;

    Camera fpsCam;


    public Transform doorL;
    public playerInteraction focus;

    void Start()
    {
        fpsCam = GetComponent<Camera>();
        TheyHave = GetComponent<CharacterController>();
    }
    int trial = 0;
    // Update is called once per frame
    void Update()
    {
        
        GetInput();
        UpdateMovement();
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("I'm looking at " + hit.transform.name);
            if(hit.transform.name == "Door.L" && trial ==0)
            {
                Debug.Log("Open Door");
                doorL.Rotate(0.0f,90.0f,0.0f);
                trial = 1;
            }
        }
        else
        {
            Debug.Log("I'm looking at nothing!");
        }
    }


    void GetInput() {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        xMouse = Input.GetAxis("Mouse X") * mouseSensitivity;
        yMouse = Input.GetAxis("Mouse Y");
    }
    void UpdateMovement() {

        Vector3 move = new Vector3(xInput, 0, zInput);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        if (TheyHave.isGrounded)//this function will be disable after the roof test
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
        else
        {
            y += Gravity * Time.deltaTime;
        }

        TheyHave.Move((move + new Vector3(0, y, 0)) * Time.deltaTime);
      
        //transform.Rotate(0, xMouse, 0);


        // pitch -= yMouse;
        //  pitch = Mathf.Clamp(pitch, -pitchrange, pitchrange);
        //   Quaternion cameraRotation = Quaternion.Euler(pitch, 0, 0);
        //   camera.localRotation = cameraRotation;
    }
}
