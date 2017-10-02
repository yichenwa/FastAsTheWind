using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlScript : MonoBehaviour {

    public Button ButtonEnd; // points to Combat/Canvas/ButtonEnd
    public Text ButtonEndText; // points to Combat/Canvas/ButtonEnd/Text
    public Button ButtonFire; // points to Combat/Canvas/ButtonFire
    public Button ButtonEnemy;
    public GameObject combatManager; // points to Combat/Combat Manager
    private CombatState combatState;
    private PlayerShipState playerShipState;
    private EnemyShipState enemyShipState;
    private FirstCannon test;

    private GameObject target;

    // Use this for initialization
    void Start () {
        combatState = (CombatState)combatManager.GetComponent("CombatState"); // to get a non-static reference to the ViewScript Object
        playerShipState = (PlayerShipState)combatState.player[0].GetComponent("PlayerShipState");
        enemyShipState = (EnemyShipState)combatState.player[0].GetComponent("EnemyShipState");
        test = (FirstCannon)combatState.player[0].GetComponent("FirstCannon");
        
    }

    // Update is called once per frame
	void Update () {
        // TODO: update valid controls (i.e. if out of ammo or on cooldown, disable fire button)
        ButtonFire.interactable = test.canFire();
        

        if (combatState.combatOver)
            ButtonEndText.text = "Return to World Map";
    }

    public void buttonFirePressed () { // called when the ButtonFire is pressed in the UI
        test.fire();
    }

    public void buttonEnemyPressed()
    { // called when the ButtonFire is pressed in the UI
        target = combatState.enemy[0];
        test.target(target);
    }

    public void buttonEndPressed()
    { // called when ButtonEnd is pressed in the UI
        if (combatState.playerWon)
            PlayerController.ReturnToMap(EnemyStatus.GoldCount, EnemyStatus.ResourcesCount, PlayerStatus.ShipPos);
        else
            PlayerController.ReturnToMap(-1 * PlayerStatus.GoldCount / 2, -1 * PlayerStatus.ResourcesCount / 2, PlayerStatus.ShipPos);
    }


}
