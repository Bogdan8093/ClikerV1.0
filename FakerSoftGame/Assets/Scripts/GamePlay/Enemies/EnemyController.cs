using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Events;
using System;

public class EnemyController : MonoBehaviour
{

    public static EnemyController current;           //A public static reference to itself (make's it visible to other objects without a reference)
    public GameObject[] monsters;                //Collection of prefabs to be poooled
    public GameObject[] spawnPoints;
    public List<GameObject>[] pooledMonsters;    //The actual collection of pooled objects
    public int[] amountToBuffer;                //The amount to pool of each object. This is optional
    public int defaultBufferAmount = 5;        //Default pooled amount if no amount abaove is supplied
    public bool canGrow = true;                 //Whether or not the pool can grow. Should be off for final builds

    GameObject containerObject;					//A parent object for pooled objects to be nested under. Keeps the hierarchy clean

    public List<GameObject> onMapMonsters;

    public float _scoreCounter = 0;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _topScoreText;

    void Awake()
    {
        //Ensure that there is only one object pool
        if (current == null)
            current = this;
        else
            Destroy(gameObject);

        //Create new container
        containerObject = new GameObject("ObjectPool");
        //Create new list for objects
        pooledMonsters = new List<GameObject>[monsters.Length];

        int index = 0;
        //For each prefab to be pooled...
        foreach (GameObject objectPrefab in monsters)
        {
            //...create a new array for the objects then...
            pooledMonsters[index] = new List<GameObject>();
            //...determine the amount to be created then...
            int bufferAmount;
            if (index < amountToBuffer.Length)
                bufferAmount = amountToBuffer[index];
            else
                bufferAmount = defaultBufferAmount;

            //...loop the correct number of times and in each iteration...
            for (int i = 0; i < bufferAmount; i++)
            {
                //...create the object...
                GameObject obj = Instantiate(objectPrefab);
                //...give it a name...
                obj.name = objectPrefab.name;
                //...and add it to the pool.
                PoolObject(obj);
            }
            //Go to the next prefab in the collection
            index++;
        }

    }

    void Start()
    {
        BigMom.Init();
    }

    public void SpawnMonsters()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            //Get a pooled explosion object
            GameObject obj = current.GetObject(monsters[UnityEngine.Random.Range(0, monsters.Length)]);
            if (obj != null)
            {
                //Set its position and rotation
                obj.transform.parent = current.containerObject.transform;
                obj.transform.position = spawnPoints[i].transform.position;
                obj.transform.rotation = spawnPoints[i].transform.rotation;
                obj.name = obj.name + i;
                //Activate it
                obj.SetActive(true);
                onMapMonsters.Add(obj);
            }

        }
        StartCoroutine(WaittoBuff(1.0f));
    }

    private IEnumerator WaittoBuff(float waitTime)
    {
        while (true)
        {
            BigMom.ENC.monsterBuff();
            yield return new WaitForSeconds(waitTime);
        }
        
    }

    public GameObject GetObject(GameObject objectType)
    {
        //Loop through the collection of prefabs...
        for (int i = 0; i < monsters.Length; i++)
        {
            //...to find the one of the correct type
            GameObject prefab = monsters[i];
            if (prefab.name == objectType.name)
            {
                //If there are any left in the pool...
                if (pooledMonsters[i].Count > 0)
                {
                    //...get it...
                    GameObject pooledObject = pooledMonsters[i][0];
                    //...remove it from the pool...
                    pooledMonsters[i].RemoveAt(0);
                    //...remove its parent...
                    pooledObject.transform.parent = null;
                    //...and return it
                    return pooledObject;

                }
                //Otherwise, if the pool is allowed to grow...
                else if (canGrow)
                {
                    //...write it to the log (so we know to adjust our values...
                    Debug.Log("pool grew when requesting: " + objectType + ". consider expanding default size.");
                    //...create a new one...
                    GameObject obj = Instantiate(monsters[i]) as GameObject;
                    //...give it a name...
                    obj.name = monsters[i].name;
                    //...and return it.
                    return obj;
                }
                //If we found the correct collection but it is empty and can't grow, break out of the loop
                break;

            }
        }

        return null;
    }

    public void ClearPool()
    {
        for (int i = 0; i < pooledMonsters.Length; i++)
        {
            pooledMonsters[i].Clear();
        }
    }

    public void PoolObject(GameObject obj)
    {
        //Find the correct pool for the object to go in to
        for (int i = 0; i < monsters.Length; i++)
        {
            if (monsters[i].name == obj.name)
            {
                //Deactivate it...
                obj.SetActive(false);
                //..parent it to the container...
                obj.transform.parent = containerObject.transform;
                //...and add it back to the pool
                pooledMonsters[i].Add(obj);
                return;
            }
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

    public bool isAllMonstersOnMapDead()
    {
        if (onMapMonsters.Count == 0)
        {
            return true;
        }
        return false;
    }

    public bool isPoolEmpty()
    {
        bool empty = false;
        for (int i = 0; i < pooledMonsters.Length; i++)
        {
            if (pooledMonsters[i].Count == 0)
            {
                empty = true;
            }
            else
                empty = false;
        }

        return empty;
    }

    public bool isWaveEnd()
    {
        if (isPoolEmpty() && isAllMonstersOnMapDead())
        {
            return true;
        }
        return false;
    }

    public void monsterBuff()
    {
        for (int i = 0; i < onMapMonsters.Count; i++)
        {
            if (onMapMonsters[i].name.Contains("Healer"))
            {
                healAllMonsters(2.0f);
               // Debug.Log("Buff");
            }
            if (onMapMonsters[i].name.Contains("TimeEater"))
            {
                GameTimer.current.timerSpeed = 2.0f;
            }
            else
            {
                GameTimer.current.timerSpeed = 1.0f;
            }
        }
    }

    public void healAllMonsters(float health)
    {
        for (int i = 0; i < onMapMonsters.Count; i++)
        {
            onMapMonsters[i].gameObject.GetComponent<MonsterClick>().currentMonster.HealthPoints += health;
            //Debug.Log("Helaed");
            if (onMapMonsters[i].GetComponent<MonsterClick>().currentMonster.HealthPoints > onMapMonsters[i].GetComponent<MonsterClick>().currentMonster.maxHealthPoints)
            {
                onMapMonsters[i].GetComponent<MonsterClick>().currentMonster.HealthPoints -= health;
            }
        }
    }

    public void setAllMonstersHP(float percentHP)
    {
        for (int i = 0; i < onMapMonsters.Count; i++)
        {
            onMapMonsters[i].gameObject.GetComponent<MonsterClick>().currentMonster.HealthPoints *=percentHP;
        }
    }
}
