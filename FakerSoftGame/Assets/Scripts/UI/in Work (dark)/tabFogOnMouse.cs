using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class tabFogOnMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
void IPointerEnterHandler.OnPointerEnter (PointerEventData eventData){
this.GetComponent<Image>().color = new Color32(150,150,150,100);
}
void IPointerExitHandler.OnPointerExit (PointerEventData eventData){
GetComponent<Image>().color = new Color32(255,255,255,255);
}
}