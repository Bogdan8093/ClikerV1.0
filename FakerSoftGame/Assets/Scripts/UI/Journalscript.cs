using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journalscript : MonoBehaviour {
    public GameObject Questtab;
    public GameObject Collectiontab;
    public GameObject Kodecstab;
    public GameObject Achivmenttab;
    // Use this for initialization
    public void onquestclick ()
    {
        Collectiontab.SetActive(false);
        Kodecstab.SetActive(false);
        Achivmenttab.SetActive(false);
        Questtab.SetActive(true);
    }
      public void onAchivmentclick ()
    {
        Collectiontab.SetActive(false);
        Kodecstab.SetActive(false);
        Achivmenttab.SetActive(true);
        Questtab.SetActive(false);
    }
    public void onKodecsclick()
    {
        Collectiontab.SetActive(false);
        Kodecstab.SetActive(true);
        Achivmenttab.SetActive(false);
        Questtab.SetActive(false);
    }
    public void onCollectionsclick()
    {
        Collectiontab.SetActive(true);
        Kodecstab.SetActive(false);
        Achivmenttab.SetActive(false);
        Questtab.SetActive(false);
    }
}
