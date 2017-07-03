using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class skillImage : MonoBehaviour {
/*
в грид добавляем катинки +
прокачка по очереди в гриде
(иф предведуший актив то этот можно активировать )
активация 5 поинтов
проверка на активность по тегу
если поинтов меньше 0 дебаг лог недостаточно поинто

GetComponent<RectTransform>().hierarchyCount
перейти в родителя 
узнать сколько потомков  = длина 3
узнать который из них интересен
*/
GameObject[] objectArr;
int spendpoints = 5;

	void Start(){
		objectArr = new GameObject[transform.childCount];
		for (int i = 0; i < objectArr.Length; i++)
		{
			objectArr[i] = transform.GetChild(i).gameObject;
			objectArr[i].AddComponent<EventTrigger>();
			EventTrigger trigger = objectArr[i].GetComponent<EventTrigger>();
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = EventTriggerType.PointerDown;
			entry.callback.AddListener((data)=>{mouseClick();});
			trigger.triggers.Add( entry );
		}
		// Debug.Log("конец фор");
	}
	void mouseClick(){
	   if(PlayerSkillPoints.skillPoints > 0){
		PlayerSkillPoints.skillPoints -= spendpoints;
	   }
	   else{
		   Debug.Log("недостаточно поинтов");
	   }   
	}
}
