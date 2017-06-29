using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[Serializable]
public class Item {
    private int ID;
    private string Title;
    private int Value;
    private int Power;
    private int Defence;
    private int Vitality;
    private string Description;
    private int Rarity;
    private string Slug;
    private Sprite icon;
    public Item()
    {

    }
    public Item(string Title)
    {
        this.Title = Title;
    }
    public int getID()
    {
        return this.ID;
    }
    public string getTitle()
    {
        return this.Title;
    }
    public int getValue()
    {
        return this.Value;
    }
    public int getPower()
    {
        return this.Power;
    }
    public int getDefnce()
    {
        return this.Defence;
    }
    public int getVitality()
    {
        return this.Vitality;
    }
    public string getDescription()
    {
        return this.Description;
    }
    public int getRarity()
    {
        return this.Rarity;
    }
    public string getSlug()
    {
        return this.Slug;
    }
    public Sprite getIcon()
    {
        return this.icon;
    }


    public void setID(int ID)
    {
         this.ID=ID;
    }
    public void setTitle(string Title)
    {
         this.Title= Title;
    }
    public void setValue(int Value)
    {
         this.Value=Value;
    }
    public void setPower(int Power)
    {
         this.Power=Power;
    }
    public void setDefence(int Defence)
    {
         this.Defence=Defence;
    }
    public void setVitality(int Vitality)
    {
         this.Vitality=Vitality;
    }
    public void setDescription(string Description)
    {
         this.Description=Description;
    }
    public void setRarity(int Rarity)
    {
         this.Rarity=Rarity;
    }
    public void setSlug(string Slug)
    {
         this.Slug=Slug;
    }
    public void setIcon(Sprite icon)
    {
        this.icon = icon;
    }
}
