using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCannon : FirstCannon {

    public BigCannon()
    {
        weaponName = "Big Cannon";
        weaponCooldown = 5f;
        currentCooldown = 0f;
        weaponAttack = 50f;
    }
}
