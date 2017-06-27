using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public GameObject SellSide;
    public GameObject BuySide;
    public GameObject ExchangeSide;
    public GameObject Inst;
    public Vector3[] SlotsPosition;
    public Vector3 SlotsOffset;

    private Invetory BarmanInventory;

    private Invetory PlayerInventory;

    private Invetory ExchangeInventory;

    bool b = true;
    // Use this for initialization
    void Start()
    { //Test
        List<Item> it = new List<Item>();
        List<Item> it1 = new List<Item>();
        Sprite temp = Resources.Load<Sprite>("cursorSword_gold");
        if (temp == null)
            Debug.Log("Image Fail Load");
        for (int i = 0; i < 6; i++)
        {
            Item iq = new Item();
            iq.setIcon(temp);
            iq.setTitle("Btn" + (i + 1).ToString());
            iq.setDescription("Btn" + (i + 1).ToString());
            it.Add(iq);
        }
        for (int i = 0; i < 3; i++)
        {
            Item iq = new Item();
            iq.setIcon(temp);
            iq.setTitle("Pl" + (i + 1).ToString());
            iq.setDescription("Pl" + (i + 1).ToString());
            it1.Add(iq);
        }
        BarmanInventory = new Invetory();
        PlayerInventory = new Invetory();
        ExchangeInventory = new Invetory();

        //Test
        BarmanInventory.setItems(it);
        PlayerInventory.setItems(it1);
    }

    // Update is called once per frame
    void Update()
    {
        if (b)
        {
            // Debug.Log(BarmanInventory.getSize());
            ClearItems(SellSide);
            ClearItems(ExchangeSide);
            ClearItems(BuySide);
            ShowItems(BarmanInventory.getItems(), SellSide, SlotsPosition[0]);
            ShowItems(PlayerInventory.getItems(), BuySide, SlotsPosition[1]);
            ShowItems(ExchangeInventory.getItems(), ExchangeSide, SlotsPosition[2]);
        }

    }
    void ShowItems(List<Item> slots, GameObject showing, Vector3 slotpos)
    {
        GameObject tmp = null;
        int j = 0;
        for (int i = 0; i < slots.Count; i++)
        {

            if (i % 3 == 0)
            {
                tmp = Instantiate(Inst, slotpos, Quaternion.identity) as GameObject;
                tmp.transform.SetParent(showing.transform, false);
                //  StartCoroutine(setRowItem(tmp, slots[i]));
                slotpos -= SlotsOffset;
                j = 0;
            }
            setRowItem(j, tmp, slots[i]);
            j++;

        }
        b = false;
    }
    void ClearItems(GameObject showing)
    {

        for (int i = 0; i < showing.transform.childCount; i++)
        {
            if (showing.transform.GetChild(i).name == "RowSlots")
            {

            }
            Destroy(showing.transform.GetChild(i).gameObject);
            // Debug.Log("D");
        }
        b = false;
    }
    void setRowItem(int curr, GameObject t, Item item)
    {
        t.transform.GetChild(curr).GetComponent<Button>().image.sprite = item.getIcon();
        t.transform.GetChild(curr).GetComponent<Button>().name = item.getTitle();
        t.transform.GetChild(curr).GetComponent<Button>().gameObject.GetComponent<SlotAction>().description=item.getDescription();
        t.transform.GetChild(curr).GetComponent<Button>().onClick.AddListener(clickSlot);
    }

    public void clickSlot()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        if (go != null)
        {
            // Debug.Log(go.name);
            if (BarmanInventory.getItembyName(go.name) != null)
                ExchangeInventory.AddItem(BarmanInventory.takeItembyName(go.name));
            else
            if (ExchangeInventory.getItembyName(go.name) != null)
                BarmanInventory.AddItem(ExchangeInventory.takeItembyName(go.name));
            b = true;
        }
        else
            Debug.Log("currentSelectedGameObject is null");
    }
    public void clickExchange()
    {
        Debug.Log("Exchange");
        Debug.Log(PlayerInventory.getSize());
        Debug.Log(ExchangeInventory.getSize());
        Debug.Log(BarmanInventory.getSize());
        // List<Item> t = ExchangeInventory.takeItems();
        // Debug.Log(t.Count);
        PlayerInventory.AddItems(ExchangeInventory.takeItems());
        b = true;
        Debug.Log("Exchanged");
        Debug.Log(PlayerInventory.getSize());
        Debug.Log(ExchangeInventory.getSize());
        Debug.Log(BarmanInventory.getSize());
    }
}
