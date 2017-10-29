using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUiScript : MonoBehaviour {
    // public Text AGI, STR, STA, INT;
    // agi str sta int
    // public Text[] stats = new Text[4];
    // public Text texts[5], getPoints;
    // private int[] statArr = new int[4];
    [HideInInspector]
    public int[] TmpStats = new int[4];
    public Text[] StatFields = new Text[6];
    IEnumerator Start () {
        yield return new WaitUntil (() => BigMom.DBF.LVL != 0);
        reWriteStats ();
    }
    // /*
    public IEnumerator Send () {
        if (int.Parse (StatFields[0].text) != BigMom.DBF.PT) {
            StatFields[5].text = "Updating please wait";
            WWWForm form = new WWWForm ();
            if (TmpStats[0] > 0) {
                form.AddField ("AGI", TmpStats[0]);
            }
            if (TmpStats[1] > 0) {
                form.AddField ("INT", TmpStats[1]);
            }
            if (TmpStats[2] > 0) {
                form.AddField ("STA", TmpStats[2]);
            }
            if (TmpStats[3] > 0) {
                form.AddField ("STR", TmpStats[3]);
            }

            form.AddField ("userID", BigMom.DBF.ID);
            WWW w = BigMom.DBF.requst ("UpdateStats", form);
            yield return new WaitUntil (() => w.isDone == true);
            Reset ();
            BigMom.DBF.externalGetStats ();
            yield return new WaitUntil (() => BigMom.DBF.UpdatingStats == false);
            reWriteStats ();
            StatFields[5].text = "Success!";
            yield return new WaitForSeconds (2);
            StatFields[5].text = "";
        } else {
            StatFields[5].text = "Вы не распределили характеристики";
        }
    }
    // */
    void Reset () {
        for (int i = 0; i < TmpStats.Length; i++) {
            TmpStats[i] = 0;
        }
        foreach (Text item in StatFields) {
            item.color = Color.black;
        }
    }
    public void reWriteStats () {
        StatFields[0].text = BigMom.DBF.PT.ToString ();
        StatFields[1].text = BigMom.DBF.AGI.ToString ();
        StatFields[2].text = BigMom.DBF.INT.ToString ();
        StatFields[3].text = BigMom.DBF.STA.ToString ();
        StatFields[4].text = BigMom.DBF.STR.ToString ();
    }
}