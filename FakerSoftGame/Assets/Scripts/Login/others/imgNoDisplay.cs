using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imgNoDisplay : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        if (this.transform.parent.GetComponent<InputField> () != null) {
            if (string.IsNullOrEmpty (this.transform.parent.GetComponent<InputField> ().textComponent.text)) {
                this.GetComponent<Image> ().enabled = false;
            } else {
                if (this.GetComponent<Image> ().enabled == false) {
                    this.GetComponent<Image> ().enabled = true;
                }
            }
        }
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