using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
// Скрипт действие - тут вызываются и исполняются основные действия над монстрами - непосредственно убывание здоровья
// реакция на стандартный клик персонажа. Анализ здоровья монстра и последующий вызов ивента на хил со стороны монстра хиллера
// Сложность в том что этот скрипт должен висеть на всех монстрах, по этому с этим нужно днликатно, если хотим тут добится данных
// от какого-то конкретного типа монстров, то проверяем его тип через главный монстер класс и отсеиваем ненужных

public class UsualClickerController : MonoBehaviour
{
    [SerializeField]
    public GameObject _healthBar;

    [SerializeField]
    private TextMesh _HealthText;

    [SerializeField]
    private GameObject Scars;

    private BoxCollider2D monsterHitbox;

    private Monster currentMonster;

    void Start()
    {
        monsterHitbox = gameObject.GetComponentInChildren<BoxCollider2D>();
        currentMonster = new Monster();
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
            _healthBar.transform.localScale = new Vector3(currentMonster.HealthPoints, 1f, 1f);
        }


    }

    void Update()
    {

        if (currentMonster.isDead())
        {
            BigMom.ENC.onMapMonsters.Remove(gameObject);
            Destroy(gameObject);
        }
    }




}
