using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class authDBCon : MonoBehaviour {

    bool complete = false;
    // Obj
    Image imLogin, imEmail, imPass, imRePass;
    InputField inputLogin, inputEmail, inputPass, inputRePass;
    Button Login, toRegister, Register, toLogin;
    bool bLogin, bEmail, bPass, bRePass;
    Text output;
    // private
    private int i;
    private WWW w;
    private EventSystem system;
    private string key, URL;
    void Awake () {
        key = BigMom.GSV.DBKey;
        URL = BigMom.GSV.URL;
        output = this.transform.parent.Find ("Others/return").GetComponent<Text> ();
        inputLogin = this.transform.Find ("input/login").GetComponent<InputField> ();
        inputPass = this.transform.Find ("input/password").GetComponent<InputField> ();
        if (this.name == "RegisterForm") {
            inputEmail = this.transform.Find ("input/email").GetComponent<InputField> ();
            inputRePass = this.transform.Find ("input/repassword").GetComponent<InputField> ();
            imLogin = this.transform.Find ("input/login/Image").GetComponentInChildren<Image> ();
            imEmail = this.transform.Find ("input/email/Image").GetComponentInChildren<Image> ();
            imPass = this.transform.Find ("input/password/Image").GetComponentInChildren<Image> ();
            imRePass = this.transform.Find ("input/repassword/Image").GetComponentInChildren<Image> ();
            Register = this.transform.Find ("buttons/Register").GetComponent<Button> ();
            toLogin = this.transform.Find ("buttons/toLogin").GetComponent<Button> ();
        }
        if (this.name == "LoginForm") {
            Login = this.transform.Find ("buttons/Login").GetComponent<Button> ();
            toRegister = this.transform.Find ("buttons/toRegister").GetComponent<Button> ();
        }

    }
    private void Update () {
        if (Input.GetKeyDown (KeyCode.Tab)) {
            i++;
            if (i >= Selectable.allSelectables.Count) {
                i = 0;
            }
            EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[i].gameObject);
        }
        if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) {
            if (EventSystem.current.currentSelectedGameObject.transform.parent.name == "input") {
                i++;
                if (i >= EventSystem.current.currentSelectedGameObject.transform.parent.childCount) {
                    // EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[i].gameObject);
                    i = 0;
                }
                EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[i].gameObject);
            }
            // if(Input.GetKey(KeyCode.Return)){

            // }
            // if(Selectable.allSelectables.){}
            // if (!(Selectable.allSelectables[Selectable.allSelectables.Count - 1].IsActive () || Selectable.allSelectables[Selectable.allSelectables.Count - 2].IsActive ())) {
            //     Debug.Log ("dssadsa");
            // }
            // EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[i].gameObject);
        }
    }
    void OnEnable () {
        StartCoroutine (Forms ());
        i = 0;
    }
    void Start () {
        if (this.name == "RegisterForm") {
            inputLogin.onEndEdit.AddListener (delegate { pLoginCheck (); });
            inputEmail.onEndEdit.AddListener (delegate { pEmailCheck (); });
            inputPass.onEndEdit.AddListener (delegate { PasswordCheck (); });
            inputRePass.onEndEdit.AddListener (delegate { RePasswordCheck (); });
        }
    }

    IEnumerator Forms () {
        yield return new WaitUntil (() => inputLogin != null);
        if (this.name == "RegisterForm") {
            yield return new WaitUntil (() => inputEmail && inputPass && inputRePass != null);
            Selectable.allSelectables.Clear ();
            Selectable.allSelectables.Add (inputLogin);
            Selectable.allSelectables.Add (inputEmail);
            Selectable.allSelectables.Add (inputPass);
            Selectable.allSelectables.Add (inputRePass);
            Selectable.allSelectables.Add (Register);
            Selectable.allSelectables.Add (toLogin);
            if (!inputLogin.isFocused) {
                inputLogin.Select ();
            }
        }
        if (this.name == "LoginForm") {
            Selectable.allSelectables.Clear ();
            Selectable.allSelectables.Add (inputLogin);
            Selectable.allSelectables.Add (inputPass);
            Selectable.allSelectables.Add (Login);
            Selectable.allSelectables.Add (toRegister);
            if (!inputLogin.isFocused) {
                inputLogin.Select ();
            }
        }
    }
    public void pLogin () {

        StartCoroutine (login ());
    }
    public void pRegister () {
        if (bEmail && bLogin && bPass && bRePass) {
            StartCoroutine (register ());
        }
    }
    void pEmailCheck () {
        if (!string.IsNullOrEmpty (inputEmail.text) && inputEmail.text.Length >= 4) {
            StartCoroutine (emailCheck ());
        }
    }
    void pLoginCheck () {
        if (!string.IsNullOrEmpty (inputLogin.text) && inputLogin.text.Length >= 4) {
            StartCoroutine (loginCheck ());
        }
    }
    void PasswordCheck () {

    }
    void RePasswordCheck () {
        if (inputPass.text == inputRePass.text) {
            imRePass.color = Color.green;
        } else {
            imRePass.color = Color.red;
        }
    }
    IEnumerator login () {
        WWWForm form = new WWWForm ();
        form.AddField ("email", inputLogin.text);
        form.AddField ("pass", inputPass.text);
        requst ("auth", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            int responce = new int ();
            responce = int.Parse (w.text);
            if (responce > 0) {
                BigMom.GSV.UserID = responce;
            }
            if (responce == 0) {
                output.text = "Wrong Pass";
            }
        } else {
            Debug.Log (w.error);
        }
    }

    IEnumerator register () {
        WWWForm form = new WWWForm ();
        form.AddField ("login", inputLogin.text);
        form.AddField ("email", inputEmail.text);
        form.AddField ("pass", inputPass.text);
        requst ("reg", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            int responce = new int ();
            responce = int.Parse (w.text);
            if (responce > 0) {
                // Debug.Log ("УРА!");
                output.text = "Logging in";
            }
            if (responce == 0) {
                output.text = "Error";
                // Debug.Log ("none");
            }
        } else {
            Debug.Log (w.error);
        }
    }
    public IEnumerator emailCheck () {
        WWWForm form = new WWWForm ();
        form.AddField ("email", inputEmail.text);
        requst ("emailCheck", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            int responce = new int ();
            responce = int.Parse (w.text);
            if (responce == 1) {
                // Debug.Log ("Free!");
                bEmail = true;
                imEmail.color = Color.green;
            }
            if (responce == 0) {
                output.text = "Email already exists!";
                // Debug.Log ("Already exists!");
            }
        } else {
            Debug.Log (w.error);
        }
    }
    public IEnumerator loginCheck () {
        WWWForm form = new WWWForm ();
        form.AddField ("login", inputLogin.text);
        requst ("loginCheck", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            int responce = new int ();
            responce = int.Parse (w.text);
            if (responce == 1) {
                // Debug.Log ("Free!");
                bLogin = true;
                imLogin.color = Color.green;
            }
            if (responce == 0) {
                // Debug.Log ("Already exists!");
                output.text = "User already exists!";
            }
        } else {
            Debug.Log (w.error);
        }
    }
    private void requst (string addr, WWWForm form) {
        form.AddField ("secretKeyCode", key);
        w = new WWW (URL + addr, form);
    }
}