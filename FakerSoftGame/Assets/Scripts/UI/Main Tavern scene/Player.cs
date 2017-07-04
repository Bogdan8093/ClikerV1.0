using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject PlayerUI;

    void OnMouseDown()
    {
        PlayerUI.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
}
