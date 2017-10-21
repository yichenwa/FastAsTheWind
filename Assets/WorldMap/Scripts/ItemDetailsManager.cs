using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailsManager : MonoBehaviour
{
    public Text detailsText;
    public GameItem gameItem;

    public GameObject thisPanel;
    public GameObject crewEquip;
    public GameObject shipEquip;

    void OnEnable()
    {
        detailsText.text = gameItem.GetAttributes();
    }

    public void Equip()
    {
        thisPanel.SetActive(false);

        GameObject target = null;
        if (gameItem.GetItemType() == "Personal Weapon") target = crewEquip;
        else if (gameItem.GetItemType() == "Ship Weapon")
        {
            target = shipEquip;
            shipEquip.GetComponent<EquipShipManager>().shipWeapon = (ShipWeapon)gameItem;
        }

        if (!target) return;
        target.SetActive(true);
    }
}
