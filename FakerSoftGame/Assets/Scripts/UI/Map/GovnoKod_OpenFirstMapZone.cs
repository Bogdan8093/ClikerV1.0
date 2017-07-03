using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GovnoKod_OpenFirstMapZone : MonoBehaviour {

    public GameObject FirstMapZone;
    public GameObject CurrentMap;

    void OnMouseDown()
    {
        FirstMapZone.SetActive(true);
        CurrentMap.SetActive(false);
    }
}
