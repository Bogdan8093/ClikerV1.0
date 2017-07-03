using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plusminusStat : MonoBehaviour {
    public Text field, points;
    private int currentVal, currentPoints;

    public void Minus () {
        currentPoints = int.Parse (points.text);
        currentVal = int.Parse (field.text);
        if (this.transform.parent.name == "Agility") {
            if (tempStats.AGI > 0) {
				tempStats.AGI--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (tempStats.AGI == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Strength") {
            if (tempStats.STR > 0) {
                tempStats.STR--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (tempStats.STR == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Intellect") {
            if (tempStats.INT > 0) {
				tempStats.INT--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (tempStats.INT == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Stamina") {
            if (tempStats.STA > 0) {
				tempStats.STA--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (tempStats.STA == 0) {
                field.color = Color.black;
            }
        }
    }

    public void Plus () {
        currentPoints = int.Parse (points.text);
        currentVal = int.Parse (field.text);
        if (currentPoints > 0) {

            if (this.transform.parent.name == "Agility") {
                tempStats.AGI++;
            }
            if (this.transform.parent.name == "Strength") {
                tempStats.STR++;
            }
            if (this.transform.parent.name == "Intellect") {
                tempStats.INT++;
            }
            if (this.transform.parent.name == "Stamina") {
                tempStats.STA++;
            }
            currentPoints--;
            currentVal++;
            field.text = currentVal.ToString ();
            points.text = currentPoints.ToString ();
            field.color = new Color (0, 0, 1, 1);
        }

    }
}