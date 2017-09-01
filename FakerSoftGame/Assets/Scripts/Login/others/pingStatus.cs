using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pingStatus : MonoBehaviour {
    private string URL;
    public Text pingValue;
    void Start () {
        URL = BigMom.GSV.pURL;
        StartCoroutine (ping ());
    }
    IEnumerator ping () {
        while (true) {
            var dsa = new Ping (URL);
            yield return new WaitUntil (() => dsa.isDone == true);
            if (pingValue != null) {
                pingValue.text = "Ping: " + dsa.time + "ms";
            }
            if (dsa.time >= 0) {
                BigMom.GSV.status = true;
            } else {
                BigMom.GSV.status = false;
            }
            yield return new WaitForSeconds (1);
        }
    }
}