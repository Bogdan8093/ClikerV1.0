using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent (typeof (InputField))]
public class inputtest : MonoBehaviour, ISubmitHandler {
// 	BaseEventData dsad;
// void Start(){
// 	this.GetComponent<InputField>().OnSubmit(dsad);
// }
	void Update(){
		// Debug.Log(EventSystem.current.currentSelectedGameObject);
	}
    public void OnSubmit (BaseEventData eventData) {
        Debug.Log ("'test'");
    }
}