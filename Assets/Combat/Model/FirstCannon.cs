using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCannon : MonoBehaviour
{

     public string weaponName = "Test";
     public float weaponCost;
     public float weaponCooldown = 5f;
     public float currentCooldown = 0f;
     public float weaponAttack = 50f;

     //States that the weapon could be in.
     public enum States
     {
       PROCESSING,
       WAITING,
       SELECTING,
       QUEUE,
       ACTION,
       DEAD
     }

     //The current state the weapon is in.
     public States currentState;
     private CombatState CSM;


    void Start () {
        // First state where the weapon will count up until it can be used.
        currentState = States.PROCESSING;
        CSM = GameObject.Find("Combat Manager").GetComponent<CombatState>();
    }
	
	void Update () {

        Debug.Log(currentState);

        //Switch case for the weapon states.
        //As long as the weapon is in processing, the current cooldown will count up.
        //When it reaches the queue state, it will create a action or turn and add it to the queue.
        switch (currentState)
        {
            case States.PROCESSING:
                advanceCooldown();
                break;
            case States.WAITING:
               // fire();
                break;
            case States.SELECTING:
                if (CSM.enemy.Count < 0)
                {
                    currentState = States.DEAD;
                }
                break;
            case States.QUEUE:
                break;
            case States.ACTION:
                break;
            case States.DEAD:
                break;
        }
    }



    //Will count up until it reaches the weapon cooldown time. When it reaches the cooldown time it will change states.
    void advanceCooldown()
    {
        currentCooldown = currentCooldown + Time.deltaTime;
        if (currentCooldown >= weaponCooldown)
        {
            currentState = States.WAITING;
        }
    }

   public void fire() {
        if (currentState == States.WAITING) {
            currentState = States.SELECTING;
        }
    }

    public void target(GameObject target) {
        if (currentState == States.SELECTING) {
            currentState = States.QUEUE;
            attackTarget(target);
        }
    }

    void attackTarget(GameObject target)
    {
        //Create a new "Turn"
        //Gets attacker Objets and target Objects from Combat State CSM.    
        Turns basicAttack = new Turns();
        basicAttack.attackerName = "FTL";
        basicAttack.attackerObject = CSM.player[0];
        basicAttack.targetObject = CSM.enemy[0];
        basicAttack.test = this;
        //Add to the attack queue.
        PlayerStatus.AmmoCount = PlayerStatus.AmmoCount - 1;
        CSM.Add(basicAttack);
    }

    public void reset()
    {
        currentCooldown = 0f;
        currentState = States.PROCESSING;
    }

    //tells player ship to make an attack. returns true if attack is made, false if on cooldown 
    public bool canFire() // returns true if allowed to attack
    {
        return (currentState == States.WAITING && PlayerStatus.AmmoCount > 0);
    }

    public bool canTarget() // returns true if allowed to attack
    {
        return (currentState == States.SELECTING && PlayerStatus.AmmoCount > 0);
    }
}
