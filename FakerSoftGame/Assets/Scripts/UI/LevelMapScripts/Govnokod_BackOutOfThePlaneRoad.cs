using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Govnokod_BackOutOfThePlaneRoad : MonoBehaviour {

    public GameObject LevelMap;
    public GameObject PlaneRoad_1;

    void OnMouseDown()
    {
        LevelMap.SetActive(true);
        PlaneRoad_1.SetActive(false);
    }
}
