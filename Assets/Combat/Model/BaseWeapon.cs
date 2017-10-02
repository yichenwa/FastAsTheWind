using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseWeapon{

    public string weaponName;
    public float weaponCost;
    public float weaponCooldown;
    public float currentCooldown;
    public float weaponAttack;

    //States that the weapon could be in.
    public enum States
    {
        PROCESSING,
        QUEUE,
        SELECTING,
        WAITING,
        ACTION,
        DEAD
    }

    //The current state the weapon is in.
    public States currentState;

}
