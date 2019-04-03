using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public GameObject userName;
    public GameObject password;
    private string userNameD;
    private string passwordD;
    private string Decrypt;

    private string[] Lines;
    bool Un = false;
    bool Pw = false;

    string loginURL = "http://127.0.0.1/testdb/login.php";

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (passwordD!=""&&userNameD!="") {
                LoginButton();
            }
        }
        userNameD = userName.GetComponent<InputField>().text;
        passwordD = password.GetComponent<InputField>().text;
    }

    public void LoginButton() {

        int i = 0;
    
        if (passwordD != ""&& userNameD != "")
        {
            StartCoroutine(Checklogin(userNameD, passwordD));
            i++;
           

        }
        else {
            Debug.LogWarning("Username or Passeword can not be empty!");
        }

        if (Un = true && Pw == true)
        {
            userNameD = userName.GetComponent<InputField>().text = "";
            passwordD = password.GetComponent<InputField>().text = "";
            print("Login sucess!");
            Application.LoadLevel("CommunityMap");
            //and further 
        }

        Debug.Log("iiiiii" + i);
    }

    IEnumerator Checklogin(string username, string userpassword)
    {
        
        WWWForm uploadform = new WWWForm();
        uploadform.AddField("usernamePost", username);
        
        uploadform.AddField("userpasswordPost", userpassword);
        Debug.Log("PPPPPPPPPPPPPP" + userpassword);

        UnityWebRequest www = UnityWebRequest.Post(loginURL, uploadform);
        www.chunkedTransfer = false;
        yield return www.SendWebRequest();


        
            //Debug.Log("Form upload complete!");
            //Debug.Log("WWWForm: " + www.downloadHandler.text);
            if (www.downloadHandler.text == "login success")
            { Pw = true;
              Un = true;
            }
        
    }

}

  

