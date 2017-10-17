using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logining : MonoBehaviour {

    // Public
    public Text TextOutput;
    public InputField[] inputs = new InputField[2];
    public Button[] button = new Button[2];

    // private
    private string key, URL;
    private bool w8;
    private int SIN;
    private List<Selectable> selectableObj = new List<Selectable> ();

    void Awake () {
        key = BigMom.GSV.DBKey;
        URL = BigMom.GSV.URL;
        for (int i = 0; i < 2; i++) {
            selectableObj.Add (inputs[i]);
            selectableObj.Add (button[i]);
        }
    }
    void OnEnable () {
        StartCoroutine (Forms ());
        SIN = 0;
    }
    IEnumerator Forms () {
        yield return new WaitUntil (() => inputs[0] != null);
        if (!inputs[0].isFocused) {
            inputs[0].Select ();
        }
    }
    private void LateUpdate () {
        if (Input.GetKeyDown (KeyCode.Tab)) {
            SIN++;
            if (SIN >= selectableObj.Count) {
                SIN = 0;
            }
            EventSystem.current.SetSelectedGameObject (selectableObj[SIN].gameObject);
        }
        if (EventSystem.current.currentSelectedGameObject != selectableObj[SIN].gameObject) {
            if (selectableObj.Find (o => o.gameObject == EventSystem.current.currentSelectedGameObject) == null) {
                EventSystem.current.SetSelectedGameObject (selectableObj[SIN].gameObject);
            } else {
                SIN = selectableObj.FindIndex (o => o.gameObject == EventSystem.current.currentSelectedGameObject);
            }
        }
    }
    public void Auth () {
        if (!string.IsNullOrEmpty (inputs[0].text) && !string.IsNullOrEmpty (inputs[1].text)) {
            if (!w8) {
                StartCoroutine (AuthCall ());
            } else {
                TextOutput.text = "Relax boy w8";
            }
        }else{
            TextOutput.text = "Enter login and password";
        }
    }
    IEnumerator AuthCall () {
        yield return new WaitUntil (() => w8 == false);
        w8 = true;
        WWWForm form = new WWWForm ();
        form.AddField ("email", inputs[0].text);
        form.AddField ("pass", inputs[1].text);
        form.AddField ("secretKeyCode", key);
        WWW w = new WWW (URL + "auth", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            int responce = int.Parse (w.text);
            if (responce > 0) {
                BigMom.GSV.UserID = responce;
                SceneManager.LoadScene ("Tavern Scene", LoadSceneMode.Single);
            }
            if (responce == 0) {
                TextOutput.text = "Wrong Pass";
            }
        } else {
            Debug.Log (w.error);
        }
        w8 = false;
    }

}