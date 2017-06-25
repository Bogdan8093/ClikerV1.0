using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class closeOpenCanvasUI : MonoBehaviour, IPointerClickHandler {
public GameObject closeUIObject;
public GameObject openUIObject;

void IPointerClickHandler.OnPointerClick(PointerEventData eventData){
	if(closeUIObject != null){
		closeUIObject.SetActive(false);
		Debug.Log(gameObject.name + " Закрывает " + closeUIObject.name);
	}
	if(openUIObject != null){
		openUIObject.SetActive(true);
		Debug.Log(gameObject.name + " Открывает " + openUIObject);
	}
	if(openUIObject && closeUIObject == null){
		Debug.Log("Не введены обьекты в " + gameObject.name);
	}
}
}
