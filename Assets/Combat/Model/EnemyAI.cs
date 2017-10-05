using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private CombatState CSM;
    private GameObject self;
    private FirstCannon[] weapons;


    void Start () {
        CSM = GameObject.Find("Combat Manager").GetComponent<CombatState>();
        self = this.gameObject;
        weapons = self.GetComponents<FirstCannon>();
    }
	
	void Update () {
        foreach (FirstCannon weapons in weapons) {
            if (weapons.canFire()) {
                weapons.fire();
                weapons.target(CSM.player[0], "Enemy");
                weapons.reset();
            }
        }
	}
}
