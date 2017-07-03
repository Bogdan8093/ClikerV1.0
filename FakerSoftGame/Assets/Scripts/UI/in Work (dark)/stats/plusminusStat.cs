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
            if (BigMom.TS.AGI > 0) {
				BigMom.TS.AGI--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.TS.AGI == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Strength") {
            if (BigMom.TS.STR > 0) {
                BigMom.TS.STR--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.TS.STR == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Intellect") {
            if (BigMom.TS.INT > 0) {
				BigMom.TS.INT--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.TS.INT == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Stamina") {
            if (BigMom.TS.STA > 0) {
				BigMom.TS.STA--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.TS.STA == 0) {
                field.color = Color.black;
            }
        }
    }

    public void Plus () {
        currentPoints = int.Parse (points.text);
        currentVal = int.Parse (field.text);
        if (currentPoints > 0) {

            if (this.transform.parent.name == "Agility") {
                BigMom.TS.AGI++;
            }
            if (this.transform.parent.name == "Strength") {
                BigMom.TS.STR++;
            }
            if (this.transform.parent.name == "Intellect") {
                BigMom.TS.INT++;
            }
            if (this.transform.parent.name == "Stamina") {
                BigMom.TS.STA++;
            }
            currentPoints--;
            currentVal++;
            field.text = currentVal.ToString ();
            points.text = currentPoints.ToString ();
            field.color = new Color (0, 0, 1, 1);
        }

    }
}