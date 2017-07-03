using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerSkillPoints : MonoBehaviour {
public static int skillPoints = 25;
public GameObject displayPoints;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        displayPoints.GetComponent<Text>().text = "Points "+ skillPoints;
    }

}
