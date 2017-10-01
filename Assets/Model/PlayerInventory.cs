using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour {

    [System.Serializable]
    public class Inventory
    {
        public GameObject item;
        public int Quantity;

    }
    public List<Inventory> inventoryItems;
    public List<Inventory> inventoryEquiment;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
