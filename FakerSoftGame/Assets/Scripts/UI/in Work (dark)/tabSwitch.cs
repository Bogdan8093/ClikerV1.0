using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tabSwitch : MonoBehaviour, IPointerClickHandler {
private GameObject skills;
private GameObject inv;
private GameObject stats;
private string currentTab;
private string teststr;
void Start(){
	currentTab = gameObject.name;
	skills = transform.parent.parent.Find("content").Find("skills").gameObject;
	inv = transform.parent.parent.Find("content").Find("inv").gameObject;
	stats = transform.parent.parent.Find("content").Find("stats").gameObject;
	// Debug.Log("skill tab = "+skills.name);
}
/*
если куртаб = таблефт
то вырубить инвентарь и статсы


*/
void IPointerClickHandler.OnPointerClick(PointerEventData eventData){
	if(currentTab == "Tab_left"){
		inv.SetActive(false);
		stats.SetActive(false);
		skills.SetActive(true);
	}
	if(currentTab == "Tab_middle"){
		inv.SetActive(true);
		stats.SetActive(false);
		skills.SetActive(false);
	}
	if(currentTab == "Tab_right"){
		inv.SetActive(false);
		stats.SetActive(true);
		skills.SetActive(false);
	}
}
}