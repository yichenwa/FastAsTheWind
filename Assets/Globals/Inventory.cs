using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public List<GameItem> inventoryList = new List<GameItem>();

    private int size = 0; //Number of objects in inventoryList *NOT ARRAY LENGTH*

    public void AddItem(GameItem item, int quantity = 1)
    {
        for(int i = 0; i < quantity; i++)
        {
            int index = inventoryList.IndexOf(item);

            if (index >= 0) //If true, then will return if the item can be placed not at the end of the array
            {
                if (item.GetStackable())
                {
                    inventoryList[index].quantity += quantity;
                    return;
                }
                else if (inventoryList[index].quantity == 0) //If the inventory contains 0 of a non-stackable item, replace it with the new item of the same type
                {
                    item.invLoc = index;
                    inventoryList[index] = item;
                    return;
                }
            }

            inventoryList.Add(item);
            item.invLoc = inventoryList.Count;
            size++;
        }
        
        
    }
}

public class GameItem
{
    public int quantity = 1; //0 possible, indicates that the item can be replaced by a new instance even if it isn't stackable
    //-1 indicates that the item is in use, either by the ship or a crew member
    public int invLoc; //0-based location in array; assigned on add

    public int value; //true value of the item in coins

    public string childAttributes = "";

    public bool canUse(int num = 1) //Returns true, unless there is no item to use
    {
        if (quantity < num) return false;

        return true;
    }

    public void Drop()
    {
        PlayerStatus.Inventory.inventoryList[invLoc].quantity--;
        if (PlayerStatus.Inventory.inventoryList[invLoc].quantity == 0)
            PlayerStatus.Inventory.inventoryList.RemoveAt(invLoc);
    }

    public virtual string GetName()
    {
        return "";
    }

    public virtual string GetItemType()
    {
        return "";
    }

    public virtual string GetItemDescription()
    {
        return "";
    }

    public virtual bool GetStackable()
    {
        return false;
    }

    public virtual string GetAttributes()
    {
        return "";
    }
}

public class HealthPotion : GameItem
{ 
    public override string GetAttributes()
    {
        string stackableString = "x" + quantity + "\n";
        if (GetStackable() == true) stackableString = "x" + quantity + "\n";
        return "Name: " + GetName() + "\n" + stackableString + "Classification: " + GetItemType() + "\n" + GetItemDescription();
    }

    public override string GetName()
    {
        return "Health Potion";
    }

    public override string GetItemType()
    {
        return "Consumable";
    }

    public override bool GetStackable()
    {
        return true;
    }

    public override string GetItemDescription()
    {
        return "A blood-red potion, used to magically heal an individual's wounds.";
    }
}

public class Sword : GameItem
{
    private string material = "Steel";
    private int condition = 100;

    public override string GetAttributes()
    {
        childAttributes = "Material: " + material + "\n" + "Condition: " + condition;
        string stackableString = "";
        if (GetStackable() == true) stackableString = "x" + quantity + "\n";
        return "Name: " + GetName() + "\n" + stackableString + "Classification: " + GetItemType() + "\n" +
            "Material: " + material + "\n" + "Condition: " + condition + "\n" + GetItemDescription();
    }

    public override string GetName()
    {
        return "Sword";
    }

    public override string GetItemType()
    {
        return "Weapon";
    }

    public override bool GetStackable()
    {
        return false;
    }

    public override string GetItemDescription()
    {
        return "A four-foot long steel blade with a leather-bound hilt. A well made sword, but nothing to brag about.";
    }

}

public class ShipWeapon : GameItem
{
    public string ammoType;
    public int cooldown;
    
    /*
    public override string GetAttributes()
    {
        childAttributes = "Material: " + material + "\n" + "Condition: " + condition;
        string stackableString = "";
        if (GetStackable() == true) stackableString = "x" + quantity + "\n";
        return "Name: " + GetName() + "\n" + stackableString + "Classification: " + GetItemType() + "\n" +
            "Material: " + material + "\n" + "Condition: " + condition + "\n" + GetItemDescription();
    }
    */

    public override string GetName()
    {
        return "Sword";
    }

    public override string GetItemType()
    {
        return "Weapon";
    }

    public override bool GetStackable()
    {
        return false;
    }

    public override string GetItemDescription()
    {
        return "A large, reliable naval cannon";
    }
}
