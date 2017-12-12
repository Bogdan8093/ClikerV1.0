using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
public class DataBaseFunc : MonoBehaviour {
    // [Header("User stats")]
    public bool Updating;
    private bool Auth;
    public JsonHelper.ItemLists[] items;
    private string secretKey, URL;
    private GlobalServerValues GSV;
    // В скрипте происходит всякая магия. Не лезь - убьет!

    void Awake() {
        GSV = GameObject.FindObjectOfType<GlobalServerValues>();
        URL = BigMom.GSV.URL;
        //Заглушка чтоб работало без логин сцены
        if (BigMom.GSV.SecretKey != null) {
            if (GSV.Auth == null) {
                StartCoroutine(StringToken());
            } else {
                Auth = true;
            }
            StartCoroutine(AutoStart());
        } else {
            Debug.Log("Отсутствует файл ключа!\nДБ работать не будет");
        }
    }
    IEnumerator AutoStart() {
        yield return new WaitUntil(() => Auth == true);
        StartCoroutine(GetUserData());
        StartCoroutine(GetItemsCall());
    }

    // Получение конкретизированных параметров персонажа
    public IEnumerator UpdateValue(List<string> stat) {
        Updating = true;
        string strRequst = string.Join(" ", stat.ToArray());
        WWWForm form = new WWWForm();
        form.AddField("val", strRequst);
        WWW w = requst("update_value", form);
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            // Debug.Log(w.text);
            JsonUtility.FromJsonOverwrite(w.text, GSV.userData);
            // GSV.userData = JsonMapper.ToObject<GlobalServerValues.UserData>(w.text);
            // Debug.Log(w.text);
        }
        Updating = false;
    }
    // Получение полной инфы о юзвере
    // Не использовать в личных целях перезаписывает ластвизит

    IEnumerator GetUserData() {
        Updating = true;
        WWW w = requst("user_data");
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            GSV.userData = JsonMapper.ToObject<GlobalServerValues.UserData>(w.text);
        } else {
            Debug.Log("ERROR: " + w.error + "\n");
        }
        Updating = false;
    }
    IEnumerator GetItemsCall() {
        WWW w = requst("get_items");
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            string parseItems = w.text;
            parseItems = "{\"Items\":" + parseItems + "}";
            items = JsonHelper.FromJson<JsonHelper.ItemLists>(parseItems);
        } else {
            Debug.Log(w.error);
        }
    }
    public WWW requst(string addr, WWWForm form = null) {

        byte[] data;
        if (form == null) {
            form = new WWWForm();
            data = null;
        } else {
            form.AddField("dsa", "dsa");
            data = form.data;
        }
        var header = new Dictionary<string, string>();
        header["Accept"] = "application/json";
        header["Authorization"] = GSV.Auth[0] + " " + GSV.Auth[2];
        WWW requst = new WWW(URL + addr, data, header);
        return requst;
    }
    IEnumerator StringToken() {
        WWWForm form = new WWWForm();
        form.AddField("id", GSV.SecretID);
        form.AddField("secret", GSV.SecretKey);
        form.AddField("email", "vlad94@ukr.net");
        form.AddField("password", "123456");
        WWW w = new WWW(URL + "login", form);
        yield return new WaitUntil(() => w.isDone == true);
        GSV.Auth = JsonMapper.ToObject(w.text);
        Auth = true;
    }
    IEnumerator AssetTest() {

        WWW w = requst("user_data");
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            // GSV.userData = JsonMapper.ToObject<GlobalServerValues.UserData>(w.text);
            Debug.Log(w.text);
        } else {
            Debug.Log(w.error);
        }
    }
}