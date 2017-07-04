using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
// Скрипт действие - тут вызываются и исполняются основные действия над монстрами - непосредственно убывание здоровья
// реакция на стандартный клик персонажа. Анализ здоровья монстра и последующий вызов ивента на хил со стороны монстра хиллера
// Сложность в том что этот скрипт должен висеть на всех монстрах, по этому с этим нужно днликатно, если хотим тут добится данных
// от какого-то конкретного типа монстров, то проверяем его тип через главный монстер класс и отсеиваем ненужных

public class MonsterClick : MonoBehaviour
{
    public float Level = 1.0f;
    public string monsterType = "";
    public float CorrectionHealthPoints = 1.0f;
    public float CorrectionDamage = 1.0f;
    public float CorrectionExperience = 1.0f;
    public float CorrectionGold = 1.0f;
    public float CorrectionDropChanse = 1.0f;
    public float CorrectionArmor = 1.0f;
    public float CorrectionMagicResist = 1.0f;

    [SerializeField]
    private TextMesh _HealthText;
    [SerializeField]
    public GameObject _healthBar;
    [SerializeField]
    private GameObject Scars;

    private BoxCollider2D monsterHitbox;
    [HideInInspector]
    public Monster currentMonster;

    void Start()
    {
        monsterHitbox = gameObject.GetComponentInChildren<BoxCollider2D>();
        currentMonster = new Monster.Builder().coefArmor(CorrectionArmor).coefDC(CorrectionDropChanse).
            coefDmg(CorrectionDamage).coefGold(CorrectionGold).coefHP(CorrectionHealthPoints).
            coefMR(CorrectionMagicResist).coefXP(CorrectionExperience).build();
        currentMonster.setLevel(Level);
        currentMonster.monsterType = monsterType;
 
    }


    public Vector3 getScarsRandomPosition()
    {
        Vector3 ScarPosition = monsterHitbox.transform.position;
        float randomX = Random.Range(-monsterHitbox.size.x * 0.1f, monsterHitbox.size.x * 0.1f);
        float randomY = Random.Range(-monsterHitbox.size.y * 0.5f, monsterHitbox.size.y * 0.1f);

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
            ScarRotation.w);
        return ScarRotation;
    }

    public void OnMouseDown()
    {

        Instantiate(Scars, getScarsRandomPosition(), getScarsRandomRotation());
        Debug.Log(currentMonster.HealthPoints);
        if (!currentMonster.isDead())
        {

            currentMonster.HealthPoints -= BigMom.PP.CalculateHit(currentMonster);
            /*float calcHealth = ((4.19f * currentMonster.HealthPoints) / currentMonster.maxHealthPoints);
            if(calcHealth!=4.19f)
                _healthBar.transform.localScale = new Vector3(calcHealth, 1f, 1f);*/
        }


    }

    void Update()
    {
        float calcHealth = ((12.44f * currentMonster.HealthPoints) / currentMonster.maxHealthPoints);
            _healthBar.transform.localScale = new Vector3(calcHealth, 1f, 1f);

        if (currentMonster.isDead())
        {
            BigMom.ENC.onMapMonsters.Remove(gameObject);
            Destroy(gameObject);
        }
    }




}
