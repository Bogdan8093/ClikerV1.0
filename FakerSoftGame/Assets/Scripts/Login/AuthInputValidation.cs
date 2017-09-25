using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class AuthInputValidation : MonoBehaviour {
    public registeration regFull;
    [HideInInspector]
    public Text output;

    void Start () {
        output = regFull.TextOutput;
    }
    public void ValidateLogin () {
        string login = regFull.inputs[0].text;
        switch (LoginCheck (login)) {
            case 4:
                output.text = null;
                regFull.img[0].sprite = regFull.checkBox[0];
                break;
            case 3:
                output.text = "Login must be more than 4";
                regFull.img[0].sprite = regFull.checkBox[1];
                break;
            case 2:
                output.text = "Login Less than 26";
                regFull.img[0].sprite = regFull.checkBox[1];
                break;
            case 1:
                StartCoroutine (regFull.LoginCheck (login));
                break;
        }
    }
    private int LoginCheck (string login) {
        if (!string.IsNullOrEmpty (login)) {
            if (login.Length > 3) {
                if (login.Length < 26) {
                    return 1;
                } else {
                    return 2;
                }
            } else {
                return 3;
            }
        } else {
            return 4;
        }
    }
    public void ValidateEmail () {
        string email = regFull.inputs[1].text;
        switch (EmailCheck (email)) {
            case 3:
                output.text = null;
                regFull.img[1].sprite = regFull.checkBox[0];
                break;
            case 2:
                output.text = "Enter valid email";
                regFull.img[1].sprite = regFull.checkBox[1];
                break;
            case 1:
                StartCoroutine (regFull.emailCheck (email));
                break;
        }
    }
    private int EmailCheck (string email) {
        if (!string.IsNullOrEmpty (email)) {
            if (email.Length < 50 && email.LastIndexOf ("@") > 1) {
                string fEmail = email.Substring ((email.LastIndexOf ("@") + 1));
                if (fEmail.LastIndexOf (".") > 1 &&
                    fEmail.Substring (fEmail.LastIndexOf (".")).Length > 2) {
                    return 1;
                } else {
                    return 2;
                }
            } else {
                return 2;
            }
        } else {
            return 3;
        }
    }
    public void ValidatePass () {
        string pass = regFull.inputs[2].text;
        switch (PassCheck (pass)) {
            case 5:
                regFull.TextOutput.text = null;
                if (regFull.passImg.enabled) {
                    regFull.passImg.enabled = false;
                }
                regFull.img[2].sprite = regFull.checkBox[0];
                regFull.confirm[2] = false;
                break;
            case 4:
                regFull.TextOutput.text = "Password too short";
                regFull.img[2].sprite = regFull.checkBox[1];
                passImg ();
                regFull.confirm[2] = false;
                break;
            case 3:
                regFull.TextOutput.text = "Password too long";
                regFull.img[2].sprite = regFull.checkBox[1];
                passImg ();
                regFull.confirm[2] = false;
                break;
            case 2:
                regFull.TextOutput.text = null;
                regFull.passImg.sprite = regFull.securityBox[1];
                regFull.passImg.color = Color.yellow;
                regFull.img[2].sprite = regFull.checkBox[2];
                regFull.confirm[2] = true;
                break;
            case 1:
                regFull.TextOutput.text = null;
                regFull.passImg.sprite = regFull.securityBox[2];
                regFull.passImg.color = Color.green;
                regFull.img[2].sprite = regFull.checkBox[2];
                regFull.confirm[2] = true;
                break;
        }
    }
    private int PassCheck (string pass) {
        if (!string.IsNullOrEmpty (pass)) {
            if (pass.Length >= 6) {
                if (pass.Length < 25) {
                    if (pass.Length >= 8 && Regex.Match (pass, @"\d+").Success && Regex.Match (pass, @"\D+").Success) {
                        return 1;
                    } else {
                        return 2;
                    }
                } else {
                    return 3;
                }
            } else {
                return 4;
            }
        } else {
            return 5;
        }
    }
    void passImg () {
        if (!regFull.passImg.enabled) {
            regFull.passImg.color = Color.red;
            regFull.passImg.enabled = true;
        }
    }
    public void ValidateRePass(){
        string pass = regFull.inputs[2].text;
        string repass = regFull.inputs[3].text;
        if(pass == repass && pass.Length >=6 && pass.Length<25){
            output.text = null;
            regFull.img[3].sprite = regFull.checkBox[2];
            regFull.confirm[3] = true;
        }else{
            output.text = "Passwords do not match";
            regFull.img[3].sprite = regFull.checkBox[1];
            regFull.confirm[3] = false;
        }
    }
}