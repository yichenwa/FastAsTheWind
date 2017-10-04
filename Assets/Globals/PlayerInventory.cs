using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour //***THIS IS A PLACEHOLDER SCRIPT. DELETE WHEN REAL INVENTORY IS IMPLEMENTED***
{
    public static Inventory inventory = new Inventory();
}

public class Inventory
{
    public GameItem[] inventoryList = new GameItem[0];

    private int size = 0; //Number of objects in inventoryList

    public void AddItem(GameItem item, int quantity = 1)
    {
        for(int i = 0; i < quantity; i++)
        {
            int index = FindDuplicate(item);

            if (index >= 0) //If true, then will return if the item can be placed not at the end of the array
            {
                if (item.GetStackable())
                {
                    inventoryList[index].quantity += quantity;
                    return;
                }
                else if (inventoryList[index].quantity == 0) //If the inventory contains 0 of a non-stackable item, replace it with the new item of the same type
                {
                    inventoryList[index] = item;
                    return;
                }
            }

            if (inventoryList.Length == 0) //If the inventoryList has no size, make an array of size 10
            {
                inventoryList = new GameItem[10];
            }
            else if (size == inventoryList.Length) //If inventoryList is full, resize it to twice the size
            {
                ResizeInventory();
            }

            inventoryList[size] = item;
            size++;
        }
        
        
    }

    private void ResizeInventory()
    {
        GameItem[] newInventory = new GameItem[inventoryList.Length * 2];
        for (int i = 0; i < inventoryList.Length; i++)
        {
            newInventory[i] = inventoryList[i];
        }
        inventoryList = newInventory;

    }

    private int FindDuplicate(GameItem item)
    {
        for (int i = 0; i < inventoryList.Length; i++)
        {
            if (inventoryList[i] == null) return -1;
            if (inventoryList[i].GetName() == item.GetName()) return i;
        }

        return -1;
    }
}

public class GameItem
{
    public int quantity = 1;

    public string childAttributes = "";

    public bool Use(int index, int num = 0) //Returns true, unless there is no item to use
    {
        if (PlayerInventory.inventory.inventoryList[index].quantity < num) return false;
        return true;
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
        string stackableString = "";
        if (GetStackable() == true) stackableString = "x" + quantity + "\n";
        return "Name: " + GetName() + "\n" + stackableString + "Classification: " + GetItemType() + "\n" + childAttributes + 
            "\n" + GetItemDescription();
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
