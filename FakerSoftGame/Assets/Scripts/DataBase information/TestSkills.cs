using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TestSkills : MonoBehaviour {


    [SerializeField]
    private GameObject _skillsPanel;

    [SerializeField]
    private int _streght, _agility, _intellect, _stamina;

    [SerializeField]
    private Text _streghtCounter, _agilityCounter, _intellectCounter, _staminaCounter, _countPointAbilities;

    [SerializeField]
    private Button _strenghtPlus, _agilityPlus, _intellectPlus, _staminaPlus;

    [SerializeField]
    private Button _strenghtMinus, _agilityMinus, _intellectMinus, _staminaMinus;


    public void ShowPanelSkills()
    {
        _skillsPanel.SetActive(!_skillsPanel.activeSelf);
    }


    public void StrenghtPlus()
    {
        if (int.Parse(_streghtCounter.text) != 99)
        {
            string _string = _streghtCounter.text;
            int _index = 1 + int.Parse(_string);
            _streghtCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) - 1;
            _countPointAbilities.text = _integer.ToString();
            BigMom.PP._power = _integer;
            BigMom.PP.CalсulateParams();
        }
     
    }

    public void AgilityPlus()
    {
        if (int.Parse(_agilityCounter.text) != 99)
        {
            string _string = _agilityCounter.text;
            int _index = 1 + int.Parse(_string);
            _agilityCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) - 1;
            _countPointAbilities.text = _integer.ToString();
            BigMom.PP._agility = _integer;
            BigMom.PP.CalсulateParams();
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
            BigMom.PP._intellect = _integer;
            BigMom.PP.CalсulateParams();
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
            BigMom.PP._stamina = _integer;
            BigMom.PP.CalсulateParams();
        }
       
    }

    public void StrenghtMinus()
    {
        if (int.Parse(_streghtCounter.text) != 0)
        {
            string _string = _streghtCounter.text;
            int _index = int.Parse(_string) - 1;
            _streghtCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            BigMom.PP._power = _integer;
            BigMom.PP.CalсulateParams();
        }
        
    }

    public void AgilityMinus()
    {
        if (int.Parse(_agilityCounter.text) != 0)
        {
            string _string = _agilityCounter.text;
            int _index = int.Parse(_string) - 1;
            _agilityCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            BigMom.PP._agility = _integer;
            BigMom.PP.CalсulateParams();
        }
   
    }

    public void IntellectMinus()
    {
        if (int.Parse(_intellectCounter.text) != 0)
        {
            string _string = _intellectCounter.text;
            int _index = int.Parse(_string) - 1;
            _intellectCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            BigMom.PP._intellect = _integer;
            BigMom.PP.CalсulateParams();
            
        }
       
    }

    public void StaminaMinus()
    {
        if (int.Parse(_staminaCounter.text) != 0)
        {
            string _string = _staminaCounter.text;
            int _index = int.Parse(_string) - 1;
            _staminaCounter.text = _index.ToString();
            int _integer = int.Parse(_countPointAbilities.text) + 1;
            _countPointAbilities.text = _integer.ToString();
            BigMom.PP._stamina = _integer;
            BigMom.PP.CalсulateParams();
        }
        
    }
}
