using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int ShipHull { get; set; }
    public int ShipSail { get; set; }
    public int ShipCrew { get; set; }
    private GameObject Self { get; set; }

    void Start ()
    {
	    Self = this.gameObject;     //Get the GameObject this is attached to.

        if (Self.tag == "Player")   //Check if it is attached to the player or enemy.
        {
            ShipHull = PlayerStatus.ShipHealthCurrent;
        }

        else {
            ShipHull = EnemyStatus.ShipHealthCurrent;
        }
	}
	
	void Update () {

        if (Self.tag == "Player")
        {
            PlayerStatus.ShipHealthCurrent = ShipHull;
        }

        else
        {
            EnemyStatus.ShipHealthCurrent = ShipHull;
        }
        
    }
}
