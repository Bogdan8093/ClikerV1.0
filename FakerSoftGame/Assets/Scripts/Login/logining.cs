using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logining : MonoBehaviour {

    // Public
    public Text TextOutput;
    public InputField[] inputs = new InputField[2];
    public Button[] button = new Button[2];

    // private
    private string key, URL;
    private bool w8;
    private int SelectedItemNumber;

    void Awake () {
        key = BigMom.GSV.DBKey;
        URL = BigMom.GSV.URL;
    }
    void OnEnable () {
        StartCoroutine (Forms ());
        SelectedItemNumber = 0;
    }
    IEnumerator Forms () {
        yield return new WaitUntil (() => button[1] != null);
        Selectable.allSelectables.Clear ();
        Selectable.allSelectables.Add (inputs[0]);
        Selectable.allSelectables.Add (inputs[1]);
        Selectable.allSelectables.Add (button[0]);
        Selectable.allSelectables.Add (button[1]);
        if (!inputs[0].isFocused) {
            inputs[0].Select ();
        }
    }
    private void Update () {
        if (Input.GetKeyDown (KeyCode.Tab)) {
            if (Selectable.allSelectables.Find (o => o.gameObject == EventSystem.current.currentSelectedGameObject) != null) {
                if (EventSystem.current.currentSelectedGameObject.GetComponent<InputField> () != null) {
                    SelectedItemNumber = Selectable.allSelectables.FindIndex (o => o.gameObject == EventSystem.current.currentSelectedGameObject);
                }
                SelectedItemNumber++;
                if (SelectedItemNumber >= Selectable.allSelectables.Count) {
                    SelectedItemNumber = 0;
                }
                EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[SelectedItemNumber].gameObject);
            } else {
                SelectedItemNumber = 0;
                EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[0].gameObject);
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
                SceneManager.LoadScene("Tavern Scene", LoadSceneMode.Single);
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