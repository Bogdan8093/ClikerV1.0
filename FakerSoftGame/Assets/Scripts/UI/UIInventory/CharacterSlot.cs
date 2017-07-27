using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CharacterSlot : MonoBehaviour,IPointerDownHandler, IDragHandler
{

    public int index;
    public ItemD item = new ItemD();
    InventoryD inventory;

 

    // Use this for initialization
    void Start () {
        inventory = GameObject.Find("Inventory").GetComponent<InventoryD>();
	}
	
	// Update is called once per frame
	void Update () {
        if (item.itemType !=ItemD.ItemType.None) {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().sprite = item.itemIcon;
        }else
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
            

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (inventory.draggingItem)
        {
            if (index == 0 && inventory.draggedItem.itemType == ItemD.ItemType.Head)
            {
                if (item.itemType != ItemD.ItemType.None) {
                    ItemD temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp,-1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.CloseDraggedItem();
                }
            }
            if (index == 1 && inventory.draggedItem.itemType == ItemD.ItemType.Chest)
            {
                if (item.itemType != ItemD.ItemType.None)
                {
                    ItemD temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.CloseDraggedItem();
                }
            }
            
            if (index == 2 && inventory.draggedItem.itemType == ItemD.ItemType.Hands)
            {
                if (item.itemType != ItemD.ItemType.None)
                {
                    ItemD temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.CloseDraggedItem();
                }
            }
            
            if (index ==3 && inventory.draggedItem.itemType == ItemD.ItemType.Shoes)
            {
                if (item.itemType != ItemD.ItemType.None)
                {
                    ItemD temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.CloseDraggedItem();
                }
            }
            
            if (index == 4 && inventory.draggedItem.itemType == ItemD.ItemType.Weapon)
            {
                if (item.itemType != ItemD.ItemType.None)
                {
                    ItemD temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.CloseDraggedItem();
                }
            }
            
            if (index == 5 && inventory.draggedItem.itemType == ItemD.ItemType.Weapon)
            {
                if (item.itemType != ItemD.ItemType.None)
                {
                    ItemD temp = item;
                    item = inventory.draggedItem;
                    inventory.draggedItem = temp;
                    inventory.ShowDraggedItem(temp, -1);
                }
                else
                {
                    item = inventory.draggedItem;
                    inventory.CloseDraggedItem();
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item.itemType != ItemD.ItemType.None)
        {
            inventory.draggedItem = item;
            inventory.ShowDraggedItem(item,-1);
            item = new ItemD();
        }
    }
}
