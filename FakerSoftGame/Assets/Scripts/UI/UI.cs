using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{

    [SerializeField]
    private GameObject _tavernPanel, _personPanel, _shopPanel, _mapPanel;

    [SerializeField]
    private int _forse, _sleight, _intellect, _stamina;

    [SerializeField]
    private Text _forceCounter, _sleightCounter, _intellectCounter, _staminaCounter, _countPointAbilities;

    [SerializeField]
    private Button _forcePlus, _sleightPlus, _intellectPlus, _staminaPlus;

    [SerializeField]
    private Button _forceMinus, _sleightMinus, _intellectMinus, _staminaMinus;

    [SerializeField]
    private GameObject _abilities, _skills;


      public void FightScene()
    {
        SceneManager.LoadScene("clickScene");
    }

    public void LoadingBarPanel()
    {
        SceneManager.LoadScene("SceneDownloads");
    }

    public void TavernPanel()
    {
        _tavernPanel.SetActive(true);
        _personPanel.SetActive(false);
        _mapPanel.SetActive(false);
        _shopPanel.SetActive(false);
    }

    public void ShopPanel()
    {
        _shopPanel.SetActive(true);
        _tavernPanel.SetActive(false);
    }

    public void MapPanel()
    {
        _mapPanel.SetActive(true);
        _tavernPanel.SetActive(false);
    }

    public void PersonPanel()
    {
        _personPanel.SetActive(true);
        _tavernPanel.SetActive(false);
        if (PlayerPrefs.HasKey("power"))
        {
            //  BigMom.PP._agility = int.Parse(_sleightCounter.text);

            if (PlayerPrefs.HasKey("agility")) 
            _sleightCounter.text = PlayerPrefs.GetInt("agility").ToString();

            if (PlayerPrefs.HasKey("power")) 
            _forceCounter.text = PlayerPrefs.GetInt("power").ToString();

            if (PlayerPrefs.HasKey("intellect"))
            _intellectCounter.text = PlayerPrefs.GetInt("intellect").ToString();

            if (PlayerPrefs.HasKey("stamina")) 
            _staminaCounter.text = PlayerPrefs.GetInt("stamina").ToString();
            //  _power = PlayerPrefs.GetInt("power");
            // _agility = PlayerPrefs.GetInt("agility");
            // _intellect = PlayerPrefs.GetInt("intellect");
            //_stamina = PlayerPrefs.GetInt("stamina");
        }
    }

    public void AbilitiesSkills()
    {
        _abilities.SetActive(!_abilities.activeSelf);
        _skills.SetActive(!_skills.activeSelf);
    }

    public void ForsePlus()
    {
        if (int.Parse(_forceCounter.text) != 99)
        {
            string _string = _forceCounter.text;
            int _index = 1 + int.Parse(_string);
            _forceCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) - 1;
            _countPointAbilities.text = _integer.ToString();
            PlayerPrefs.SetInt("power", _index);
        }
       
     //   _power = PlayerPrefs.GetInt("power");
      //  _agility = PlayerPrefs.GetInt("agility");
      //  _intellect = PlayerPrefs.GetInt("intellect");
      //  _stamina = PlayerPrefs.GetInt("stamina");

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
            PlayerPrefs.SetInt("agility", _index);
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
            PlayerPrefs.SetInt("intellect", _index);
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
            PlayerPrefs.SetInt("stamina", _index);
        }
    }

    public void ForseMinus()
    {
        if (int.Parse(_forceCounter.text) > 10)
        {
            string _string = _forceCounter.text;
            int _index = int.Parse(_string) - 1;
            _forceCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            PlayerPrefs.SetInt("power", _index);
        }
    }

    public void SleightMinus()
    {
        if (int.Parse(_sleightCounter.text) > 10)
        {
            string _string = _sleightCounter.text;
            int _index = int.Parse(_string) - 1;
            _sleightCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            PlayerPrefs.SetInt("agility", _index);
        }
    }

    public void IntellectMinus()
    {
        if (int.Parse(_intellectCounter.text) > 10)
        {
            string _string = _intellectCounter.text;
            int _index = int.Parse(_string) - 1;
            _intellectCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            PlayerPrefs.SetInt("intellect", _index);
        }
    }

    public void StaminaMinus()
    {
        if (int.Parse(_staminaCounter.text) > 10)
        {
            string _string = _staminaCounter.text;
            int _index = int.Parse(_string) - 1;
            _staminaCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            PlayerPrefs.SetInt("stamina", _index);
        }
    }
}