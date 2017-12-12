using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
public class serverStatus : MonoBehaviour {

    public Image status;
    string URL;
    WWW w;

    IEnumerator Start() {
        URL = BigMom.GSV.URL;
        status.color = Color.red;
        while (true) {
            w = new WWW(URL + "check_status");
            yield return new WaitUntil(() => w.isDone == true);
            if (string.IsNullOrEmpty(w.error) || !string.IsNullOrEmpty(w.text)) {
                status.color = Color.green;
                yield return new WaitForSeconds(7.5f);
            } else {
                yield return new WaitForSeconds(2.5f);
            }
        }
    }
}