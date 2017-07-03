using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class setTabActive : MonoBehaviour/*, IPointerClickHandler*/ {
/*
получаем три вкладки
и три контента
если контент актив (
	табу поднимаю размер и цвет ))ссс
)

*/
public GameObject skillsTab;
public GameObject invTab;
public GameObject statsTab;
public GameObject skillsContent;
public GameObject invContent;
public GameObject statsContent;

	// Update is called once per frame
	void Update () {

		if(skillsContent.activeInHierarchy){
			skillsTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 70);
			skillsTab.transform.Find("Tab Name").GetComponent<Text>().fontSize = 16;
			skillsTab.GetComponent<Image>().color =  new Color32(200,200,200,100);
		}
		if(invContent.activeInHierarchy){
			invTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 70);
			invTab.transform.Find("Tab Name").GetComponent<Text>().fontSize = 16;
			invTab.GetComponent<Image>().color =  new Color32(200,200,200,100);
		}
		if(statsContent.activeInHierarchy){
			statsTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 70);
			statsTab.transform.Find("Tab Name").GetComponent<Text>().fontSize = 16;
			statsTab.GetComponent<Image>().color =  new Color32(200,200,200,100);
		}
/*
шапки
		if(!skillsContent.activeInHierarchy){
			invTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);
			statsTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);
		}
		if(!invContent.activeInHierarchy){
			skillsTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);
			statsTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);

		}
		if(!statsContent.activeInHierarchy){
			invTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);
			skillsTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);

		}*/
	}
	/*
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
}
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
	}*/
}
