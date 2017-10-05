using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship {

    public enum ShipClass
    {
        SLOOP,
        FRIGATE,
        KRAKEN
    }

    public readonly string _name;
    public readonly string _description;
    public readonly int _value;
    public readonly ShipClass _shipClass;

    private readonly int _hullHealthMaxBase;
    public int _hullHealth;

    private readonly int _crewHealthMaxBase;
    public int _crewHealth;

    private readonly int _sailHealthMaxBase;
    public int _sailHealth;

    public int slotCount;
    public WeaponSlot[] weaponSlots;


    public Ship (string name, string description, int value, ShipClass shipClass, int hullHealthMaxBase, int crewHealthMaxBase, int sailHealthMaxBase)
    {
        _name = name;
        _description = description;
        _value = value;
        _shipClass = shipClass;

        _hullHealthMaxBase = hullHealthMaxBase;
        _crewHealthMaxBase = crewHealthMaxBase;
        _sailHealthMaxBase = sailHealthMaxBase;

        _hullHealth = HullStrengthMax();
        _crewHealth = CrewStrengthMax();
        _sailHealth = SailStrengthMax();

        InitializeWeaponSlots();
    }

    public int HullStrengthMax()
    {
        return _hullHealthMaxBase;
    }

    public int CrewStrengthMax()
    {
        return _crewHealthMaxBase;
    }

    public int SailStrengthMax()
    {
        return _sailHealthMaxBase;
    }

    private void InitializeWeaponSlots()
    {
        switch (_shipClass)
        {
            case ShipClass.SLOOP: // Sloops have 4 slots for cannons
                slotCount = 4;
                weaponSlots = new WeaponSlot[slotCount];
                for (int i = 0; i < 4; i++)
                {
                    weaponSlots[i] = new WeaponSlot();
                    weaponSlots[i].addType(ShipWeapon.WeaponType.CANNON);
                }
                break;
            case ShipClass.FRIGATE: // Frigates have 8 slots for cannons, slots 6 and 7 can also be used for spells
                slotCount = 8;
                weaponSlots = new WeaponSlot[slotCount];
                for (int i = 0; i < 8; i++)
                {
                    weaponSlots[i] = new WeaponSlot();
                    weaponSlots[i].addType(ShipWeapon.WeaponType.CANNON);
                }
                for (int i = 6; i < 8; i++)
                {
                    weaponSlots[i] = new WeaponSlot();
                    weaponSlots[i].addType(ShipWeapon.WeaponType.SPELL);
                }
                break;
            case ShipClass.KRAKEN: // Kraken has 8 slots for melee, 1 for each tentacle it'll have
                slotCount = 8;
                weaponSlots = new WeaponSlot[slotCount];
                for (int i = 0; i < 8; i++)
                {
                    weaponSlots[i] = new WeaponSlot();
                    weaponSlots[i].addType(ShipWeapon.WeaponType.MELEE);
                }
                break;
            default:
                break;
        }
    }
}

public class WeaponSlot
{
    private HashSet<ShipWeapon.WeaponType> acceptedTypes;
    public ShipWeapon equippedWeapon;

    public WeaponSlot()
    {
        acceptedTypes = new HashSet<ShipWeapon.WeaponType>();
    }

    public void addType(ShipWeapon.WeaponType weaponType)
    {
        acceptedTypes.Add(weaponType);
    }

    public bool validWeapon(ShipWeapon weapon)
    {
        return acceptedTypes.Contains(weapon._weaponType);
    }
}

/*
public class CrewSlot
{

}
*/
