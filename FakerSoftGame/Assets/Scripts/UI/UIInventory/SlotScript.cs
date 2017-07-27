using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SlotScript : MonoBehaviour, IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler,IDragHandler{
    public ItemD item;
    Image itemImage;
    public int slotNumber;
    InventoryD inventory;
    Text itemAmount;
    // Use this for initialization
    void Start () {
        itemAmount = gameObject.transform.GetChild(1).GetComponent<Text>();
        inventory = GameObject.Find("Inventory").GetComponent<InventoryD>();
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        if (inventory.Items[slotNumber].itemName !=null)
        {
            item = inventory.Items[slotNumber];
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].itemIcon;
            if(inventory.Items[slotNumber].itemType == ItemD.ItemType.Consumable)
            {
                itemAmount.enabled = true;
                itemAmount.text ="" + inventory.Items[slotNumber].itemValue;
            }
        }
        else
        {
            itemImage.enabled = false;
        }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
            if (inventory.Items[slotNumber].itemName == null && inventory.draggingItem)
            {
                inventory.Items[slotNumber] = inventory.draggedItem;
                inventory.CloseDraggedItem();
            }
            else if (inventory.draggingItem && inventory.Items[slotNumber].itemName != null)
        {
            inventory.Items[inventory.indexOfDraggadItem] = inventory.Items[slotNumber];
            inventory.Items[slotNumber] = inventory.draggedItem;
            inventory.CloseDraggedItem();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inventory.Items[slotNumber].itemName!=null && !inventory.draggingItem)
        {
            inventory.showTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition,inventory.Items[slotNumber]);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (inventory.Items[slotNumber].itemName != null)
        {
            inventory.closeTooltip();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (inventory.Items[slotNumber].itemName != null)
        {
            inventory.ShowDraggedItem(inventory.Items[slotNumber],slotNumber);
            inventory.Items[slotNumber] = new ItemD();
            itemAmount.enabled = false;
        }

    }
}
