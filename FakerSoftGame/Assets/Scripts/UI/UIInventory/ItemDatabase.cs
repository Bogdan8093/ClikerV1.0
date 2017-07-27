using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<ItemD> items = new List<ItemD>();
	// Use this for initialization
	void Start () {
        items.Add(new ItemD("cap", 0, "Полная шляпа", 2, 1, 3, 2, 7, ItemD.ItemType.Head));
        items.Add(new ItemD("shirt", 1, "Простоя рубашка", 2, 1, 3, 2, 10, ItemD.ItemType.Chest));
        items.Add(new ItemD("glove", 2, "Перчатки", 1, 1, 1, 1, 6, ItemD.ItemType.Hands));
        items.Add(new ItemD("shoes", 3, "Теплые угги", 2, 1, 3, 2, 10, ItemD.ItemType.Shoes));
        items.Add(new ItemD("sword", 4, "Меч 3000", 3, 2, 2, 4, 15, ItemD.ItemType.Weapon));
        items.Add(new ItemD("baton", 5, "Булава гетмана", 1, 3, 1, 1, 12, ItemD.ItemType.Weapon));
        items.Add(new ItemD("beer", 6, "Жигулевское светлое", 0, 1, 2, -1, 3, ItemD.ItemType.Consumable));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
