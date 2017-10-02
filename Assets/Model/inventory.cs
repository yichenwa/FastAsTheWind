using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
	GameObject inventoryPanel;
	GameObject slotPanel;
    Baseitem database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	private int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start()
	{
        database = GetComponent<Baseitem>();
		slotAmount = 16;
		inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
		for (int i = 0; i < slotAmount; i++)
		{
            items.Add(new Item());
			slots.Add(Instantiate(inventorySlot)); //add iventory slot
			slots[i].transform.SetParent(slotPanel.transform);
		}
        AddItem(0);
	}

    public void AddItem(int id){
        Item itemtoadd = database.GetItemByID(id);
        for (int i = 0; i < items.Count;i++){
            if(items[i].ID == -1){
                items[i] = itemtoadd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                break;
            }
        }
    }
}
