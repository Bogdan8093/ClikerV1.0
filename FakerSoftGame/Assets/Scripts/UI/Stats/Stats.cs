using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    [SerializeField]
    private int _forse, _sleight, _intellect, _stamina;

    [SerializeField]
    private Text _forceCounter, _sleightCounter, _intellectCounter, _staminaCounter, _countPointAbilities;

    [SerializeField]
    private Button _forcePlus, _sleightPlus, _intellectPlus, _staminaPlus;

    [SerializeField]
    private Button _forceMinus, _sleightMinus, _intellectMinus, _staminaMinus;

    string Pid, Plogin, Ppass, Pmail, Pint, Psta, Pagi, Pstr, Pexp, Plvl, PCchance, PCdamage;

    private string secretKey;
    [SerializeField]
    private int _PointAbilities = 396; //Поинты прокачки
    private string UserName = "Dark";// логин пользователя получает при авторизации 



    void Start()
    {
        secretKey = BigMom.DBkey.dbsecretkey;
        _countPointAbilities.text = _PointAbilities.ToString();
        GetStats(UserName);
    }
    
    

    #region GetStats
    void GetStats(string user)
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("secretKey", secretKey);
        WWW w = new WWW("http://s2s.ddns.net/db/GetUserInf.php", form);
        StartCoroutine(GetUserInf(w));

     }
    IEnumerator GetUserInf(WWW w)
    {
        yield return w;
        if (w.error == null)
        {
            if (w.text == "Недостаток данных")
            {
                Debug.Log("Ну ты сначала то данных то дай");
            }
            if (w.text == "Username does not exist\n")
            {
                Debug.Log("Ну кароч такого юзверя тут нет");
            }
            else
            {
                string[] lines = w.text.Split('\n');
                Pid = lines[0];
                Plogin = lines[1];
                Ppass = lines[2];
                Pmail = lines[3];
                Pint = lines[4];
                Psta = lines[5];
                Pagi = lines[6];
                Pstr = lines[7];
                Pexp = lines[8];
                Plvl = lines[9];
                PCchance = lines[10];
                PCdamage = lines[11];
                _forceCounter.text = Pagi;
                _sleightCounter.text = Pstr;
                _intellectCounter.text = Pint;
                _staminaCounter.text = Psta;
           }
        } 
    }
    #endregion


    #region SetStats
    void SetStats(string table, string column, string changeValue, int ChangeableID)
    {
        if (secretKey != null)
        {
            WWWForm form = new WWWForm();
            form.AddField("table", table);
            form.AddField("column", column);
            form.AddField("changeValue", changeValue);
            form.AddField("changeID", ChangeableID);
            form.AddField("secretKey", secretKey);
            WWW w = new WWW("http://s2s.ddns.net/db/UpdateValue.php", form);

        }
        else
        {
            Debug.Log("Секретного ключа немного нехватает");
        }
    }


    public void SetSubmit()
    {
       
        SetStats("users", "strength", _forceCounter.text, int.Parse(Pid));
        SetStats("users", "agility", _sleightCounter.text, int.Parse(Pid));
        SetStats("users", "intellect", _intellectCounter.text, int.Parse(Pid));
        SetStats("users", "stamina", _staminaCounter.text, int.Parse(Pid));
    }
    #endregion

   
    #region StatPlus
    public void ForsePlus()
    {
        if (int.Parse(_forceCounter.text) != 99)
        {
            string _string = _forceCounter.text;
            int _index = 1 + int.Parse(_string);
            _forceCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) - 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }

    public void SleightPlus()
    {
        if (int.Parse(_sleightCounter.text) != 99)
        {
            string _string = _sleightCounter.text;
            int _index = 1 + int.Parse(_string);
            _sleightCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) - 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }

    public void IntellectPlus()
    {
        if (int.Parse(_intellectCounter.text) != 99)
        {
            string _string = _intellectCounter.text;
            int _index = 1 + int.Parse(_string);
            _intellectCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) - 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }

    public void StaminaPlus()
    {
        if (int.Parse(_staminaCounter.text) != 99)
        {
            string _string = _staminaCounter.text;
            int _index = 1 + int.Parse(_string);
            _staminaCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) - 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }
    #endregion

    #region StatsMinus
    public void ForseMinus()
    {
        if (int.Parse(_forceCounter.text) != 10)
        {
            string _string = _forceCounter.text;
            int _index = int.Parse(_string) - 1;
            _forceCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }

    public void SleightMinus()
    {
        if (int.Parse(_sleightCounter.text) != 10)
        {
            string _string = _sleightCounter.text;
            int _index = int.Parse(_string) - 1;
            _sleightCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }

    public void IntellectMinus()
    {
        if (int.Parse(_intellectCounter.text) != 10)
        {
            string _string = _intellectCounter.text;
            int _index = int.Parse(_string) - 1;
            _intellectCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }

    public void StaminaMinus()
    {
        if (int.Parse(_staminaCounter.text) != 10)
        {
            string _string = _staminaCounter.text;
            int _index = int.Parse(_string) - 1;
            _staminaCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
        }

    }
}
#endregion