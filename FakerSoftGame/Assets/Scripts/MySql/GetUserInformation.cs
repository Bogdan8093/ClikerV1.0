using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class GetUserInformation : MonoBehaviour {
private string secretKey;
string Pid, Plogin, Ppass, Pmail, Pint, Psta, Pagi, Pstr, Pexp, Plvl, PCchance, PCdamage;
// В скрипте происходит всякая магия. Не лезь - убьет!
	void Start() {
        secretKey = BigMom.DBkey.dbsecretkey;
        // ниже пример использования 
        //GetUserInfo("dark");
	}
    void GetUserInfo(string user){
        if(secretKey!=null){
            WWWForm form = new WWWForm();
            form.AddField("user", user);
			form.AddField("secretKey", secretKey);
            WWW w = new WWW("http://s2s.ddns.net/db/GetUserInf.php", form);
            StartCoroutine(GetUserInf(w));
        }
        else{
            Debug.Log("Введи сначала переменные и заработаю");
        }
    }

	IEnumerator GetUserInf(WWW w){
        yield return w;
        if (w.error == null){
            if (w.text == "Недостаток данных"){
                Debug.Log("Ну ты сначала то данных то дай");
            }
            if (w.text == "Username does not exist\n"){
                Debug.Log("Ну кароч такого юзверя тут нет");
            }
            else{
                string[] lines =  w.text.Split('\n');
                Pid=lines[0];
                Plogin=lines[1];
                Ppass=lines[2];
                Pmail=lines[3];
                Pint=lines[4];
                Psta=lines[5];
                Pagi=lines[6];
                Pstr=lines[7];
                Pexp=lines[8];
                Plvl=lines[9];
                PCchance=lines[10];
                PCdamage=lines[11];
                
                int newPid = int.Parse(Pid);
                    if(newPid == 4){
                        Debug.Log("Данные о игроке дарк успешно полученны в стрингах в этом скрипте");
                    }
            }
        }
        else{
           Debug.Log("ERROR: " + w.error + "\n");
        }
    }
}

