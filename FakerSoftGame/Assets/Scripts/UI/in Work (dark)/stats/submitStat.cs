using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class submitStat : MonoBehaviour, IPointerClickHandler {
    public Text AGI, STR, STA, INT;
    public Text showLog, getPoints;
    private int id;
    
    // WWWForm form;
    // public WWWForm form;
    IEnumerator Start () {
        yield return new WaitUntil (() => BigMom.DBF.readyCheck == true);
        id = BigMom.DBF.ID;
    }
    IEnumerator Send () {
        if (int.Parse (AGI.text) != BigMom.DBF.AGI || int.Parse (STR.text) != BigMom.DBF.STR || int.Parse (STA.text) != BigMom.DBF.STA || int.Parse (INT.text) != BigMom.DBF.INT) {
            showLog.text = "Updating please wait";
            WWWForm form = new WWWForm();
            if (int.Parse (getPoints.text) != BigMom.DBF.PT) {
                if (int.Parse (AGI.text) != BigMom.DBF.AGI) {
                    form.AddField ("AGI", BigMom.TS.AGI);
                }
                if (int.Parse (STR.text) != BigMom.DBF.STR) {
                    form.AddField ("STR", BigMom.TS.STR);
                }
                if (int.Parse (STA.text) != BigMom.DBF.STA) {
                    form.AddField ("STA", BigMom.TS.STA);
                }
                if (int.Parse (INT.text) != BigMom.DBF.INT) {
                    form.AddField ("INT", BigMom.TS.INT);
                }
                form.AddField ("userID", id);
                StartCoroutine(BigMom.DBF.UpdateValue (form, "UpdateStats"));
                StatsUpdate ();
                BigMom.DBF.externalGetStats ();
                yield return new WaitUntil (() => BigMom.DBF.readyCheck == true);
                getPoints.text = BigMom.DBF.PT.ToString ();
                AGI.text = BigMom.DBF.AGI.ToString ();
                STR.text = BigMom.DBF.STR.ToString ();
                STA.text = BigMom.DBF.STA.ToString ();
                INT.text = BigMom.DBF.INT.ToString ();
                showLog.text = "Success!";
                yield return new WaitForSeconds (2);
                showLog.text = "";
            }
        } else {
            showLog.text = "Вы не распределили характеристики";
        }
    }
    void StatsUpdate () {
        BigMom.TS.STA = 0;
        BigMom.TS.STR = 0;
        BigMom.TS.AGI = 0;
        BigMom.TS.INT = 0;
        AGI.color = Color.black;
        STR.color = Color.black;
        STA.color = Color.black;
        INT.color = Color.black;
    }
    void IPointerClickHandler.OnPointerClick (PointerEventData eventData) {
        if (showLog.text != "Updating please wait") {
            StartCoroutine (Send ());
        } else {
            Debug.Log ("Сработала защита от постоянных кликов");
        }
    }
}