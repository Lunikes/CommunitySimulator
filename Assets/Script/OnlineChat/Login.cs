using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject userName;
    public GameObject password;
    private string userNameD;
    private string passwordD;
    private string Decrypt;

    private string[] Lines;

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
        bool Un = false;
        bool Pw = false;

        if (userNameD != "")
        {
            if (System.IO.File.Exists(@"C:/Document/" + userNameD + ".txt"))
            { //anyway change anytime
                Un = true;
                Lines = System.IO.File.ReadAllLines(@"C:/Document/" + userNameD + ".txt");
            }
            else
            {
                Debug.LogWarning("Username Invaild");

            }
        }
        else {
            Debug.LogWarning("Username can not be empty");
        }

        if (passwordD != "")
        {
            if (System.IO.File.Exists(@"C:/Document/" + userNameD + ".txt"))
            {

                int i = 1;
                foreach (char c in Lines[2])
                {
                    i++;
                    char decrypt = (char)(c / i);
                    Decrypt += decrypt.ToString();
                }
                if (passwordD == Decrypt)
                {
                    Pw = true;
                }
                Debug.LogWarning("Wrong password!");
            }
            else {
                Debug.LogWarning("Password invalid!");
            }
        }
        else {
            Debug.LogWarning("Password can not be empty!");
        }
        if (Un=true&&Pw==true) {
            userNameD = userName.GetComponent<InputField>().text="";
            passwordD = password.GetComponent<InputField>().text="";
            print("Login sucess!");
            Application.LoadLevel("CommunityMap");
            //and further 
        }
    }
  
}
