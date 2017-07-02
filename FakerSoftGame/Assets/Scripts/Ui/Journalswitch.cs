using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Journalswitch : MonoBehaviour, IPointerClickHandler {
public GameObject Collections;
public GameObject quest;
public GameObject achivments;
public GameObject codecs;

public GameObject resetHeight1;
public GameObject resetHeight2;
private string currentTab;

void Start(){
	currentTab = gameObject.name;
}
void IPointerClickHandler.OnPointerClick(PointerEventData eventData){
	if(currentTab == "Tab_quest"){
		codecs.SetActive(false);
		Collections.SetActive(false);
        achivments.SetActive(false);
            quest.SetActive(true);
	}
	if(currentTab == "Tab_Collection"){
            codecs.SetActive(false);
            Collections.SetActive(true);
            achivments.SetActive(false);
            quest.SetActive(false);
        }
	if(currentTab == "Tab_codecs"){
            codecs.SetActive(true);
            Collections.SetActive(false);
            achivments.SetActive(false);
            quest.SetActive(false);
        }
        if (currentTab == "Tab_Achivment")
        {
            codecs.SetActive(false);
            Collections.SetActive(false);
            achivments.SetActive(true);
            quest.SetActive(false);
        }
        resetHeight1.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);
	resetHeight1.GetComponent<Image>().color = new Color32(255,255,255,255);
	resetHeight1.transform.Find("Tab Name").GetComponent<Text>().fontSize = 14;
	resetHeight2.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, 50);
	resetHeight2.GetComponent<Image>().color = new Color32(255,255,255,255);
	resetHeight2.transform.Find("Tab Name").GetComponent<Text>().fontSize = 14;
}
}