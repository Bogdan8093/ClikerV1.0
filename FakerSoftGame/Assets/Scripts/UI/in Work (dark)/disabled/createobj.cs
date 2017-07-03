using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createobj : MonoBehaviour {
     //store gameObject reference
 private GameObject EmptyObj;
 
 void Start()
 {
     EmptyObj = new GameObject("Bought");
     EmptyObj.transform.SetParent(this.transform, true);
 }
 	// void buying()
	// {
	// 	Buying = new GameObject("Bought");
	// 	buying.Re
	// 	Buying.AddComponent<RectTransform>();
	// 	Buying.transform.SetParent(this.transform, true);
	// 	Buying.transform.localScale = new Vector3(0,0,0);
	// }
    }
