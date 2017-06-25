using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class testclickimage : MonoBehaviour, IPointerClickHandler,
    IPointerDownHandler,
     IPointerUpHandler,
     IPointerEnterHandler,
     IPointerExitHandler,
     ISelectHandler
{
  public  Image CountryImg;

    Image SelectCountry;
   // public event testclickimage TapEvent;
    public delegate void ClickAction();
    public static event ClickAction OnClicked;

   // public Texture2D gg;
    public Image img;

    void Awake()
    {
     //   Debug.Log("GGWPFCKNSPRITE");
        //  img.alphaHitTestMinimumThreshold
       // CountryImg = GetComponent<Image>();
       // SelectCountry = transform.GetChild(0).GetComponent<Image>();
       // SelectCountry.sprite = Resources.Load<Sprite>("Image/Countries/" + CountryImg.sprite.name);
    }
    private bool IsAlphaPoint(PointerEventData eventData)
    {
     //   Debug.Log("akmaf");
        Vector2 localCursor;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localCursor);
        Rect r = RectTransformUtility.PixelAdjustRect(GetComponent<RectTransform>(), GetComponent<Canvas>());
        Vector2 ll = new Vector2(localCursor.x - r.x, localCursor.y - r.y);

        int x = (int)(ll.x / r.height * CountryImg.sprite.textureRect.height);
        int y = (int)(ll.y / r.height * CountryImg.sprite.textureRect.height);
        if (CountryImg.sprite.texture.GetPixel(x, y).a > 0) {// Debug.Log("false");
            return false; }
        
             
        else{
          //  Debug.Log("true");
            return true;
        }
    }
    public void MayBeYouWantClickMe(List<testclickimage> ResultsCountryMap, PointerEventData eventData)
    {
        if (!IsAlphaPoint(eventData))
        {
            if (gameObject.name == "Player")
            {
                BigMom.BackUIScript.PlayerUI.SetActive(true);
            }else if (gameObject.name == "Barman")
            {
                BigMom.BackUIScript.ShopUI.SetActive(true);
            }
            else if (gameObject.name == "Front")
            {
                BigMom.BackUIScript.MapUI.SetActive(true);
            }
            
            
            //Debug.Log("GGWPFCKNSPRITE");
         //   if (TapEvent != null) TapEvent(this);
        }
        else
        {
         //   ResultsCountryMap.Remove(this);
        //    if (ResultsCountryMap.Count > 0) ResultsCountryMap[0].MayBeYouWantClickMe(ResultsCountryMap, eventData);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
       // Debug.Log("click");
        //  eventData.
        if (!IsAlphaPoint(eventData))
        {
          //  Debug.Log("GGWPFCKNSPRITE");
            print(gameObject.name);
         //   if (TapEvent != null) TapEvent(this);
        }
        else
        {
       //     List<RaycastResult> raycastResults=new List<RaycastResult>();
        //    EventSystem.current.RaycastAll(eventData, raycastResults);
       //     List<testclickimage> ResultsCountryMap = raycastResults.Select(x => x.gameObject.GetComponent<testclickimage>()).ToList();
       //     ResultsCountryMap.RemoveAll(x => x == null || x.gameObject==gameObject);
       //     if (ResultsCountryMap.Count > 0) ResultsCountryMap[0].MayBeYouWantClickMe(ResultsCountryMap, eventData);

        }
    }

    public void StopSelect()
    {
        StopAllCoroutines();
        SelectCountry.color = new Color32(255, 255, 255, 0);
    }
    public void StartSelect()
    {
        StartCoroutine(Selecting());
    }
    IEnumerator Selecting()
    {
        int alpha=0;
        int count = 0;
        while (true)
        {
            alpha = (int)Mathf.PingPong(count, 150);
            count = count > 300 ? 0 : count + 5;
            SelectCountry.color = new Color32(255, 255, 255, (byte)alpha);
            yield return new WaitForFixedUpdate();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
       
    }
}