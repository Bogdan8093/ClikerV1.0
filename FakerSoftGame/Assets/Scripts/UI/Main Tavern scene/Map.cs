using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public GameObject MapUI;
    public GameObject CurrentUI;

    void OnMouseDown()
    {
        MapUI.SetActive(true);
        if(CurrentUI != null)
        {
            CurrentUI.SetActive(false);
        }
    }
}
