using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Events;


public class EnemyController : MonoBehaviour
{

    public GameObject Monster;
    public GameObject spawnSpot1;
    public GameObject spawnSpot2;
    public GameObject spawnSpot3;
    public GameObject spawnSpot4;
    public GameObject spawnSpot5;
    public float timeDecreaseCoeficient = 0.1f;
    [HideInInspector]
    public int countAliveMonsters = 0;

    [HideInInspector]
    public bool isHealerOnAMap = false;

    [HideInInspector]
    public float healersMonstersCount = 0;

    [HideInInspector]
    public bool isArmorBufferOnAMap = false;

    [HideInInspector]
    public float ClickStrengthCorrective = 1.0f;


    public List<MonstersBasicClass> HealersList = new List<MonstersBasicClass>();

    private List<Vector3> _spwnPointsList = new List<Vector3>();
    private List<MonstersBasicClass> _MonstersList = new List<MonstersBasicClass>();

    [HideInInspector]
    public List<MonstersBasicClass> UsedMonstersList = new List<MonstersBasicClass>();

    public MonstersBasicClass BasicMonster;
    private List<MonstersBasicClass.MonsterType> _monsterTypesList = new List<MonstersBasicClass.MonsterType>();

    public BoxCollider2D _monsterHitbox;

    public MonstersBasicClass BufferMonster;

    private MonstersBasicClass monster1;
    private MonstersBasicClass monster2;
    private MonstersBasicClass monster3;
    private MonstersBasicClass monster4;
    private MonstersBasicClass monster5;

    [HideInInspector]
    public MonstersBasicClass spelCastMonster;


    public MonstersBasicClass CreatedMonster1;
    public MonstersBasicClass CreatedMonster2;
    public MonstersBasicClass CreatedMonster3;



    public float _scoreCounter = 0;

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _topScoreText;

    void Start()
    {
        BigMom.Init();

        _spwnPointsList.Add(spawnSpot1.transform.position);
        _spwnPointsList.Add(spawnSpot2.transform.position);
        _spwnPointsList.Add(spawnSpot3.transform.position);
        _spwnPointsList.Add(spawnSpot4.transform.position);
        _spwnPointsList.Add(spawnSpot5.transform.position);


        monster1 = new MonstersBasicClass();
        monster2 = new MonstersBasicClass();
        monster3 = new MonstersBasicClass();
        monster4 = new MonstersBasicClass();
        monster5 = new MonstersBasicClass();
        spelCastMonster = new MonstersBasicClass();

        _monsterTypesList = BigMom.MBC.MonsterTypesList;
        initMonsters();

        _MonstersList.Add(monster1);
        _MonstersList.Add(monster2);
        _MonstersList.Add(monster3);
        _MonstersList.Add(monster4);
        _MonstersList.Add(monster5);


        _monsterHitbox = Monster.GetComponent<BoxCollider2D>();
        //  SpawnEnemy();
        _topScoreText.text = "BestScore: " + PlayerPrefs.GetFloat("BestScore").ToString();
        int randomInt = UnityEngine.Random.Range(1, 5);
        countAliveMonsters = randomInt;
        SpawnMonsters(countAliveMonsters);

        Debug.Log(monster1.TypeOfThisMonster.ToString());
        Debug.Log(monster2.TypeOfThisMonster.ToString());
        Debug.Log(monster3.TypeOfThisMonster.ToString());
    }

    public void DestroyAllMobs()
    {
        Destroy(monster1);
        Destroy(monster2);
        Destroy(monster3);
        Destroy(monster4);
        Destroy(monster5);
    }

    public void WaitingForDestroying()
    {
        StartCoroutine(WaitingForMonstersDeath());
    }

    public IEnumerator WaitingForMonstersDeath()
    {
        yield return new WaitForSeconds(0.1f);
        BigMom.GC.TimeIsOutLetsEndThisGame = false;


    }
    public void SpawnMonstersAfterDeath()
    {
        _spwnPointsList.Clear();
        _monsterTypesList.Clear();
        _MonstersList.Clear();

        _spwnPointsList.Add(spawnSpot1.transform.position);
        _spwnPointsList.Add(spawnSpot2.transform.position);
        _spwnPointsList.Add(spawnSpot3.transform.position);
        _spwnPointsList.Add(spawnSpot4.transform.position);
        _spwnPointsList.Add(spawnSpot5.transform.position);

        monster1 = new MonstersBasicClass();
        monster2 = new MonstersBasicClass();
        monster3 = new MonstersBasicClass();
        monster4 = new MonstersBasicClass();
        monster5 = new MonstersBasicClass();
        spelCastMonster = new MonstersBasicClass();

        _monsterTypesList.Add(MonstersBasicClass.MonsterType.Armored);
        _monsterTypesList.Add(MonstersBasicClass.MonsterType.Healer);
        _monsterTypesList.Add(MonstersBasicClass.MonsterType.TimeEater);
        _monsterTypesList.Add(MonstersBasicClass.MonsterType.Usual);

        Debug.Log(_monsterTypesList.Count.ToString() + " ddddddddddd");

        initMonsters();

        _MonstersList.Add(monster1);
        _MonstersList.Add(monster2);
        _MonstersList.Add(monster3);
        _MonstersList.Add(monster4);
        _MonstersList.Add(monster5);

        countAliveMonsters = UnityEngine.Random.Range(1, 5);
        SpawnMonsters(countAliveMonsters);
    }


    public void initMonsters()
    {
        BigMom.MBC.initMonster(GetRandomMonsterType(_monsterTypesList), choseRandomSpawnSpot(), monster1);
        BigMom.MBC.initMonster(GetRandomMonsterType(_monsterTypesList), choseRandomSpawnSpot(), monster2);
        BigMom.MBC.initMonster(GetRandomMonsterType(_monsterTypesList), choseRandomSpawnSpot(), monster3);
        BigMom.MBC.initMonster(GetRandomMonsterType(_monsterTypesList), choseRandomSpawnSpot(), monster4);
        BigMom.MBC.initMonster(GetRandomMonsterType(_monsterTypesList), choseRandomSpawnSpot(), monster5);
        BigMom.MBC.initMonster(MonstersBasicClass.MonsterType.coldownCastObject, new Vector3(0, 0, 0), spelCastMonster);
    }

    public Vector3 GetRandmSpawnPointAndRemove(List<Vector3> list)
    {
        int randomID = UnityEngine.Random.Range(0, list.Count);
        Vector3 RandomPoint = list[randomID];
        list.RemoveAt(randomID);
        return RandomPoint;
    }


    public MonstersBasicClass.MonsterType GetRandomMonsterType(List<MonstersBasicClass.MonsterType> list)
    {
        int randomID = UnityEngine.Random.Range(0, list.Count);
        MonstersBasicClass.MonsterType RandomMonsterType = list[randomID];
        //  list.RemoveAt(randomID);
        return RandomMonsterType;
    }


    public MonstersBasicClass GetRandomMonsterAndRemove(List<MonstersBasicClass> list)
    {
        int randomID = UnityEngine.Random.Range(0, list.Count);
        MonstersBasicClass RandomMonster = list[randomID];
        list.RemoveAt(randomID);
        return RandomMonster;
    }


    public void SpawnMonsters(int monstersValue)
    {
        StartCoroutine(spawnAndWait(monstersValue));

    }

    public IEnumerator spawnAndWait(int MV)
    {
        MonstersBasicClass current_monster;
        UsedMonstersList.Clear();
        for (int i = 0; i < MV; i++)
        {
            current_monster = GetRandomMonsterAndRemove(_MonstersList);
            //  _UsedMonstersList.Add(current_monster);

            yield return new WaitForSeconds(0.1f);
            Instantiate(current_monster.monsterBody, current_monster.spawnSlot, Quaternion.identity);
            current_monster.MonsterPresonalNumber = i;
            ClickStrengthCorrective = current_monster.ClickStrengthCorrectiveVector;
            BufferMonster = current_monster;
            //  BigMom.MBC.initMonster(GetRandomMonsterTypeAndRemove(_monsterTypesList), choseRandomSpawnSpot(), monster1);
            if (current_monster.TypeOfThisMonster != MonstersBasicClass.MonsterType.coldownCastObject)
            {
                UsedMonstersList.Add(current_monster);
            }
        }
        for (int i = 0; i < UsedMonstersList.Count; i++)
        {
            Debug.Log("Used Monsters" + UsedMonstersList[i].TypeOfThisMonster.ToString());
        }
    }

    public void UpdateScore()
    {

        _scoreText.text = "Score: " + _scoreCounter.ToString();
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (PlayerPrefs.GetFloat("BestScore") < _scoreCounter)
            {
                PlayerPrefs.SetFloat("BestScore", _scoreCounter);
            }
        }
        else
            PlayerPrefs.SetFloat("BestScore", _scoreCounter);
        _topScoreText.text = "BestScore: " + PlayerPrefs.GetFloat("BestScore").ToString();
    }

    public Vector3 choseRandomSpawnSpot()
    {
        Vector3 MonsterPosition;
        MonsterPosition = GetRandmSpawnPointAndRemove(_spwnPointsList);

        MonsterPosition = new Vector3( MonsterPosition.x,
          MonsterPosition.y + _monsterHitbox.size.y * 0.4f,
          MonsterPosition.z  );
        return MonsterPosition;
    }

    public void StartCorutineOutside()
    {
        StartCoroutine(SpawnNewMonsterAfterDeath());
    }

    public IEnumerator SpawnNewMonsterAfterDeath()
    {

        //  _scoreCounter++;
        //   UpdateScore();
        yield return new WaitForSeconds(1.0f);

        SpawnMonstersAfterDeath();
    }

    public void SpawnEnemy()
    {
        Vector3 MonsterPosition = choseRandomSpawnSpot();


        //   Instantiate(Monster, MonsterPosition, Quaternion.identity);
    }
    //set all monsters hp in percents
    public void setAllMonstersHP(float percent)
    {
        for (int i = 0; i < UsedMonstersList.Count; i++)
        {
            Debug.Log(UsedMonstersList[i].CurrentHealth);
            UsedMonstersList[i].HealthPoints= UsedMonstersList[i].HealthPoints * percent;

        }

    }
}
