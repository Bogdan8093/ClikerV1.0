using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class testget : MonoBehaviour, IPointerClickHandler {

    void IPointerClickHandler.OnPointerClick (PointerEventData eventData) {
		BigMom.DBF.externalStartStats();
    }
}