using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class setTabActive : MonoBehaviour {

public GameObject skillsTab;
public GameObject invTab;
public GameObject statsTab;
public GameObject skillsContent;
public GameObject invContent;
public GameObject statsContent;

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

	}
}
