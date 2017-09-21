using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : MonoBehaviour {

    //Queue of attacks
    public Queue<Turns> actions = new Queue<Turns>();
    //List if the player ships.
    public List<GameObject> player = new List<GameObject>();
    //List of enemys.
    public List<GameObject> enemy = new List<GameObject>();

    // Use this for initialization
    void Start () {

        //Find and adds objects with the tag "Enemy" and "Player"
        enemy.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        player.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }

	// Update is called once per frame
	void Update () {

        //Judge if the next attack is from the enemy or player. Kind of bad. Should change. 
        if (actions.Count > 0) {
            if (actions.Peek().attackerName == "FTL")
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
        PlayerShipState test = input.attackerObject.GetComponent<PlayerShipState>();
        EnemyShipState test2 = input.targetObject.GetComponent<EnemyShipState>();
        test2.enemy.shipHealth = test2.enemy.shipHealth - test.cannon.weaponAttack;
        if (test2.enemy.shipHealth <= 0) {
            Destroy(input.targetObject);
        }
    }

    void EnemyDoDamage(Turns input)
    {
        EnemyShipState test = input.attackerObject.GetComponent<EnemyShipState>();
        PlayerShipState test2 = input.targetObject.GetComponent<PlayerShipState>();
        test2.player.shipHealth = test2.player.shipHealth - test.cannon.weaponAttack;
        if (test2.player.shipHealth <= 0)
        {
            Destroy(input.targetObject);
        }
    }
}
