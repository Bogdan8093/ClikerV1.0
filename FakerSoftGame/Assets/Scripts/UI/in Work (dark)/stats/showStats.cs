using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class showStats : MonoBehaviour {
    public Text points, Agi, Str, Sta, Int;
    IEnumerator Start () {
        yield return new WaitUntil (() => BigMom.DBF.readyCheck == true);
        points.text = BigMom.DBF.PT.ToString ();
        Agi.text = BigMom.DBF.AGI.ToString ();
        Str.text = BigMom.DBF.STR.ToString ();
        Sta.text = BigMom.DBF.STA.ToString ();
        Int.text = BigMom.DBF.INT.ToString ();
    }
}