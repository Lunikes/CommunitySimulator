using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class FirstPersonController : MonoBehaviour
{
    CharacterController TheyHave;
    public float speed = 80f;
    // Start is called before the first frame update
    float y = 0;
    public float Gravity = -10f;
    float pitch = 0;

    public GameObject canvasMM;
    int escapeMenu = 0;

    [Range(5, 15)]
    float mouseSensitivity = 10f;

    [Range(45, 85)]
    float pitchrange = 45f;

    float xInput = 0f;
    float zInput = 0f;

    float xMouse = 0f;
    float yMouse = 0f;

    void Start()
    {
        TheyHave = GetComponent<CharacterController>();

        string path = Application.persistentDataPath + "/Cha.racter";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData data = formatter.Deserialize(stream) as SavedData;
            stream.Close();
        }
    }
    int trial = 0;
    // Update is called once per frame
    void Update()
    {

        GetInput();
        UpdateMovement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerMenu();
        }

    }


    void playerMenu()
    {
        if (escapeMenu == 0)
        {
            canvasMM.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameObject.Find("CameraFps").GetComponent<camerfps>().enabled = false;
            escapeMenu = 1;
        }
        else
        {
            canvasMM.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameObject.Find("CameraFps").GetComponent<camerfps>().enabled = true;
            escapeMenu = 0;
        }
    }



    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        xMouse = Input.GetAxis("Mouse X") * mouseSensitivity;
        yMouse = Input.GetAxis("Mouse Y");
    }
    void UpdateMovement()
    {

        Vector3 move = new Vector3(xInput, 0, zInput);
        move = transform.TransformDirection(move);
        move = Vector3.ClampMagnitude(move, speed);
        move = move * speed;

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
    }
}
