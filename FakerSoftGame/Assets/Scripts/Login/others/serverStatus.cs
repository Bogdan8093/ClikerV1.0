using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
public class serverStatus : MonoBehaviour {
	
    public Image status;
    string URL = "http://s2s.epac.to/api/";
    WWW w;

    IEnumerator Start () {
        status.color = Color.red;
        while (true) {
            w = new WWW (URL + "serverStatus");
            yield return new WaitUntil (() => w.isDone == true);
            if (w.text == "1") {
                status.color = Color.green;
                break;
            } else {
                yield return new WaitForSeconds (2.5f);
            }
        }
    }
}