using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class submitStat : MonoBehaviour, IPointerClickHandler {
    public Text AGI, STR, STA, INT;
    public Text showLog, getPoints;
    private string tableName, collumnName;
    private int id;
    IEnumerator Start () {
        yield return new WaitUntil (() => BigMom.DBF.readyCheck == true);
        id = BigMom.DBF.ID;
        tableName = "users";
    }
    public void Send () {
        if (int.Parse (getPoints.text) != BigMom.DBF.PT) {
            if (int.Parse (AGI.text) != BigMom.DBF.AGI) {
                UpdateStat (AGI);
            }
            if (int.Parse (STR.text) != BigMom.DBF.STR) {
                UpdateStat (STR);
            }
            if (int.Parse (STA.text) != BigMom.DBF.STA) {
                UpdateStat (STA);
            }
            if (int.Parse (INT.text) != BigMom.DBF.INT) {
                UpdateStat (INT);
            }
            // если задет хоть 1 параметр запрос данных с сервера заного
            if (int.Parse (AGI.text) != BigMom.DBF.AGI || int.Parse (STR.text) != BigMom.DBF.STR || int.Parse (STA.text) != BigMom.DBF.STA || int.Parse (INT.text) != BigMom.DBF.INT) {
                collumnName = "points";
                BigMom.DBF.UpdateValueFunc (tableName, collumnName, getPoints.text, id);
                StatsUpdate ();
            }
        } else {
            showLog.text = "Вы не распределили характеристики";
        }
    }
    void UpdateStat (Text stat) {
        collumnName = stat.transform.parent.name.ToLower ();
        BigMom.DBF.UpdateValueFunc (tableName, collumnName, stat.text, id);

    }
    void StatsUpdate () {
        tempStats.STA = 0;
        tempStats.STR = 0;
        tempStats.AGI = 0;
        tempStats.INT = 0;
        AGI.color = Color.black;
        STR.color = Color.black;
        STA.color = Color.black;
        INT.color = Color.black;
        BigMom.DBF.externalStartStats ();
    }
    void IPointerClickHandler.OnPointerClick (PointerEventData eventData) {
        Send ();
    }
}