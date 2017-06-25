using UnityEngine;
using System.Collections;
using System.Collections.Generic;






public class MonstersBasicClass : MonoBehaviour {


    public enum MonsterType
    { TimeEater, Healer, Usual, Armored, coldownCastObject };



    public List<MonsterType> MonsterTypesList = new List<MonsterType> { MonsterType.Armored, MonsterType.Healer, MonsterType.Usual, MonsterType.TimeEater };

    public GameObject HealerBody;
    public GameObject UsualBody;
    public GameObject TimeEaterBody;
    public GameObject ArmoredBody;
    public GameObject ColdownObjectBody;


    public float _coefDamage;
    public float _coefHealth;
    public float _coefArmor;
    public float _coefMagicResist;
    public float _coefExperiance;
    public float _coefDrop;
    public float _coefGold;
        





    [HideInInspector]
    public  float ClickStrengthCorrectiveVector;

    [HideInInspector]
    public float SaveClickStrengthCorrectiveVector;

    // public  string TypeOfMonster;
    [HideInInspector]
    public Vector3 spawnSlot;
    [HideInInspector]
    public MonsterType TypeOfThisMonster;
    [HideInInspector]
    public GameObject monsterBody;
    public MonstersBasicClass currentMonster;

    [HideInInspector]
    public bool AlreadyDead = false;

    [HideInInspector]
    public int MonsterPresonalNumber;

    private MonstersBasicClass MonsterSaverForInvokeRepeating ;

    [HideInInspector]
    public bool AlreadyHealTarget = false;

    [HideInInspector]
    public float BaseHealthPoints;
    [HideInInspector]
    private float BaseDamage = 0.1f;
    [HideInInspector]
    private float BaseExpereance = 1.0f;
    [HideInInspector]
    private float BaseGold = 0.1f;
    [HideInInspector]
    private float BaseDropChanse = 1.0f;
    [HideInInspector]
    private float BaseArmor = 1.0f;
    [HideInInspector]
    private float BaseMagResist = 1.0f;


    [HideInInspector]
    public float HealthPoints;
    [HideInInspector]
    public float Damage = 0;
    [HideInInspector]
    public float Expereance;
    [HideInInspector]
    public float Gold;
    [HideInInspector]
    public float DropChanse;
    [HideInInspector]
    public float Armor;
    [HideInInspector]
    public float MagResist;

    [HideInInspector]
    public float CorrectionHealthPoints;
    [HideInInspector]
    public float CorrectionDamage;
    [HideInInspector]
    public float CorrectionExpereance;
    [HideInInspector]
    public float CorrectionGold;
    [HideInInspector]
    public float CorrectionDropChanse;
    [HideInInspector]
    public float CorrectionArmor;
    [HideInInspector]
    public float CorrectionMagResist;

    public float CurrentHealth;
    public float BasicHealth;

    private const float HEAL_COLDOWN_WALUE = 6f;

    

    private const float MAX_SCALE_X_VALUE_FOR_COLDOWNBAR = 12.4f;

    public float couldownBarValue = MAX_SCALE_X_VALUE_FOR_COLDOWNBAR;

    public float HealColdown = 0f;
    public float HealCastTime = 0f;

    public bool killmeNOW = false;

    public bool StartHealCastSpelCountdown = false;

    [HideInInspector]
    public bool ColdownMonsterDestroted = false;

    [HideInInspector]
    public MonstersBasicClass coldownMonster;

    [HideInInspector]
    public MonstersBasicClass healerMonsterForColdown;

    void Start()
    {

    }

    private void onEnable()
    {
      //  BigMom.GC.MonsterWasKilled_E.AddListener(checkExistingMonsterTypesInGame);
        //BigMom.GC.MonsterReadyToBeHealed_E.AddListener(catchMonstersAskAboutHeal);
    }

    private void onDisable()
    {
      //  BigMom.GC.MonsterWasKilled_E.RemoveListener(checkExistingMonsterTypesInGame);
      //  BigMom.GC.MonsterReadyToBeHealed_E.RemoveListener(catchMonstersAskAboutHeal);
    }

    public void initMonster(MonsterType _monsterType, Vector3 _spawnSpotNumber, MonstersBasicClass curmon )
    {
        //  ClickStrengthCorrectiveVector = _monsterHealthCorrectiveValue;
        TypeOfThisMonster = _monsterType;
        curmon.TypeOfThisMonster = _monsterType;

        curmon.spawnSlot = _spawnSpotNumber;
        //  monsterBody = _monsterBody;
      //  BaseHealthPoints = BigMom.PP._monsterHealth;
        HealthPoints = BaseHealthPoints;
        attachBodyToMonster(curmon);
        
       
        

    }

    private void attachBodyToMonster(MonstersBasicClass curmon)
    {
        switch (curmon.TypeOfThisMonster)
        {
            case (MonsterType.Armored):
               curmon.monsterBody = ArmoredBody;
                curmon.ClickStrengthCorrectiveVector = 1f;
               // CorrectionArmor =;
               // CorrectionDamage;
               // CorrectionDropChanse;
               // CorrectionExpereance;
               // CorrectionGold;
               // CorrectionHealthPoints;
    _coefDamage = 0.8f;
     _coefHealth = 1.5f;
                curmon._coefArmor = 1.5f;
     _coefMagicResist = 0.5f;
     _coefExperiance = 2.0f;
     _coefDrop = 2.0f;
     _coefGold = 2.0f;

                break;
            case (MonsterType.Healer):
                curmon.monsterBody = HealerBody;
                curmon.ClickStrengthCorrectiveVector = 1.5f;
                _coefDamage = 0.5f;
                _coefHealth = 0.8f;
                curmon._coefArmor = 1.0f;
                _coefMagicResist = 1.0f;
                _coefExperiance = 2.0f;
                _coefDrop = 2.0f;
                _coefGold = 2.0f;
                break;
            case (MonsterType.TimeEater):
                curmon.monsterBody = TimeEaterBody;
                curmon.ClickStrengthCorrectiveVector = 1.5f;
                _coefDamage = 1.0f;
                _coefHealth = 1.0f;
                curmon._coefArmor = 1.0f;
                _coefMagicResist = 1.0f;
                _coefExperiance = 1.0f;
                _coefDrop = 1.0f;
                _coefGold = 1.0f;
                break;
            case (MonsterType.Usual):
                curmon.monsterBody = UsualBody;
                curmon.ClickStrengthCorrectiveVector = 0.6f;
                _coefDamage = 1.0f;
                _coefHealth = 1.0f;
                curmon._coefArmor = 1.0f;
                _coefMagicResist = 1.0f;
                _coefExperiance = 1.0f;
                _coefDrop = 1.0f;
                _coefGold = 1.0f;
                break;
            case (MonsterType.coldownCastObject):
                curmon.monsterBody = ColdownObjectBody;
                curmon.ClickStrengthCorrectiveVector = 10;
                _coefDamage = 1.0f;
                _coefHealth = 1.0f;
                curmon._coefArmor = 1.0f;
                _coefMagicResist = 1.0f;
                _coefExperiance = 1.0f;
                _coefDrop = 1.0f;
                _coefGold = 1.0f;
                break;
        }
        curmon.SaveClickStrengthCorrectiveVector = curmon.ClickStrengthCorrectiveVector;
        HealthPoints = BaseHealthPoints;
        //curmon.Damage //= BigMom.PP.CalculateHit() * _coefDamage ;
        
        Debug.Log("Coef " + _coefDamage);
        curmon.Expereance = BaseExpereance;
        curmon.DropChanse = BaseDropChanse;
        curmon.Armor = BaseArmor;
        curmon.Gold = BaseGold;
        curmon.MagResist = BaseMagResist;   
    }

    /*
     *  private void HealingSpellLogic()
    {
        if (BigMom.ENC.isHealerOnAMap)
        {
            if (CurrentHealColdown < 0)

            {
                if (currentMonster.CurrentHealth < currentMonster.BasicHealth/2f)
                {
                    
                }
  
          }



        }
    }

        private void HealDamagedTarget()
    {

        if (BigMom.ENC.isHealerOnAMap)
        {
           
        }



        if (_healthObjLockalScaleX < _healthbarMaxValue/2)
        {
         MonstersBasicClass randomMob =   BigMom.ENC.UsedMonstersList[Random.Range(1, BigMom.ENC.UsedMonstersList.Count)];

        }
    }
     * */


    public void FastTime()
    {
        BigMom.PP.timeDecreaseCoeficient = 0.35f;
    }


    public void catchMonstersAskAboutHeal(MonstersBasicClass current_monster)
    {
        //  Debug.Log("HEALLLLLLLLLLLLWHEREAREYOU");      
    //    if (!current_monster.AlreadyHealTarget) {
            foreach (MonstersBasicClass mob in BigMom.ENC.UsedMonstersList)
            {
                if (mob.TypeOfThisMonster == MonsterType.Healer && mob.HealColdown <= 0 )
            {
                    Debug.Log("HEEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAALLLLLLLLLLLLL");
                    StartHealCast(mob);
                 //   current_monster.AlreadyHealTarget = true;
                    current_monster.MonsterSaverForInvokeRepeating = current_monster;
                    return;
                }
            }
      //  }
    }


    public void checkExistingMonsterTypesInGame()
    {
     //   healersMonstersCount = 0;
        Debug.Log("Why Inwokes are not here???");
        foreach (MonstersBasicClass mob in BigMom.ENC.UsedMonstersList)
        {
            if (mob.TypeOfThisMonster == MonsterType.Healer)
            {
            //    healersMonstersCount += 1;
              //  BigMom.ENC.isHealerOnAMap = true;
            }
            if (mob.TypeOfThisMonster == MonsterType.Armored)
            {
                BigMom.ENC.isArmorBufferOnAMap = true;
            }
            
        }
    }




    public void ArmoredBuff(MonstersBasicClass curmonster)
    {
        
        if (BigMom.ENC.isArmorBufferOnAMap && curmonster.TypeOfThisMonster != MonstersBasicClass.MonsterType.coldownCastObject)
        {
            curmonster.ClickStrengthCorrectiveVector = 0.5f;
        }
        else
        {
           curmonster.ClickStrengthCorrectiveVector = curmonster.SaveClickStrengthCorrectiveVector;
        }
    }

    public void HealingAura(MonstersBasicClass curmonster)
    {

        if (BigMom.ENC.isHealerOnAMap && curmonster.HealthPoints < curmonster.BaseHealthPoints && curmonster.TypeOfThisMonster != MonstersBasicClass.MonsterType.Healer &&
            curmonster.TypeOfThisMonster != MonstersBasicClass.MonsterType.coldownCastObject)
        {
            float HealAuraCoeficient = 1f;
           
                curmonster.HealthPoints += BigMom.ENC.healersMonstersCount*HealAuraCoeficient * Time.deltaTime;
            
        }

    }

    public void StartHealCast(MonstersBasicClass curmonster)
    {
      //  if (curmonster.TypeOfThisMonster == MonsterType.Healer && curmonster.HealColdown <=0 )//&& curmonster == BigMom.ENC.HealersList[0])
      //  {
        //    bool isSomebodyNeedToBeHealed = false;
       //   foreach(MonstersBasicClass mob in BigMom.ENC.UsedMonstersList)
        //    {
          //      if (mob.HealthPoints < mob.BasicHealth * 0.5f)
            //    {
              //      isSomebodyNeedToBeHealed = true;
                //    return;
              //  }
          //  }
            
           // if (isSomebodyNeedToBeHealed)
           // {
                
                curmonster.HealColdown = HEAL_COLDOWN_WALUE;
             //   isSomebodyNeedToBeHealed = false;
                curmonster.HealCastTime = 4f;
              curmonster.StartHealCastSpelCountdown = true;
                curmonster.couldownBarValue = 0;
              //  MonsterSaverForInvokeRepeating.couldownBarValue = 0;
                Debug.Log("Neeed heal");
                //     InvokeRepeating("SpellColdown", 0, 1f);
                // InvokeRepeating("SpellColdown", 0, 1f);
                //   HealSomebody();
             //   BigMom.ENC.HealersList.RemoveAt(0);
             //   BigMom.ENC.HealersList.Add(curmonster);
           // }


          //  curmonster.CurrentHealth += 1f * Time.deltaTime;

       // }//

    }


    public void HealSomedsfbody()
    {
    //    StartCoroutine(HealCourutine());
    }

    public void HealSomebody()
    {
        //    yield return new WaitForSeconds(0.5f);

        Debug.Log("Im heled");
        float lowestHealth = 1000f;
        MonstersBasicClass weakestMonster = BigMom.ENC.UsedMonstersList[0];
        foreach (MonstersBasicClass mob in BigMom.ENC.UsedMonstersList)
        {
            if ( mob.HealthPoints < lowestHealth && !mob.AlreadyDead && mob.TypeOfThisMonster != MonsterType.Healer && BigMom.ENC.isHealerOnAMap)
            {
                lowestHealth = mob.HealthPoints;
                weakestMonster = mob;
            }
        }

       // if (weakestMonster.HealthPoints < weakestMonster.BasicHealth)
       // {
            float healValue = weakestMonster.BaseHealthPoints / 2.0f;

        //            if (weakestMonster.HealthPoints + healValue > weakestMonster.BasicHealth)
        // {
        //     healValue = weakestMonster.HealthPoints + healValue - weakestMonster.BasicHealth;
        // }

        if (healValue + weakestMonster.HealthPoints > weakestMonster.BaseHealthPoints)
        {
            weakestMonster.HealthPoints = weakestMonster.BaseHealthPoints;
        }
        else
        {
            weakestMonster.HealthPoints += healValue;
        }

          
       // }
        Debug.Log("Hearted monster HP = " + weakestMonster.HealthPoints.ToString() + " HealValue = " + healValue.ToString());
        //  BigMom.GC.TimeIsOutLetsEndThisGame = false;

    }


    public void SpellColdown(MonstersBasicClass Monster)
    {
       
        if (Monster.HealColdown > 0f)
        {
            Monster.HealColdown -= Time.deltaTime;
            // monstr.col
            Monster.couldownBarValue += MAX_SCALE_X_VALUE_FOR_COLDOWNBAR * (Time.deltaTime / HEAL_COLDOWN_WALUE);
        }
        else
        {
            Monster.HealColdown = -1f;
        }
    }

    public void killCast(MonstersBasicClass monstr)
    {

        if (monstr.coldownMonster != null)
        {
            monstr.coldownMonster.killmeNOW = true;
         //   monstr.StartHealCastSpelCountdown = false;
          //  HealSomebody();

        }
    }

    public void HealCastTimeCountdown (MonstersBasicClass monstr){
       
        if (monstr.TypeOfThisMonster == MonsterType.Healer && monstr.StartHealCastSpelCountdown) {
/*
            if (monstr.HealCastTime == 4.0f)
            {
                BigMom.ENC.BufferMonster = BigMom.ENC.spelCastMonster;
                Vector3 correctionVector;
                if(monstr.spawnSlot.y > 0)
                {
                    correctionVector = monstr.spawnSlot + new Vector3(0,monstr.spawnSlot.y * 2.4f, 0);
                }
                else
                {
                    correctionVector = monstr.spawnSlot - new Vector3(0, monstr.spawnSlot.y/2.0f, 0);
                }
                Instantiate(BigMom.ENC.spelCastMonster.monsterBody,  correctionVector , Quaternion.identity);
                  
                monstr.coldownMonster = BigMom.ENC.BufferMonster;
            }
            */
            monstr.HealCastTime -= Time.deltaTime;



            if (monstr.HealCastTime < 0f)
            {
                //  Debug.Log(monstr.coldownMonster.HealthPoints);
                //  if (monstr.coldownMonster.ColdownMonsterDestroted == true)
                //   {
               // monstr.coldownMonster.killmeNOW = true;
                monstr.StartHealCastSpelCountdown = false;
                HealSomebody();

                //     }
            }
                foreach (MonstersBasicClass mob in BigMom.ENC.UsedMonstersList)
                {
                   
                        mob.AlreadyHealTarget = false;
                    
                }
                      }
        }
    
    void LateUpdate()
    {
    //    checkExistingMonsterTypesInGame();
        //  HealCastTimeCountdown();
        //  SpellColdown();
    }

  
}
