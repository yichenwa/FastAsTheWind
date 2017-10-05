using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCannon : FirstCannon {

    public SmallCannon(){
        weaponName = "Small Cannon";
        weaponCooldown = 1f;
        currentCooldown = 0f;
        weaponAttack = 2f;
    }
}
