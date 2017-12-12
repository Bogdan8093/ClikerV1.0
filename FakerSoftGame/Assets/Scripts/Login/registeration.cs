using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class registeration : MonoBehaviour {
    //public
    public Text TextOutput;
    public InputField[] inputs = new InputField[4];
    public Button[] button = new Button[2];

    // Hidden (Auto incresment)
    [HideInInspector]
    public Image[] img = new Image[5];
    [HideInInspector]
    public Image passImg;
    [HideInInspector]
    public Sprite[] checkBox, securityBox;
    [HideInInspector]
    public bool[] confirm = new bool[4];

    //  Private
    private string URL;
    private bool w8;
    private int SIN; // SelectedItemNumber
    private Sprite loadingSprite;
    private List<Selectable> selectableObj = new List<Selectable>();
    private Color[] buttonColors;
    // AIV
    AuthInputValidation AIV;

    void Awake() {
        URL = BigMom.GSV.URL;
        loadingSprite = Resources.Load<Sprite>("auth/loading1");
        checkBox = Resources.LoadAll<Sprite>("auth/checkBox/checkBox");
        securityBox = Resources.LoadAll<Sprite>("auth/checkBox/securityBox");
        for (int i = 0; i < inputs.Length; i++) {
            img[i] = inputs[i].GetComponentsInChildren<Image>()[1];
            selectableObj.Add(inputs[i]);
        }
        passImg = inputs[2].GetComponentsInChildren<Image>()[2];
        selectableObj.Add(button[0]);
        selectableObj.Add(button[1]);
        // buttonColors[0] = button[0].colors.normalColor;
        // buttonColors[1] = button[0].colors.pressedColor;
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
    // void test(Selectable dsa){}
    void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            SIN++;
            if (SIN >= selectableObj.Count) {
                SIN = 0;
            }
            EventSystem.current.SetSelectedGameObject(selectableObj[SIN].gameObject);
        }
        // /*
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<InputField>() != null) {
                if (selectableObj[SIN + 1].GetType() == typeof(Button)) {
                    reg();
                    EventSystem.current.SetSelectedGameObject(button[0].gameObject);
                    EventSystem.current.SetSelectedGameObject(inputs[3].gameObject);
                } else {
                    SIN += 1;
                    EventSystem.current.SetSelectedGameObject(selectableObj[SIN].gameObject);
                }
            }
        }
        // */
        // нетрогай норм пашет )
        if (EventSystem.current.currentSelectedGameObject != selectableObj[SIN].gameObject) {
            if (selectableObj.Find(o => o.gameObject == EventSystem.current.currentSelectedGameObject) == null) {
                EventSystem.current.SetSelectedGameObject(selectableObj[SIN].gameObject);
            } else {
                SIN = selectableObj.FindIndex(o => o.gameObject == EventSystem.current.currentSelectedGameObject);
            }
        }
    }
    public IEnumerator LoginCheck(string login) {
        yield return new WaitUntil(() => w8 == false);
        StartCoroutine(loading(0));
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        WWW w = requst("check_login", form);
        yield return new WaitUntil(() => w.isDone == true);
        w8 = false;
        if (string.IsNullOrEmpty(w.error)) {
            int responce = int.Parse(w.text);
            if (responce == 1) {
                yield return new WaitUntil(() => img[0].transform.rotation.z == 0);
                TextOutput.text = null;
                img[0].sprite = checkBox[2];
                confirm[0] = true;
            }
            if (responce == 0) {
                yield return new WaitUntil(() => img[0].transform.rotation.z == 0);
                TextOutput.text = "User already exists!";
                img[0].sprite = checkBox[1];
                confirm[0] = false;
            }
        } else {
            Debug.Log(w.error);
            confirm[0] = false;
            TextOutput.text = null;
        }
    }
    public IEnumerator emailCheck(string email) {
        yield return new WaitUntil(() => w8 == false);
        StartCoroutine(loading(1));
        TextOutput.text = "Connecting please wait ";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        WWW w = requst("check_email", form);
        yield return new WaitUntil(() => w.isDone == true);
        w8 = false;
        if (string.IsNullOrEmpty(w.error)) {
            int responce = int.Parse(w.text);
            if (responce == 1) {
                TextOutput.text = null;
                confirm[1] = true;
                yield return new WaitUntil(() => img[1].transform.rotation.z == 0);
                img[1].sprite = checkBox[2];
            }
            if (responce == 0) {
                TextOutput.text = "Email already exists!";
                confirm[1] = false;
                yield return new WaitUntil(() => img[1].transform.rotation.z == 0);
                img[1].sprite = checkBox[1];
            }
        } else {
            Debug.Log(w.error);
            confirm[1] = false;
            TextOutput.text = null;
        }
    }
    IEnumerator Register() {
        TextOutput.text = "Connection please wait";
        foreach (Selectable item in selectableObj) {
            item.interactable = false;
        }
        yield return new WaitUntil(() => w8 == false);
        w8 = true;
        WWWForm form = new WWWForm();
        form.AddField("name", inputs[0].text);
        form.AddField("email", inputs[1].text);
        form.AddField("password", inputs[3].text);
        WWW w = requst("register", form);
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            BigMom.GSV.Auth = JsonMapper.ToObject(w.text);
            SceneManager.LoadScene("Tavern Scene", LoadSceneMode.Single);
        } else {
            Debug.Log(w.error);
            Debug.Log(w.text);
        }
        w8 = false;
        foreach (Selectable item in selectableObj) {
            item.interactable = true;
        }
    }
    public void reg() {
        if (!w8) {
            if (confirm[0]) {
                if (confirm[1]) {
                    if (confirm[2]) {
                        if (confirm[3]) {
                            StartCoroutine(Register());
                        } else { EventSystem.current.SetSelectedGameObject(inputs[3].gameObject); }
                    } else { EventSystem.current.SetSelectedGameObject(inputs[2].gameObject); }
                } else { EventSystem.current.SetSelectedGameObject(inputs[1].gameObject); }
            } else { EventSystem.current.SetSelectedGameObject(inputs[0].gameObject); }
        } else {
            TextOutput.text = "Relax boy w8";
        }
    }
    public void ResetFields() {
        foreach (InputField item in inputs) {
            item.text = null;
        }
        TextOutput.text = null;
    }
    IEnumerator loading(int InputField) {
        w8 = true;
        img[InputField].sprite = loadingSprite;
        img[InputField].color = Color.grey;
        float z = Random.Range(-180f, 180f);
        while (w8) {

            img[InputField].transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            z -= 25;
            yield return new WaitForSeconds(0);
        }
        img[InputField].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        img[InputField].color = Color.white;
    }
    private WWW requst(string addr, WWWForm form) {
        WWW requst = new WWW(URL + addr, form);
        return requst;
    }
}