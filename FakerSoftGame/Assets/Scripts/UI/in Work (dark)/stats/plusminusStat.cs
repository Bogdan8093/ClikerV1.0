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
            if (BigMom.SUS.TmpStats[0] > 0) {
                BigMom.SUS.TmpStats[0]--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.SUS.TmpStats[0] == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Strength") {
            if (BigMom.SUS.TmpStats[3] > 0) {
                BigMom.SUS.TmpStats[3]--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.SUS.TmpStats[3] == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Intellect") {
            if (BigMom.SUS.TmpStats[1] > 0) {
                BigMom.SUS.TmpStats[1]--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.SUS.TmpStats[1] == 0) {
                field.color = Color.black;
            }
        }
        if (this.transform.parent.name == "Stamina") {
            if (BigMom.SUS.TmpStats[2] > 0) {
                BigMom.SUS.TmpStats[2]--;
                currentPoints++;
                currentVal--;
                field.text = currentVal.ToString ();
                points.text = currentPoints.ToString ();
            }
            if (BigMom.SUS.TmpStats[2] == 0) {
                field.color = Color.black;
            }
        }
    }

    public void Plus () {
        currentPoints = int.Parse (points.text);
        currentVal = int.Parse (field.text);
        if (currentPoints > 0) {

            if (this.transform.parent.name == "Agility") {
                BigMom.SUS.TmpStats[0]++;
            }
            if (this.transform.parent.name == "Strength") {
                BigMom.SUS.TmpStats[3]++;
            }
            if (this.transform.parent.name == "Intellect") {
                BigMom.SUS.TmpStats[1]++;
            }
            if (this.transform.parent.name == "Stamina") {
                BigMom.SUS.TmpStats[2]++;
            }
            currentPoints--;
            currentVal++;
            field.text = currentVal.ToString ();
            points.text = currentPoints.ToString ();
            field.color = new Color (0, 0, 1, 1);
        }

    }
    void test(){

        
    }
}