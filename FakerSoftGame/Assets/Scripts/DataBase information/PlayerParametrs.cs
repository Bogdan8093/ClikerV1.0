using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerParametrs : MonoBehaviour {
    private float _monsterArmor= 0.1f;//10 percent
    private float _monsterMagicresist = 10;
    public GameObject DevUI;
    public void OpenHIde()
    {
        DevUI.SetActive(!DevUI.activeSelf);

    }
    public InputField _ETKSAIcoef, _ETKInputLvlExecutioner, _ETKInputLvlrush, _ETKInputLvlmagicArmor;

    public InputField _changInputLVLValue, _changInputClickDamage, _changInputCritChance, _changInputMultiplyCritPrower,
   _changInputMultiplySkillPower, _changInputMultiplyColdoun, _changInputResistCoef, _changInputFinalPower, _changInputFinalAgility,
   _changInputFinalIntellect, _changInputFinalStamina;



    //[SerializeField]
    [HideInInspector]
    public float _power = 10.0f, _agility = 10.0f, _intellect = 10.0f, _stamina = 10.0f, _SAICoef = 0.4f; //Main states 

    // [SerializeField]


    public InputField _basicInputClickDamage, _basicImputCritChance, _basicInputMultiplyCritPower, _basicInputMultiplyMagicPower,
            _basicInputMultiplyClodoun, _basicInputResistCoef, _basicInputPower, _basicInputAgility, _basicInputIntellect, _basicInputStamina;
    [SerializeField]
   public float LvL_Score;
    public float _basicClickDamage = 1.0f;
    public float _basicCritChance = 10.0f, _basicMultiplyCritPower = 1.5f, _basicMultiplyMagicPower = 1, _basicMultiplyColdoun = 1, _basicResistCoef = 0;
    //Game params
    [SerializeField]
    private float _clotheStrength=0, _clotheAgility=0, _clotheIntellect=0, _clotheStamina=0,_clotheMultiplyCriticalPowerChance=1.5f,_clotheMultiplyColdounCoef=1;//Clothes prams

  //  [SerializeField]
    public float _passiveModStrength= 1.0f, _passiveModAgility=1, _passiveModintellect=1, _passiveModStamina=1, _passiveMultipyCritiPower=1 , _passiveMultiplyColdoun=1;

    //Passive modification without 2 coefs;

   public  float _passiveLvlExecutioner, _passiveLvlrush, _passiveLvlmagicArmor;

    [HideInInspector]
    public float timeDecreaseCoeficient = 0.1f;

    [HideInInspector]
    public float HitDecreaseCoefForSpell = 1f;

    private const float BASE_HEALTH_DECREESE_COEFICIENT = 0.01f;
    private float _clickStrength;
  
    private float critChanse = 1.05f;

    private float correctiveHitStrangth = 1.0f;

    [HideInInspector]
    public float _monsterHealth;

    [HideInInspector]
    public float _clickDamage, _resistCoef;

    [HideInInspector]
    public float CurrentExp;

    [SerializeField]
    private float newPassiveSpending=0;
    // calculated params
    void Start()
    {
      
        CalсulateParams();
       
        if (PlayerPrefs.HasKey("agility"))
            _agility = PlayerPrefs.GetInt("agility");

        if (PlayerPrefs.HasKey("power"))
            _power = PlayerPrefs.GetInt("power");

        if (PlayerPrefs.HasKey("intellect"))
            _intellect = PlayerPrefs.GetInt("intellect");

        if (PlayerPrefs.HasKey("stamina"))
            _stamina = PlayerPrefs.GetInt("stamina");
     
      
    }
 
    public void CalсulateParams()
        {
        //params
        float _spendingStregth  = 2 * _passiveLvlExecutioner;
        float _spendingAgility = 2 * _passiveLvlrush;
        float _spendingIntellect = 2 * _passiveLvlmagicArmor;
        float _pointsSpendingPerPassive = _spendingStregth + _spendingAgility + _spendingIntellect + newPassiveSpending;
        float _koefB15 = (_power + _agility + _intellect + _stamina + _pointsSpendingPerPassive)/4;
        float _heroLevel = 1.0f; /// 1 + ((_strength + _agility + _intellect + _stamina) - 40) / LvL_Score;
        float _expForLevel = 100 * (_heroLevel * _heroLevel);       //
        float _finalStatePower = (_power + _clotheStrength) * _passiveModStrength;
        float _finalStateAgility = (_agility + _clotheAgility) * _passiveModAgility;
        float _finalStateIntellect = (_intellect + _clotheIntellect) * _passiveModintellect;
        float _finalStateStamina = (_stamina + _clotheStamina) * _passiveModStamina;
        float _finalMultiCritPowerCoef = (_clotheMultiplyCriticalPowerChance * _passiveMultipyCritiPower);
        float _finalMultiplierRollbackCoolDown = (_passiveMultiplyColdoun*_clotheMultiplyColdounCoef);
        float _clickCritcoef=1+(0.2f*_passiveLvlExecutioner);
         _clickDamage = _basicClickDamage + (_finalStatePower * _SAICoef);
        float _effectOnCritChance = 3 * _basicCritChance * _finalStateAgility;
        float _critChance = (_basicCritChance + (_finalStateAgility / (_koefB15 * _SAICoef))) + _effectOnCritChance;
        // float _critStrengthCoef = 1.5f;
        float _skillPowercoef = _basicMultiplyMagicPower+(_finalStateIntellect/(_koefB15/(_SAICoef)));
        float _coldounSkillCoef = 1.0f;
        _resistCoef = _basicResistCoef + (_koefB15 / _finalStateStamina);
        //Monsters
        float _monsterDamageEffect = 1.0f - (_passiveLvlmagicArmor*0.05f);
        float _monsterDamage = ((1.0f + _expForLevel / 50.0f) / 2.0f) * _monsterDamageEffect;
         _monsterHealth =_koefB15*_heroLevel*1.5f;
        float _monsterExp = (_monsterHealth + _expForLevel / (_koefB15 * _heroLevel))/15;
        float _monsterGold = ((_monsterHealth + _expForLevel / (_heroLevel * _koefB15)) / 15) * _heroLevel;
        float _monsterDropCoef = (_monsterHealth + _expForLevel / (_koefB15 * _heroLevel)) / 15;
        Debug.Log("MonsterHealth = " + _monsterHealth.ToString());
        Debug.Log("Strength = " + _power.ToString());
        Debug.Log("B15 = " + _koefB15.ToString());// _pointsSpendingPerPassive
        Debug.Log("_clickDamage = " + _clickDamage);
        //InputFields
        _changInputLVLValue.text = _heroLevel.ToString();
        _changInputClickDamage.text = _clickDamage.ToString();
        _changInputCritChance.text = _critChance.ToString();
        _changInputMultiplyCritPrower.text = _effectOnCritChance.ToString();
       _changInputMultiplyColdoun.text = _coldounSkillCoef.ToString();
        _changInputMultiplySkillPower.text = _skillPowercoef.ToString();
        _changInputResistCoef.text = _resistCoef.ToString();
        _changInputFinalPower.text = _finalStatePower.ToString();
        _changInputFinalAgility.text = _finalStateAgility.ToString();
        _changInputFinalIntellect.text = _finalStateIntellect.ToString();
        _changInputFinalStamina.text = _finalStateStamina.ToString();
        _basicInputClickDamage.text = _basicClickDamage.ToString();
        _basicImputCritChance.text = _basicCritChance.ToString();
        _basicInputMultiplyCritPower.text = _basicMultiplyCritPower.ToString();
        _basicInputMultiplyMagicPower.text = _basicMultiplyMagicPower.ToString();
        _basicInputMultiplyClodoun.text = _basicMultiplyColdoun.ToString();
        _basicInputResistCoef.text = _basicResistCoef.ToString();
        _basicInputPower.text = _power.ToString();
        _basicInputAgility.text = _agility.ToString();
        _basicInputIntellect.text = _intellect.ToString();
        _basicInputStamina.text = _stamina.ToString();
        _ETKSAIcoef.text = _SAICoef.ToString();
        _ETKInputLvlExecutioner.text = _passiveLvlExecutioner.ToString();
        _ETKInputLvlrush.text = _passiveLvlrush.ToString();
        _ETKInputLvlmagicArmor.text = _passiveLvlmagicArmor.ToString();


    }
    public void EtcChanges()
    {
       _SAICoef = float.Parse(_ETKSAIcoef.text);
      _passiveLvlExecutioner = float.Parse(_ETKInputLvlExecutioner.text);
       _passiveLvlmagicArmor = float.Parse(_ETKInputLvlmagicArmor.text);
       _passiveLvlrush = float.Parse(_ETKInputLvlrush.text);
    }
    public void BasicParamsChanges()
    {

        _basicClickDamage = float.Parse(_basicInputClickDamage.text);
        _basicCritChance = float.Parse(_basicImputCritChance.text);
       _basicMultiplyMagicPower = float.Parse(_basicInputMultiplyCritPower.text);
        _basicMultiplyCritPower = float.Parse(_basicInputMultiplyCritPower.text);
       _basicMultiplyColdoun = float.Parse(_basicInputMultiplyClodoun.text);
      _basicResistCoef = float.Parse(_basicInputResistCoef.text);
       _power = float.Parse(_basicInputPower.text);
       _agility = float.Parse(_basicInputAgility.text);
        _intellect = float.Parse(_basicInputIntellect.text);
       _stamina = float.Parse(_basicInputStamina.text);

    }
    public void setNormalTimeDecrease()
    {
        
        timeDecreaseCoeficient = 0.1f;
    }

    public float CalculateTimeDecrease()
    {

        return timeDecreaseCoeficient;
    }

    public float CalculateHit(MonstersBasicClass monstr)
    {
        float final_damage = _clickDamage * monstr._coefArmor - (_clickDamage * monstr._coefArmor - _clickDamage * monstr._coefArmor * _monsterArmor);
        //   _clickStrength = ((BASE_HEALTH_DECREESE_COEFICIENT + Random.Range(0.01f, 0.50f)) * CalculateCritChanse()) / Random.Range(0.5f + (BigMom.ENC._scoreCounter + 1f) / 5f, 1.4f + (BigMom.ENC._scoreCounter + 1f) / 5f);
        //    _clickStrength = _clickStrength * monster.ClickStrengthCorrectiveVector * HitDecreaseCoefForSpell;
        //    Debug.Log(monster.ClickStrengthCorrectiveVector.ToString());
        Debug.Log("Basedamage " + monstr._coefArmor);
        return final_damage;
        
    }

    private float CalculateCritChanse()
    {

        if (Random.Range(1f, 100f) * critChanse > 99)
            return 4.0f;
        else if (Random.Range(1f, 100f) * critChanse > 98)
            return 3.0f;
        else if (Random.Range(1f, 100f) * critChanse > 97)
            return 2.0f;
        else
            return 1.0f;
    }
}
