using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Button thisButton;

    public GameObject mainPanel;
    public GameObject inventoryPanel;

	// Use this for initialization
	void Start ()
    {
        thisButton.onClick.AddListener(OnClickInventory);
	}

    private void OnClickInventory()
    {
        mainPanel.SetActive(false);
        inventoryPanel.SetActive(true);
    }

}
