using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseFunc : MonoBehaviour {
    // private string secretKey = BigMom.DBkey.dbsecretkey;
    public int ID, PT, STR, AGI, INT, STA, EXP, LVL;
    public string Plogin, Ppass, Pmail, IP;
    public bool readyCheck, needwait;
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
            if (auth.userID != 0) {
                StartCoroutine (GetUserInf (auth.userID));
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
        // StartCoroutine (test ());
    }

    // Получение конкретно статов

    IEnumerator GetUserStats (int userID) {
        needwait = true;
        readyCheck = false;
        WWWForm form = new WWWForm ();
        form.AddField ("userID", userID);
        form.AddField ("secretKeyCode", secretKey);
        yield return new WaitUntil (() => needwait == false);
        WWW w = new WWW (URL + "GetUserStats", form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error)) {
            if (!(w.text == "Bad input")) {
                int[] lines = System.Array.ConvertAll<string, int> (w.text.Split ('\n'), new System.Converter<string, int> (int.Parse));
                ID  = lines[0];
                PT  = lines[1];
                AGI = lines[2];
                INT = lines[3];
                STA = lines[4];
                STR = lines[5];
                EXP = lines[6];
                LVL = lines[7];
            } else {
                Debug.Log ("Кривой ввод");
            }
        } else {
            Debug.Log ("ERROR: " + w.error + "\n");
        }
        needwait = false;
        readyCheck = true;
        // while (!w.isDone){
        // yield return new WaitForSeconds(0.1f);
        // }
    }

    // Получение полной инфы о юзвере

    IEnumerator GetUserInf (int userID) {
        WWWForm form = new WWWForm ();
        form.AddField ("userID", userID);
        form.AddField ("secretKeyCode", secretKey);
        WWW w = new WWW (URL + "GetUserInf", form);
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
            readyCheck = true;
        } else {
            Debug.Log ("ERROR: " + w.error + "\n");
        }
    }
    public IEnumerator UpdateValue (WWWForm form, string addr) {
        form.AddField ("secretKeyCode", secretKey);
        WWW w = new WWW (URL + addr, form);
        yield return new WaitUntil (() => w.isDone == true);
        if (string.IsNullOrEmpty (w.error) && !(w.text == "0")) {
            // Debug.Log (w.text);
        } else {
            Debug.Log ("ERROR: " + w.error + "\n" + "Text" + w.text);
        }
        needwait = false;
    }
    IEnumerator GetItemsCall () {
            WWWForm form = new WWWForm ();
            form.AddField ("secretKeyCode", secretKey);
            www = new WWW (URL + "GetItems", form);
            yield return new WaitUntil (() => www.isDone == true);
            if (string.IsNullOrEmpty (www.error)) {
                parseItems = www.text;
                parseItems = "{\"Items\":" + parseItems + "}";
                item = JsonHelper.FromJson<ItemLists> (parseItems);
                Debug.Log (item[0].name);

            } else {
                Debug.Log (www.error);
            }
        }
        [Serializable]
    public struct ItemLists {
        public int id, cost, INT, STA, STR, AGI;
        public string name, type, img, rare, boonus, description;
    }
}