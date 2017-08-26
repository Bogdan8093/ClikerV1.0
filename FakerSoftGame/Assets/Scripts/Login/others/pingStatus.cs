using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pingStatus : MonoBehaviour {
    string URL = "s2s.epac.to";
    public Text pingValue;
    void Start () {
        StartCoroutine (ping ());
    }
    IEnumerator ping () {
        while (true) {
            var dsa = new Ping (URL);
            yield return new WaitUntil (() => dsa.isDone == true);
            pingValue.text = "Ping: " + dsa.time + "ms";
            yield return new WaitForSeconds (1);
        }
    }
}