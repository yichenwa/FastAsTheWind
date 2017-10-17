using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : MonoBehaviour {

    //Queue of attacks
    public Queue<Turns> actions = new Queue<Turns>();
    //List of the player ships.
    public List<GameObject> player = new List<GameObject>();
    //List of enemys.
    public List<GameObject> enemy = new List<GameObject>();
    // reference to UI script
    public GameObject UIScripts; // to get a non-static reference to the ViewScript Object
    private ViewScript UI;

    private GameObject playerObject;

    public bool combatOver;
    public bool playerWon;

    void Start () {
        // to get a non-static reference to the ViewScript Object
        UI = (ViewScript)UIScripts.GetComponent("ViewScript");
        //Find and adds objects with the tag "Enemy" and "Player"
        enemy.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        player.AddRange(GameObject.FindGameObjectsWithTag("Player"));

        // establish that combat is NOT over, and that the player has NOT won
        combatOver = false;
        playerWon = false;

        playerObject = player[0];

        playerObject.AddComponent<BigCannon>();

        if (PlayerStatus.HadMoreWeapon == true) {
            
            playerObject.AddComponent<SmallCannon>();
            playerObject.AddComponent<SmallCannon>();
            playerObject.AddComponent<SmallCannon>();
        }


    }

	void Update () {

        if (Time.timeScale == 0) { return; }

        if (actions.Count > 0) {
            if (actions.Peek().attackerObject.tag == "Player")
            {
                PlayerDoDamage(actions.Dequeue());
            }
            else EnemyDoDamage(actions.Dequeue());
        }

    }

    //Adds the turns into the queue.
    public void Add(Turns input) {
        actions.Enqueue(input);
    }

    //Does damage to enemy or player. Destroy target if health is reduced to 0 or less.
    void PlayerDoDamage(Turns input)
    {
        Health enemyHealth = input.targetObject.GetComponent<Health>();
        enemyHealth.ShipHull = enemyHealth.ShipHull - input.weaponUsed.WeaponAttack;
        PlayerStatus.AmmoCount = PlayerStatus.AmmoCount - 1;
        input.weaponUsed.Reset();
        UI.printToCombatLog("The " + "Player" + " dealt " + input.weaponUsed.WeaponAttack.ToString() + " damage to the " + "Enemy" + "!");
        if (enemyHealth.ShipHull <= 0)
        {
            Destroy(input.targetObject);
            enemy.Remove(input.targetObject);
            EnemyStatus.ShipHealthCurrent = 0;
            UI.printToCombatLog("The " + "Player" + " has sunk the " + "Enemy" + "!");
            playerWon = true;
            combatOver = true;
        }
        
    }

    void EnemyDoDamage(Turns input)
    {
        Health playerHealth = input.targetObject.GetComponent<Health>();
        playerHealth.ShipHull = playerHealth.ShipHull - input.weaponUsed.WeaponAttack;
        UI.printToCombatLog("The " + "Enemy" + " dealt " + input.weaponUsed.WeaponAttack.ToString() + " damage to the " + "Enemy" + "!");
        if (playerHealth.ShipHull <= 0)
        {
            Destroy(input.targetObject);
            player.Remove(input.targetObject);
            PlayerStatus.ShipHealthCurrent = 0;
            UI.printToCombatLog("The " + "Enemy" + " has sunk the " + "Player" + "!");
            playerWon = false;
            combatOver = true;
        }
    }

}
