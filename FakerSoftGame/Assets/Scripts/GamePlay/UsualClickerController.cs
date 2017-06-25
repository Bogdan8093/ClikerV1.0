using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class UsualClickerController : MonoBehaviour {

    private BoxCollider2D _enemyHitbox;

    [SerializeField]
    public GameObject _healthBar;

    [SerializeField]
    private  TextMesh _HealthText;

    private float  coldownBarVelue;

    
    public GameObject ColdownBar;

    [SerializeField]
    private GameObject Scars;

    public GameObject Monster;


   

    

    private const float MAX_SCALE_X_VALUE_FOR_HEALTHBAR = 12.4f;
    private const float BASE_HEALTH_DECREESE_COEFICIENT = 0.01f;
    private float _clickStrength;
    private float _healthObjLockalScaleX;
    private float _healthbarMaxValue;
    private float critChanse = 1.05f;
    private BoxCollider2D _monsterHitbox;

    private float MonsterArmorLevel;

    public bool stopFastDecreaseTime = true;

    private float correctiveHitStrangth;
    // public EnemyController gg = new EnemyController();
    private MonstersBasicClass currentMonster;

    private float CurrentHealColdown = 5f;
    private const float CONST_HEAL_COLDON = 30f;

   

    void Start()
    {
     _healthObjLockalScaleX = _healthBar.transform.localScale.x;
        
        if(ColdownBar!= null)
        coldownBarVelue = ColdownBar.transform.localScale.x;

        _healthbarMaxValue = _healthObjLockalScaleX;
        _monsterHitbox = Monster.GetComponent<BoxCollider2D>();
        correctiveHitStrangth = BigMom.ENC.ClickStrengthCorrective;
        currentMonster = BigMom.ENC.BufferMonster;
      
      //  else
     //   {
     //       currentMonster.ColdownMonsterDestroted = true;
   //    }
        currentMonster.BaseHealthPoints = BigMom.PP._monsterHealth;
      //  checkMonsterType();
      // BigMom.ENC.MonsterWasKilled_E.AddListener(checkMonsterType);
       // currentMonster.BaseHealthPoints = _healthbarMaxValue;
        currentMonster.HealthPoints = currentMonster.BaseHealthPoints;
        //  currentMonster.checkExistingMonsterTypesInGame();
        CheckMonstersTypesOnMapForEachExistingMonster();

        if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.Healer)
        {
            BigMom.ENC.HealersList.Add(currentMonster);
            BigMom.ENC.healersMonstersCount += 1;
            
            if(BigMom.ENC.healersMonstersCount > 0)
            {
                BigMom.ENC.isHealerOnAMap = true;
                Debug.Log("Healer monsters count ATSTART = " + BigMom.ENC.healersMonstersCount.ToString());
            }
            Debug.Log("What can you say about healers?  : " + BigMom.ENC.healersMonstersCount.ToString() + "Is HEaler on map " + BigMom.ENC.isHealerOnAMap.ToString());
        }
      //  currentMonster.killmeNOW = false;
        

    }

    private void CheckMonstersTypesOnMapForEachExistingMonster (){
        foreach(MonstersBasicClass monster in BigMom.ENC.UsedMonstersList)
        {
            monster.checkExistingMonsterTypesInGame();
            
        }
        
    }

    


    public Vector3 getScarsRandomPosition()
    {
       Vector3 ScarPosition =  _monsterHitbox.transform.position;
        float randomX = Random.Range(-BigMom.ENC._monsterHitbox.size.x * 0.1f, BigMom.ENC._monsterHitbox.size.x * 0.1f);
        float randomY = Random.Range(-BigMom.ENC._monsterHitbox.size.y * 0.5f, BigMom.ENC._monsterHitbox.size.y * 0.1f);

        ScarPosition = new Vector3(
            ScarPosition.x + randomX,
            ScarPosition.y + randomY,
            ScarPosition.z
            
            );
        return ScarPosition;
    }

    public Quaternion getScarsRandomRotation()
    {
        Quaternion ScarRotation = Scars.transform.rotation;
        ScarRotation = new Quaternion(
            ScarRotation.x,
            ScarRotation.y,
            Random.rotation.z,
            ScarRotation.w );
        return ScarRotation;
    }


   

    private void checkMonsterType ()
    {
        if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.Healer)
        {
        //    BigMom.ENC.isHealerOnAMap = true;
        }
      
        if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.Armored) {
       //     BigMom.ENC.isArmorBufferOnAMap = true;
        }
    }

    public void killColdownMonster()
    {
        if (currentMonster.TypeOfThisMonster ==  MonstersBasicClass.MonsterType.coldownCastObject && currentMonster.killmeNOW == true)
        {
            currentMonster.killmeNOW = false;
            Destroy(Monster, 0.0f);
           
        }

    }

    public void KillMonster()
    {
        if (currentMonster.TypeOfThisMonster != MonstersBasicClass.MonsterType.coldownCastObject)
        {
            foreach (MonstersBasicClass mob in BigMom.ENC.UsedMonstersList)
            {
                if (mob.MonsterPresonalNumber == currentMonster.MonsterPresonalNumber)
                {
                    //BigMom.ENC.UsedMonstersList.RemoveAt(currentMonster.MonsterPresonalNumber);
                   
                    Debug.Log( mob.TypeOfThisMonster.ToString() + " Deleted " + " Monsters Left: " + BigMom.ENC.UsedMonstersList.Count.ToString()  );
                    for (int i = 0; i < BigMom.ENC.UsedMonstersList.Count; i++)
                    {
                        Debug.Log("Monster " + i + " = " + BigMom.ENC.UsedMonstersList[i].TypeOfThisMonster.ToString());
                    }
                    break;
                }
                
                // checkMonsterType();
            }


            if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.TimeEater)
                BigMom.PP.setNormalTimeDecrease();



            if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.Armored)
            {
                BigMom.ENC.isArmorBufferOnAMap = false;
            }
            if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.Healer)
            {
              //  Debug.Log("Healer monsters count = " + BigMom.ENC.healersMonstersCount.ToString());
                BigMom.ENC.healersMonstersCount -= 1;
                if (BigMom.ENC.healersMonstersCount < 0)
                {
                    BigMom.ENC.isHealerOnAMap = false;
               //     Debug.Log("Healer monsters count = " + BigMom.ENC.healersMonstersCount.ToString());
                }
               // BigMom.ENC.healersMonstersCount = 0;
            //    Debug.Log("StoooopHeal " + BigMom.MBC.healersMonstersCount.ToString());
            }


            Destroy(Monster, 0.0f);
        //    BigMom.GC.MonsterWasKilled_E.Invoke();
            StartCoroutine(WaitAfterDeath());
            BigMom.ENC.UpdateScore();
            
        }
        else
        {
            currentMonster.killmeNOW = true;
            currentMonster.ColdownMonsterDestroted = false;

        }
        //  BigMom.ENC.UsedMonstersList.Remove(currentMonster);
        currentMonster.AlreadyDead = true;
        for (int i = 0; i < BigMom.ENC.UsedMonstersList.Count; i++)
        {
            Debug.Log("MOnstersLeft:  " + BigMom.ENC.UsedMonstersList.Count.ToString() + " MonsterType " + BigMom.ENC.UsedMonstersList[i].TypeOfThisMonster.ToString());
        }
        BigMom.MBC.checkExistingMonsterTypesInGame();
    }

    IEnumerator WaitAfterDeath()
    {
        yield return new WaitForSeconds(0.1f);
        //   BigMom.ENC.MonsterWasKilled_E.Invoke();
        //  checkMonsterType();
    }


   


    private void ongoingProcesses()
    {
        //   currentMonster.CurrentHealth = _healthObjLockalScaleX;
       // checkMonsterType();
        if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.TimeEater)
        {
            currentMonster.FastTime();
            }
        float converted_health = ((100 / currentMonster.BaseHealthPoints * currentMonster.HealthPoints) * MAX_SCALE_X_VALUE_FOR_HEALTHBAR) / 100;

        _HealthText.text = System.Math.Round(currentMonster.HealthPoints, 0).ToString() + "/" + currentMonster.BaseHealthPoints.ToString();
            _healthBar.transform.localScale = new Vector3(converted_health, 1f, 1f);
        if (ColdownBar != null)
            ColdownBar.transform.localScale = new Vector3(currentMonster.couldownBarValue, 1f, 1f);

     if(currentMonster.HealthPoints > currentMonster.BaseHealthPoints)
        {
            currentMonster.HealthPoints = currentMonster.BaseHealthPoints;
        }

    }


    public void startHeal()
    {
        if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.Healer) {
            Debug.Log("WOOOOORRRRRRKKKOOOOUUUTTT");
   //         currentMonster.StartHealCast(currentMonster);
        }
    }
    

    


    public void OnMouseDown() 
    {

        Instantiate(Scars, getScarsRandomPosition(), getScarsRandomRotation());

        if (currentMonster.HealthPoints > 0)
        {


            _clickStrength =  BigMom.PP.CalculateHit(currentMonster);
         //   Debug.Log(_clickStrength);
            //Debug.Log(currentMonster.ClickStrengthCorrectiveVector);
            currentMonster.HealthPoints -= _clickStrength;
            

           // _healthBar.transform.localScale = new Vector3(currentMonster.HealthPoints, 1f, 1f);  
          //  BigMom.ENC.UpdateScore(); // we really need this?

        }
        Debug.Log("XP = " + currentMonster.HealthPoints.ToString());
        if (currentMonster.HealthPoints < 1)
        {
            if (currentMonster.TypeOfThisMonster != MonstersBasicClass.MonsterType.coldownCastObject)
            {
                BigMom.ENC.countAliveMonsters--;
                if (BigMom.ENC.countAliveMonsters < 1)
                {
                    BigMom.ENC.StartCorutineOutside();
                }
                BigMom.ENC._scoreCounter++;
            }
            
            KillMonster();
            BigMom.MBC.killCast(currentMonster);
        }
            

      //  Debug.Log(_healthObjLockalScaleX);
    }


    

    void Update()
    {
        Debug.Log(currentMonster.TypeOfThisMonster.ToString());
        ongoingProcesses();
        _healthBar.transform.localScale = new Vector3(currentMonster.HealthPoints, 1f, 1f);
        // HealingAura();
        currentMonster.ArmoredBuff(currentMonster);
        
        currentMonster.HealCastTimeCountdown(currentMonster);
        currentMonster.HealingAura(currentMonster);

        if (currentMonster.HealthPoints < currentMonster.BaseHealthPoints * 0.5f && currentMonster.TypeOfThisMonster != MonstersBasicClass.MonsterType.Healer)
        {

            currentMonster.catchMonstersAskAboutHeal(currentMonster) ;
        }
        currentMonster.SpellColdown(currentMonster);

        //  else { goToUsualSettings(); }

        if (BigMom.GC.TimeIsOutLetsEndThisGame)
        {
            
                KillMonster();
            if (currentMonster.TypeOfThisMonster == MonstersBasicClass.MonsterType.TimeEater)
            { stopFastDecreaseTime = true; }
            BigMom.ENC.WaitingForDestroying();        
        }

        CurrentHealColdown -= Time.deltaTime;


        killColdownMonster();

    }
   

  

}
