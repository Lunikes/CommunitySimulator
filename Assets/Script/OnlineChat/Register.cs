using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;



public class Register : MonoBehaviour{
    public GameObject userName;
    public GameObject email;
    public GameObject password;
    public GameObject ConfirPassword;

    private string userNameD;
    private string emailD;
    private string passwordD;
    private string ConfirPasswordD;
    private bool EmailValid = false;
    private string form;
    private string[] Characters;//JustIncase
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (passwordD!=""&&emailD!=""&&ConfirPasswordD!=""&&userNameD!="") {
                RegisterButton();
            }
        }

        userNameD = userName.GetComponent<InputField>().text;
        emailD = email.GetComponent<InputField>().text;
        passwordD = password.GetComponent<InputField>().text;
        ConfirPasswordD = ConfirPassword.GetComponent<InputField>().text;
    }
    public void RegisterButton() {
        bool Un = false;
        bool Em = false;
        bool Pw = false;
        bool Cpw = false;

        if (userNameD != "")
        {
            if (!System.IO.File.Exists(@"C:/Document/" + userNameD + ".txt")) //The save location can be change
            {
                Un = true;
            }
            else
            {
                Debug.LogWarning("Username Taken");
            }
        }else {
            Debug.LogWarning("Username can not be empty!");
        }
        if (emailD != "") {
            EmailValidation();
            if (EmailValid)
            {
                if (emailD.Contains("@"))
                {
                    if (emailD.Contains("."))
                    {
                        Em = true;
                    }
                    else {
                        Debug.LogWarning("Email format incorrect!");
                    }
                }
                else {
                    Debug.LogWarning("Email format incorrect!");
                }
            }
            else {
                Debug.LogWarning("Email format incorrect!");
            }

        }
        else {
            Debug.LogWarning("Email can not be empty!");
        }

        if (passwordD != "")
        {
            if (passwordD.Length > 5)
            {
                Pw = true;
            }
            else
            {
                Debug.LogWarning("Password need to me at least 6 characters long");
            }

        }
        else {
            Debug.LogWarning("Password can not be empty!");
        }

        if (ConfirPasswordD != "")
        {
            if (ConfirPasswordD == passwordD)
            {
                Cpw = true;
            }
            else
            {
                Debug.LogWarning("Password must be the same!");
            }
        }
        else {
            Debug.LogWarning("Confirm password can not be empty!");
        }
        if (Un==true&&Em==true&&Pw==true&&Cpw==true) {
            bool Clear = true;
            int i = 1;
            foreach (char c in passwordD) {
                if (Clear) {
                    passwordD = "";
                    Clear = false;
                }
                i++;
                char Encrypt = (char)(c * i);
                passwordD += Encrypt.ToString();
            }
            /*
         So the way we Encrypt it
         For each character times the position it is and than we find the corresponding number and add one to it
         And finally, we find the string character corresponding to the number.
         So for example,if you put and a, it will be a*2 is b, since a is correpsonding to 1.
         */
           
        }
        form = (userNameD + Environment.NewLine + emailD + Environment.NewLine + passwordD);
        System.IO.File.WriteAllText(@"C:/Document/CSPD/" + userNameD + ".txt", form);  //The save location can be change
        userNameD = userName.GetComponent<InputField>().text = "";
        emailD = email.GetComponent<InputField>().text = "";
        passwordD = password.GetComponent<InputField>().text = "";
        ConfirPasswordD = ConfirPassword.GetComponent<InputField>().text = "";
        print("You are all set!");

}
    public void EmailValidation() {
        //JustIncase
    }

}
