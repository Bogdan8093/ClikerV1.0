using System.Collections;
using System.Collections.Generic;
using LitJson;
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
    private bool w8;
    private int SIN;
    private List<Selectable> selectableObj = new List<Selectable>();

    void Awake() {
        for (int i = 0; i < inputs.Length; i++) {
            selectableObj.Add(inputs[i]);

        }
        for (int i = 0; i < button.Length; i++) {
            selectableObj.Add(button[i]);
        }

    }
    void OnEnable() {
        StartCoroutine(Forms());
        SIN = 0;
    }
    IEnumerator Forms() {
        yield return new WaitUntil(() => inputs[0] != null);
        if (!inputs[0].isFocused) {
            inputs[0].Select();
        }
    }
    private void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            SIN++;
            if (SIN >= selectableObj.Count) {
                SIN = 0;
            }
            EventSystem.current.SetSelectedGameObject(selectableObj[SIN].gameObject);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<InputField>() != null) {
                if (selectableObj[SIN + 1].GetType() == typeof(Button)) {
                    if (!(string.IsNullOrEmpty(inputs[0].text) && string.IsNullOrEmpty(inputs[1].text)))
                        StartCoroutine(AuthCall());
                    EventSystem.current.SetSelectedGameObject(button[0].gameObject);
                    EventSystem.current.SetSelectedGameObject(inputs[1].gameObject);
                } else {
                    SIN += 1;
                    EventSystem.current.SetSelectedGameObject(selectableObj[SIN].gameObject);
                }
            }
        }
        if (EventSystem.current.currentSelectedGameObject != selectableObj[SIN].gameObject) {
            if (selectableObj.Find(o => o.gameObject == EventSystem.current.currentSelectedGameObject) == null) {
                EventSystem.current.SetSelectedGameObject(selectableObj[SIN].gameObject);
            } else {
                SIN = selectableObj.FindIndex(o => o.gameObject == EventSystem.current.currentSelectedGameObject);
            }
        }
    }
    public void Auth() {
        if (!string.IsNullOrEmpty(inputs[0].text) && !string.IsNullOrEmpty(inputs[1].text)) {
            if (!w8) {
                StartCoroutine(AuthCall());
            } else {
                TextOutput.text = "Relax boy w8";
            }
        } else {
            TextOutput.text = "Enter login and password";
        }
    }
    IEnumerator AuthCall() {
        yield return new WaitUntil(() => w8 == false);
        w8 = true;
        WWWForm form = new WWWForm();
        form.AddField("email", inputs[0].text);
        form.AddField("password", inputs[1].text);
        form.AddField("id", BigMom.GSV.SecretID);
        form.AddField("secret", BigMom.GSV.SecretKey);
        WWW w = new WWW(BigMom.GSV.URL + "login", form);
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            BigMom.GSV.Auth = JsonMapper.ToObject(w.text);
            SceneManager.LoadScene("Tavern Scene", LoadSceneMode.Single);
        } else {
            Debug.Log(w.error);
        }
        w8 = false;
    }

}