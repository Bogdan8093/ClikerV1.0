using UnityEngine;
using System.Collections;

public class BarmanClick : MonoBehaviour {
    public GameObject ShopUI;

  void OnMouseDown ()
    {
        ShopUI.SetActive(true);
    }
}
