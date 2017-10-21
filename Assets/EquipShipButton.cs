using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipShipButton : MonoBehaviour
{
    public Button thisButton;
    public Text name;
    public Text slot;

    private int invSlot;
    private ShipWeapon shipWeapon;

    void Start()
    {
        thisButton.onClick.AddListener(OnClickEquip);
    }
    public void SetVars(int n) //n is the number button this is, which determines invSlot, and therefore the Weapon this refers to and the text
    {
        shipWeapon = PlayerStatus.Ship.weaponSlots[n].equippedWeapon;
        name.text = shipWeapon.GetName();
        slot.text = "Slot " + n;
    }

    private void OnClickEquip()
    {

    }
}
