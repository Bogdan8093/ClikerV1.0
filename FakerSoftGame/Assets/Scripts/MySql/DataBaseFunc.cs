using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseFunc : MonoBehaviour {
    // private string secretKey = BigMom.DBkey.dbsecretkey;
    public int ID, PT, STR, AGI, INT, STA, EXP, LVL;
    public string Plogin, Ppass, Pmail, IP;
    public bool UpdatingStats, needwait;
    public ItemLists[] item;
    public WWW www;
    private string parseItems, secretKey, URL;
    private List<string> form = new List<string> ();
    // В скрипте происходит всякая магия. Не лезь - убьет!

    void Awake () {
        secretKey = BigMom.GSV.DBKey;
        URL = BigMom.GSV.URL;
        //Заглушка чтоб работало без логин сцены

        if (BigMom.GSV.DBKey != null) {
            if (BigMom.GSV.UserID != 0) {
                StartCoroutine (GetUserInf (BigMom.GSV.UserID));
            } else {
                StartCoroutine (GetUserInf (1));
            }
            StartCoroutine (GetItemsCall ());
        } else {
            Debug.Log ("Отсутствует файл ключа!\nДБ работать не будет");
        }
    }

    public void externalGetStats () {
        StartCoroutine (GetUserStats (ID));
    }
    // Получение конкретно статов

    IEnumerator GetUserStats (int userID) {
        needwait = true;
        UpdatingStats = true;
        WWWForm form = new WWWForm ();
        form.AddField ("userID", userID);
        WWW w = requst ("GetUserStats", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error) && w.text != ("Bad input")) {
            int[] lines = System.Array.ConvertAll<string, int> (w.text.Split ('\n'), new System.Converter<string, int> (int.Parse));
            ID = lines[0];
            PT = lines[1];
            AGI = lines[2];
            INT = lines[3];
            STA = lines[4];
            STR = lines[5];
            EXP = lines[6];
            LVL = lines[7];
        } else {
            if (w.error != null) {
                Debug.Log ("ERROR: " + w.error + "\n");
            } else {
                Debug.Log ("Кривой ввод");
            }
        }
        UpdatingStats = false;
        needwait = false;
    }

    // Получение полной инфы о юзвере

    IEnumerator GetUserInf (int userID) {
        WWWForm form = new WWWForm ();
        form.AddField ("userID", userID);
        WWW w = requst ("GetUserInf", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            // Debug.Log (w.text);
            string[] lines = new string[14];
            lines = w.text.Split ('\n');
            ID = int.Parse (lines[0]);
            Plogin = lines[1];
            Ppass = lines[2];
            Pmail = lines[3];
            PT = int.Parse (lines[4]);
            AGI = int.Parse (lines[5]);
            INT = int.Parse (lines[6]);
            STA = int.Parse (lines[7]);
            STR = int.Parse (lines[8]);
            EXP = int.Parse (lines[9]);
            LVL = int.Parse (lines[10]);
            IP = lines[11];
            UpdatingStats = true;
        } else {
            Debug.Log ("ERROR: " + w.error + "\n");
        }
    }
    // public IEnumerator UpdateValue (WWWForm form, string addr) {
    //     form.AddField ("secretKeyCode", secretKey);
    //     WWW w = new WWW (URL + addr, form);
    //     yield return new WaitUntil (() => w.isDone == true);
    //     if (string.IsNullOrEmpty (w.error) && !(w.text == "0")) {
    //         // Debug.Log (w.text);
    //     } else {
    //         Debug.Log ("ERROR: " + w.error + "\n" + "Text" + w.text);
    //     }
    //     needwait = false;
    // }
    IEnumerator GetItemsCall () {
        WWW w = requst ("GetItems");
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            parseItems = w.text;
            parseItems = "{\"Items\":" + parseItems + "}";
            item = JsonHelper.FromJson<ItemLists> (parseItems);
        } else {
            Debug.Log (w.error);
        }
    }
    public WWW requst (string addr, WWWForm form = null) {
            if (form == null) {
                form = new WWWForm ();
            }
            form.AddField ("secretKeyCode", secretKey);
            WWW requst = new WWW (URL + addr, form);
            return requst;
        }
        [Serializable]
    public struct ItemLists {
        public int id, cost, INT, STA, STR, AGI;
        public string name, type, img, rare, boonus, description;
    }
}