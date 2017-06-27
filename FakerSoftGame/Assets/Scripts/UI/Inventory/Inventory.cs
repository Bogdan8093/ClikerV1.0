using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[Serializable]
public class Invetory
{
    [NonSerialized]
    private List<Item> items = new List<Item>();
    public Invetory()
    {

    }
    public List<Item> getItems()
    {
        return this.items;
    }
    public void setItems(List<Item> items)
    {
        this.items = items;
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void AddItems(List<Item> itemlist)
    {
        for (int i = 0; i < itemlist.Count; i++)
        {
            this.items.Add(itemlist[i]);
        }

    }
    public Item getItembyName(string name)
    {
        Item temp = items.Find(delegate (Item bk)
        {
            return bk.getTitle().Contains(name);
        });
        if (temp != null)
        {
            return temp;
        }
        return null;
    }
    public Item takeItembyName(string name)
    {
        Item temp = items.Find(delegate (Item bk)
        {
            return bk.getTitle().Contains(name);
        });
        if (temp != null)
        {
            items.Remove(temp);
            return temp;
        }
        return null;
    }
    public List<Item> takeItems()
    {
        List<Item> temp = new List<Item>(items);
        items.Clear();
        return temp;
    }
    public int getSize()
    {
        return items.Count;
    }
}
