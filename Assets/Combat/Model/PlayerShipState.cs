using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipState : MonoBehaviour
{
    //Gets the ship stats.
    public BasicShip player;

    //Gets the weapon stats.
    public FirstCannon cannon;

    //For list of player ships and enemy ships and action queue.
    private CombatState CSM;

    void Start()
    {
        // determine player ship health from world map
        player.shipHealth = PlayerStatus.ShipHealthCurrent;

        //CSM = GameObject.Find("Combat Manager").GetComponent<CombatState>();
    }

    void Update()
    {
        PlayerStatus.ShipHealthCurrent = (int)player.shipHealth;



    }


}
