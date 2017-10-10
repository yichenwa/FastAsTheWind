using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCannon : FirstCannon {

    public SmallCannon(){
        WeaponName = "Small Cannon";
        WeaponCooldown = 1f;
        CurrentCooldown = 0f;
        WeaponAttack = 2;
    }
}
