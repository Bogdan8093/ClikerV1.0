using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string description;
    private Sprite defaultSprite;
    public GameObject panel;
    // Use this for initialization
    void Start()
    {
        defaultSprite = gameObject.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Image>().sprite == null)
            gameObject.GetComponent<Image>().sprite = defaultSprite;
    }

    /*void onMouseEnter()
    {
        gameObject.GetComponentInChildren<GameObject>().SetActive(true);
        gameObject.GetComponentInChildren<Text>().text=thisItem.getDescription();
    }*/
    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);
        panel.GetComponentInChildren<Text>().text = description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        panel.SetActive(false);
    }
}
