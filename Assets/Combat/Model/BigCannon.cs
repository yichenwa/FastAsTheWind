using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCannon : FirstCannon {

    public BigCannon()
    {
        WeaponName = "Big Cannon";
        WeaponCooldown = 5f;
        CurrentCooldown = 0f;
        WeaponAttack = 50;
    }
}
