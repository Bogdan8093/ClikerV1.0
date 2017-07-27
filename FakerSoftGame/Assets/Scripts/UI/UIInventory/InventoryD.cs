using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryD : MonoBehaviour {

    public List<GameObject> Slots = new List<GameObject>();
    public List<ItemD> Items = new List<ItemD>();
    public GameObject slots;
    ItemDatabase database;
    public GameObject tooltip;
    public GameObject draggedItemGameObject;
    public bool draggingItem = false;
    public ItemD draggedItem;
    public int indexOfDraggadItem;

    void Start()
    {

        int Slotamaunt = 0;
        database = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
        int x = -165;
        int y = 255;
        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 4; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.GetComponent<SlotScript>().slotNumber = Slotamaunt;
                Slots.Add(slot);
                Items.Add(new ItemD());
                slot.transform.SetParent(this.gameObject.transform);
                slot.name = "Slot" + i + "-" + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 110;
                if (k == 3)
                {
                    x = -165;
                    y = y - 110;
                }
                Slotamaunt++;
            }

        }

        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(3);
        AddItem(4);
        AddItem(5);
        AddItem(6);
        AddItem(6);
    }

    void Update()
    {
        if (draggingItem)
        {
            Vector3 posi = (Input.mousePosition - GameObject.Find("Canvas").GetComponent<RectTransform>().localPosition);
            draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(posi.x+15,posi.y-15,posi.z);
        }
    }

    #region ToolTip
    public void showTooltip(Vector3 toolPosition, ItemD item)
    {
        tooltip.SetActive(true);
        //tooltip.GetComponent<RectTransform>().localPosition = new Vector2(toolPosition.x,toolPosition.y);
        tooltip.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
        tooltip.transform.GetChild(1).GetComponent<Text>().text = "Ловкость: " + item.itemStrength.ToString() + "\nСила: " + item.itemAgility.ToString() +"\nВыносливость: "+item.itemStamina.ToString()+"\nИнтеллект: " +item.itemIntellect.ToString()+"\nЦена: "+item.itemValue.ToString();
        tooltip.transform.GetChild(2).GetComponent<Text>().text = item.itemDesc;
    }
    public void closeTooltip()
    {
        tooltip.SetActive(false);
    }
    #endregion

    #region AaaItem

    public void cheeckIfItemExist(int itenID, ItemD item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemId == itenID)
            {
                Items[i].itemValue = Items[i].itemValue + 1;
                break;
            }
            else if (i == Items.Count - 1)
            {
                addItemAtEmptySlot(item);
            }
        }

    }

    void AddItem(int id)
    {
        for (int k=0;k<database.items.Count;k++)
        {
            if (database.items[k].itemId == id)
            {
                ItemD item = database.items[k];
                if(database.items[k].itemType == ItemD.ItemType.Consumable)
                {
                    cheeckIfItemExist(id, item);
                    break;
                }
                else
                {
                    addItemAtEmptySlot(item);
                }
             }
        }
    }

    void addItemAtEmptySlot(ItemD item)
    {
        for (int i=0;i< Items.Count;i++)
        {
            if(Items[i].itemName == null)
            {
                Items[i] = item;
                break;
            }
        }
    }
    #endregion

    #region Dragged
    public void ShowDraggedItem(ItemD item,int slotnumber)
    {
        indexOfDraggadItem = slotnumber;
        closeTooltip();
        draggedItemGameObject.SetActive(true);
        draggedItem = item;
        draggingItem = true;
        draggedItemGameObject.GetComponent<Image>().sprite = item.itemIcon;
    }

    public void CloseDraggedItem()
    {
        draggingItem = false;
        draggedItemGameObject.SetActive(false);
    }
    #endregion
}
