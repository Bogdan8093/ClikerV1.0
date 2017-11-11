using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sendConfirm : MonoBehaviour, IPointerClickHandler {
    public StatsUiScript SUS;
    void IPointerClickHandler.OnPointerClick (PointerEventData eventData) {
        if (SUS.StatFields[5].text != "Updating please wait") {
            StartCoroutine (SUS.Send ());
        } else {
            Debug.Log ("Сработала защита от постоянных кликов");
        }
    }
}