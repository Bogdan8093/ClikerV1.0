using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class imgNoDisplay : MonoBehaviour {

    void Update () {
        if (this.transform.parent.GetComponent<Text> () != null) {
            if (string.IsNullOrEmpty (this.transform.parent.GetComponent<Text> ().text)) {
                this.GetComponent<Image> ().enabled = false;
            } else {
                if (this.GetComponent<Image> ().enabled == false) {
                    this.GetComponent<Image> ().enabled = true;
                }
            }
        }
    }
}