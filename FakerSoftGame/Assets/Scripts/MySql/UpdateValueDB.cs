using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateValueDB : MonoBehaviour {
private string secretKey;
// В скрипте происходит всякая магия. Не лезь - убьет!
	void Start () {
        secretKey = BigMom.DBkey.dbsecretkey;
		// ниже пример использования 
        //UpdateValueFunc("users", "password", "testpassfromunity",4);
	}
    void UpdateValueFunc(string table, string column, string changeValue, int ChangeableID ){
        if(secretKey!=null){
            WWWForm form = new WWWForm();
            form.AddField("table", table);
            form.AddField("column", column);
            form.AddField("changeValue", changeValue);
            form.AddField("changeID", ChangeableID);
            form.AddField("secretKey", secretKey);
            WWW w = new WWW("http://s2s.ddns.net/db/UpdateValue.php", form);
            StartCoroutine(Call(w));
        }
        else{
            Debug.Log("Секретного ключа немного нехватает");
        }
    }
	IEnumerator Call(WWW w){
        yield return w;
        if (w.error == null){
                Debug.Log(w.text);
        }
        else{
           Debug.Log("ERROR: " + w.error + "\n");
        }
    }
}

