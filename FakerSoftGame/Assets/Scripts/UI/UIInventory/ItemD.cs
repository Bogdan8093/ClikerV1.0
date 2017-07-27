using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemD
{
    public string itemName;
    public int itemId;
    public string itemDesc;
    public Sprite itemIcon;
    public GameObject itemModel;
    public int itemStrength;
    public int itemAgility;
    public int itemStamina;
    public int itemIntellect;
    public int itemValue;
    public ItemType itemType;

    public enum ItemType
    {
        None,
        Weapon,
        // WeaponsR,
        Consumable,
        Quest,
        Head,
        Shoes,
        Chest,
        Trousers,
        Hands

    }
    public ItemD(string name, int id, string desc, int strength, int agility, int stamina, int intellect, int value, ItemType type)
    {
        itemName = name;
        itemId = id;
        itemDesc = desc;
        itemStrength = strength;
        itemAgility = agility;
        itemStamina = stamina;
        itemIntellect = intellect;
        itemValue = value;
        itemType = type;
        itemIcon = Resources.Load<Sprite>("" + name);
    }
    public ItemD()
    {

    }
}

