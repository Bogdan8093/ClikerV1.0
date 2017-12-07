using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
public class DataBaseFunc : MonoBehaviour {
    // private string secretKey = BigMom.DBkey.dbsecretkey;
    public int ID, PT, STR, AGI, INT, STA, EXP, LVL;
    public string Plogin, Ppass, Pmail, IP;
    public bool UpdatingStats, needwait;
    public JsonHelper.ItemLists[] items;
    public WWW www;
    private string parseItems, secretKey, URL;
    public GlobalServerValues GSV;
    // private List<string> form = new List<string>();
    // private TextAsset dsa;
    // В скрипте происходит всякая магия. Не лезь - убьет!

    void Awake() {
        secretKey = BigMom.GSV.DBKey;
        URL = BigMom.GSV.URL;
        //Заглушка чтоб работало без логин сцены

        if (BigMom.GSV.DBKey != null) {
            if (BigMom.GSV.UserID != 0) {
                StartCoroutine(GetUserData(BigMom.GSV.UserID));
            } else {
                StartCoroutine(GetUserData(1));
            }
            StartCoroutine(GetItemsCall());
            // StartCoroutine(AssetTest());ss
        } else {
            Debug.Log("Отсутствует файл ключа!\nДБ работать не будет");
        }
    }
    // Получение конкретно статов
    public IEnumerator GetUserStats() {
        needwait = true;
        UpdatingStats = true;
        WWWForm form = new WWWForm();
        form.AddField("userID", ID);
        WWW w = requst("getuserstats", form);
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error) && w.text != ("Bad input")) {
            int[] lines = System.Array.ConvertAll<string, int>(w.text.Split('\n'), new System.Converter<string, int>(int.Parse));
            // ID = lines[0];
            PT = lines[0];
            AGI = lines[1];
            INT = lines[2];
            STA = lines[3];
            STR = lines[4];
            EXP = lines[5];
            LVL = lines[6];
        } else {
            if (w.error != null) {
                Debug.Log("ERROR: " + w.error + "\n");
            } else {
                Debug.Log("Кривой ввод");
            }
        }
        UpdatingStats = false;
        needwait = false;
    }

    // Получение полной инфы о юзвере

    IEnumerator GetUserData(int userID) {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        WWW w = requst("getuserdata", form);
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            // Debug.Log (w.text);
            string[] lines = new string[14];
            lines = w.text.Split('\n');
            ID = int.Parse(lines[0]);
            Plogin = lines[1];
            Pmail = lines[2];
            PT = int.Parse(lines[3]);
            AGI = int.Parse(lines[4]);
            INT = int.Parse(lines[5]);
            STA = int.Parse(lines[6]);
            STR = int.Parse(lines[7]);
            EXP = int.Parse(lines[8]);
            LVL = int.Parse(lines[9]);
            UpdatingStats = true;
        } else {
            Debug.Log("ERROR: " + w.error + "\n");
        }
    }
    IEnumerator GetItemsCall() {
        WWW w = requst("getitems");
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            parseItems = w.text;
            parseItems = "{\"Items\":" + parseItems + "}";
            items = JsonHelper.FromJson<JsonHelper.ItemLists>(parseItems);
        } else {
            Debug.Log(w.error);
        }
    }
    public WWW requst(string addr, WWWForm form = null) {
        if (form == null) {
            form = new WWWForm();
        }
        form.AddField("secretKeyCode", secretKey);
        WWW requst = new WWW(URL + addr, form);
        return requst;
    }
    void ParseJson(TextAsset dsa) {

    }
    public IEnumerator UpdateValue(List<string> stat) {
        string strRequst = string.Join(" ", stat.ToArray());
        WWWForm form = new WWWForm();
        form.AddField("val", strRequst);
        form.AddField("userID", GSV.userData.id);
        WWW w = requst("UpdateValue", form);
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            GSV.userData = JsonMapper.ToObject<GlobalServerValues.UserData>(w.text);
        }
    }
    IEnumerator AssetTest() {
        WWW w = requst("test");
        yield return new WaitUntil(() => w.isDone == true);
        if (string.IsNullOrEmpty(w.error)) {
            // GSV.userData = JsonMapper.ToObject<GlobalServerValues.UserData>(w.text);
            // Debug.Log(w.text);
            // File.WriteAllText("Assets/StreamingAssets/Json/UserInfo.json", w.text);

        } else {
            Debug.Log(w.error);
        }
    }
}