using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class sendParamButton : MonoBehaviour, IPointerClickHandler {
    private StatsUiScript SUS;
    private bool direction;
    private int record;
    void Start () {
        SUS = this.transform.parent.parent.GetComponent<StatsUiScript> ();
        if (this.name.Contains ("Plus")) {
            direction = true;
        }
        switch (this.transform.parent.name) {
            case "Agility":
                record = 1;
                break;
            case "Intellect":
                record = 2;
                break;
            case "Stamina":
                record = 3;
                break;
            case "Strength":
                record = 4;
                break;
        }
    }
		// void IPointerDownHandler.OnPointerDown(PointerEventData eventData){
		// 	while(int.Parse(SUS.StatFields[0].text)>0){
		// 		SUS.StatAssignment (direction, record);
		// 	}
		// }
    void IPointerClickHandler.OnPointerClick (PointerEventData eventData) {
        SUS.StatAssignment (direction, record);
    }
}