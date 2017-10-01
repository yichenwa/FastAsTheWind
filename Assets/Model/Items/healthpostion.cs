using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpostion : ItemBase
{
   
    public int healthtogive;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void useItem()
    {
        base.useItem();
        //use the potion;
        ((PlayerShipState)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerShipState")).player.shipHealth += healthtogive;
        //check if health is full
        if(((PlayerShipState)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerShipState")).player.shipHealth > 
           ((PlayerShipState)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerShipState")).player.shipMaxHealth){
            //set the current health equals max health
            ((PlayerShipState)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerShipState")).player.shipHealth = ((PlayerShipState)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerShipState")).player.shipMaxHealth;
        }
    }
}
