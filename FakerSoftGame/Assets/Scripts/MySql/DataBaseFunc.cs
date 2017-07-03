using System.Collections;
using UnityEngine;

public class DataBaseFunc : MonoBehaviour {
    private string secretKey;
    public int ID, PT, STR, AGI, INT, STA, EXP, LVL, CC, CD;
    public string Plogin, Ppass, Pmail;
    public bool readyCheck, needwait;
    // В скрипте происходит всякая магия. Не лезь - убьет!
    void Awake () {
        secretKey = BigMom.DBkey.dbsecretkey;
        //Заглушка чтоб работало без логин сцены
        if (auth.userID != 0) {
            GetUserInfo (auth.userID);
        } else {
            GetUserInfo (1);
        }
    }
    public void externalStartStats () {
        if (auth.userID != 0) {
            GetUserStats (auth.userID);
        } else {
            GetUserStats (1);
        }
    }

    // Получение полной инфы о юзвере

    void GetUserInfo (int userID) {
        readyCheck = false;
        if (secretKey != null) {
            StartCoroutine (GetUserInfoCall (userID));
        } else {
            Debug.Log ("Введи сначала переменные и заработаю");
        }
    }
    IEnumerator GetUserInfoCall (int userID) {
        WWWForm form = new WWWForm ();
        form.AddField ("userID", userID);
        form.AddField ("secretKey", secretKey);
        yield return new WaitUntil (() => needwait == false);
        WWW w = new WWW ("http://s2s.ddns.net/db/GetUserInf.php", form);
        yield return w;
        if (w.error == null) {
            if (w.text == "Недостаток данных") {
                Debug.Log ("Ну ты сначала то данных то дай");
            }
            if (w.text == "Username does not exist\n") {
                Debug.Log ("Ну кароч такого юзверя тут нет");
            }
            if (w.text == "Введите коректный код или идите нахуй") {
                Debug.Log ("Введите ключ от дб");
            } else {
                string[] lines = new string[12];
                lines = w.text.Split ('\n');
                ID = int.Parse (lines[0]);
                Plogin = lines[1];
                Ppass = lines[2];
                Pmail = lines[3];
                PT = int.Parse (lines[4]);
                INT = int.Parse (lines[5]);
                STA = int.Parse (lines[6]);
                AGI = int.Parse (lines[7]);
                STR = int.Parse (lines[8]);
                EXP = int.Parse (lines[9]);
                LVL = int.Parse (lines[10]);
                CC = int.Parse (lines[11]);
                CD = int.Parse (lines[12]);
                yield return new WaitUntil (() => w.isDone);
                readyCheck = true;
            }
        } else {
            Debug.Log ("ERROR: " + w.error + "\n");
        }
    }

    // Получение конкретно статов

    void GetUserStats (int userID) {
        readyCheck = false;
        if (secretKey != null) {

            StartCoroutine (GetUserStatsCall (userID));
        } else {
            Debug.Log ("Введи сначала переменные и заработаю");
        }
    }
    IEnumerator GetUserStatsCall (int userID) {
        WWWForm form = new WWWForm ();
        form.AddField ("userID", userID);
        form.AddField ("secretKey", secretKey);
        yield return new WaitUntil (() => needwait == false);
        WWW w = new WWW ("http://s2s.ddns.net/db/GetUserStats.php", form);
        yield return new WaitUntil (() => w.isDone == true);
        yield return w;
        if (w.error == null) {
            if (w.text == "Username does not exist\n") {
                Debug.Log ("Ну кароч такого юзверя тут нет");
            } else {

                // lines = int.Parse(w.text).Split ('\n');
                int[] lines = System.Array.ConvertAll<string, int> (w.text.Split ('\n'), new System.Converter<string, int> (int.Parse));
                ID = lines[0];
                STR = lines[1];
                AGI = lines[2];
                INT = lines[3];
                STA = lines[4];
                PT = lines[5];
                yield return new WaitUntil (() => w.isDone);
                readyCheck = true;
                // перелопатить масив для проверки
                // foreach (string item in lines)
                // {
                //     Debug.Log(item + "\n");
                // }
            }
        } else {
            Debug.Log ("ERROR: " + w.error + "\n");
        }
        // while (!w.isDone){
        // yield return new WaitForSeconds(0.1f);
        // }
    }

    //Заполнение 1го значения в базе

    public void UpdateValueFunc (string table, string column, string changeValue, int ChangeableID) {
        needwait = true;
        if (secretKey != null) {
            WWWForm form = new WWWForm ();
            form.AddField ("table", table);
            form.AddField ("column", column);
            form.AddField ("changeValue", changeValue);
            form.AddField ("changeID", ChangeableID);
            form.AddField ("secretKey", secretKey);
            WWW UpdateValueFuncWWW = new WWW ("http://s2s.ddns.net/db/UpdateValue.php", form);
            // показать измения
            // Debug.Log ("table = " + table + "\n column = " + column + "\n val = " + changeValue + "\n playerID = " + ChangeableID);
            StartCoroutine (UpdateValueFuncCall (UpdateValueFuncWWW));
        } else {
            Debug.Log ("Секретного ключа немного нехватает");
        }
    }
    IEnumerator UpdateValueFuncCall (WWW w) {

        yield return w;
        if (w.error == null) {
            if (w.text == "Rows matched: 1  Changed: 1  Warnings: 0") {
                // if (w.isDone) {
                //     success = true;
                // }
                Debug.Log ("Значение перезаписаннo");
            }
            if (w.text == "Rows matched: 1  Changed: 0  Warnings: 0") {
                Debug.Log ("Значение найденно но НЕизменна");
            }
        } else {
            Debug.Log ("ERROR: " + w.error + "\n");
        }
        yield return new WaitUntil (() => w.isDone);
        needwait = false;
    }
}