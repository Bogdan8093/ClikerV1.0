using System.Collections;
using System.Collections.Generic;
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
    private string key, URL;
    private bool w8;
    private int SIN; // SelectedItemNumber
    private Sprite loadingSprite;
    // AIV
    AuthInputValidation AIV;

    void Awake () {
        key = BigMom.GSV.DBKey;
        URL = BigMom.GSV.URL;
        loadingSprite = Resources.Load<Sprite> ("auth/loading1");
        checkBox = Resources.LoadAll<Sprite> ("auth/checkBox/checkBox");
        securityBox = Resources.LoadAll<Sprite> ("auth/checkBox/securityBox");
        for (int i = 0; i < inputs.Length; i++) {
            img[i] = inputs[i].GetComponentsInChildren<Image> ()[1];
        }
        passImg = inputs[2].GetComponentsInChildren<Image> ()[2];
    }
    void OnEnable () {
        StartCoroutine (Forms ());
        SIN = 0;
    }
    IEnumerator Forms () {
        yield return new WaitUntil (() => button[1] != null);
        Selectable.allSelectables.Clear ();
        Selectable.allSelectables.Add (inputs[0]);
        Selectable.allSelectables.Add (inputs[1]);
        Selectable.allSelectables.Add (inputs[2]);
        Selectable.allSelectables.Add (inputs[3]);
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
                    SIN = Selectable.allSelectables.FindIndex (o => o.gameObject == EventSystem.current.currentSelectedGameObject);
                }
                SIN++;
                if (SIN >= Selectable.allSelectables.Count) {
                    SIN = 0;
                }
                EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[SIN].gameObject);
            } else {
                // button[1].OnSubmit(null);
                SIN = 0;
                EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[SIN].gameObject);
            }
        }
        /* 
        if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return)) {
            if (Selectable.allSelectables.Find (o => o.gameObject == EventSystem.current.currentSelectedGameObject) != null) {
                // если в выбранном елементе инпутфилд
                if (EventSystem.current.currentSelectedGameObject.GetComponent<InputField> () != null) {
                    SIN = Selectable.allSelectables.FindIndex (o => o.gameObject == EventSystem.current.currentSelectedGameObject);
                    // если следующий выбранный елемент имеет тип баттон
                    if (Selectable.allSelectables[SIN + 1].GetType () == typeof (Button)) {
                        // spriteState
                        // button[0].transition.SpriteSwap;
                        Debug.Log(EventSystem.current.currentInputModule);
                        //  = button[0].spriteState.pressedSprite; 
                        reg();
                        // EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[SelectedItemNumber].gameObject);
                    } else {
                        SIN += 1;
                        EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[SIN].gameObject);
                    }
                }
            } else {
                SIN = 0;
                EventSystem.current.SetSelectedGameObject (Selectable.allSelectables[SIN].gameObject);
            }
        }
        if (Input.GetKeyUp (KeyCode.KeypadEnter) || Input.GetKeyUp (KeyCode.Return)) {
            if (Selectable.allSelectables.Find (o => o.gameObject == EventSystem.current.currentSelectedGameObject) != null) {
                if (Selectable.allSelectables[SIN + 1].GetType () == typeof (Button)) {
                    // spriteState
                    // button[0].image.color = Color.white;
                }
            }
        }
        // */
    }
    public IEnumerator LoginCheck (string login) {
        yield return new WaitUntil (() => w8 == false);
        StartCoroutine (loading (0));
        WWWForm form = new WWWForm ();
        form.AddField ("login", login);
        WWW w = requst ("loginCheck", form);
        yield return new WaitUntil (() => w.isDone == true);
        w8 = false;
        if (string.IsNullOrEmpty (w.error)) {
            int responce = int.Parse (w.text);
            if (responce == 1) {
                yield return new WaitUntil (() => img[0].transform.rotation.z == 0);
                TextOutput.text = null;
                img[0].sprite = checkBox[2];
                confirm[0] = true;
            }
            if (responce == 0) {
                yield return new WaitUntil (() => img[0].transform.rotation.z == 0);
                TextOutput.text = "User already exists!";
                img[0].sprite = checkBox[1];
                confirm[0] = false;
            }
        } else {
            Debug.Log (w.error);
            confirm[0] = false;
            TextOutput.text = null;
        }
    }
    public IEnumerator emailCheck (string email) {
        yield return new WaitUntil (() => w8 == false);
        StartCoroutine (loading (1));
        TextOutput.text = "Connecting please wait ";
        WWWForm form = new WWWForm ();
        form.AddField ("email", email);
        WWW w = requst ("emailCheck", form);
        yield return new WaitUntil (() => w.isDone == true);
        w8 = false;
        if (string.IsNullOrEmpty (w.error)) {
            int responce = int.Parse (w.text);
            if (responce == 1) {
                TextOutput.text = null;
                confirm[1] = true;
                yield return new WaitUntil (() => img[1].transform.rotation.z == 0);
                img[1].sprite = checkBox[2];
            }
            if (responce == 0) {
                TextOutput.text = "Email already exists!";
                confirm[1] = false;
                yield return new WaitUntil (() => img[1].transform.rotation.z == 0);
                img[1].sprite = checkBox[1];
            }
        } else {
            Debug.Log (w.error);
            confirm[1] = false;
            TextOutput.text = null;
        }
    }
    IEnumerator Register () {
        TextOutput.text = "Connection please wait";
        yield return new WaitUntil (() => w8 == false);
        w8 = true;
        WWWForm form = new WWWForm ();
        form.AddField ("login", inputs[0].text);
        form.AddField ("email", inputs[1].text);
        form.AddField ("pass", inputs[3].text);
        WWW ip = new WWW ("http://ipecho.net/plain");
        yield return new WaitUntil (() => ip.isDone == true);
        form.AddField ("ip", ip.text);
        WWW w = requst ("reg", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            int responce = int.Parse (w.text);
            if (responce > 0) {
                BigMom.GSV.UserID = responce;
                SceneManager.LoadScene ("Tavern Scene", LoadSceneMode.Single);
            }
            if (responce == 0) {
                TextOutput.text = "Error";
            }
        } else {
            Debug.Log (w.error);
        }
        w8 = false;
    }
    public void reg () {
        if (!w8) {
            if (confirm[0] && confirm[1] && confirm[2] && confirm[3]) {
                StartCoroutine (Register ());
            }
        } else {
            TextOutput.text = "Relax boy w8";
        }
    }
    public void ResetFields () {
        inputs[0].text = null;
        inputs[1].text = null;
        inputs[2].text = null;
        inputs[3].text = null;
        TextOutput.text = null;
    }
    IEnumerator loading (int InputField) {
        w8 = true;
        img[InputField].sprite = loadingSprite;
        img[InputField].color = Color.grey;
        float z = Random.Range (-180f, 180f);
        while (w8) {

            img[InputField].transform.rotation = Quaternion.Euler (new Vector3 (0, 0, z));
            z -= 25;
            yield return new WaitForSeconds (0);
        }
        img[InputField].transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
        img[InputField].color = Color.white;
    }
    private WWW requst (string addr, WWWForm form) {
        form.AddField ("secretKeyCode", key);
        WWW requst = new WWW (URL + addr, form);
        return requst;
    }
}