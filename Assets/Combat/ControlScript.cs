using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlScript : MonoBehaviour {

    public Text textCombatLog; // points to Combat/Canvas/TextCombatLog
    private string[] combatLogBuffer; // a buffer to track what's displayed in the combat log.
    private int combatLogSize; // how many lines can fit into the combat log
    private int hits;

    // Use this for initialization
    void Start () {
        textCombatLog.text = "";
        combatLogSize = 6;
        combatLogBuffer = new string[combatLogSize];
        hits = 0;
        PlayerStatus.AmmoCount = 100;

    }

    // Update is called once per frame
	void Update () {
        //TODO: check model to see if enemy fires, if so, report it in combat log
        //TODO: check model to see if we fired
	}

    public void Fire () { // called when the Fire button is pressed in the UI
        //TODO: tell model that we want to fire
        hits++;
        PlayerStatus.AmmoCount--;
        printToCombatLog("We hit them " + hits.ToString() + " times!");
        printToCombatLog(PlayerStatus.AmmoCount.ToString() + " shots left!");
    }

    void printToCombatLog(string line) {
        for (int i = combatLogSize - 1; i > 0; i--) // shift the buffer up one
            combatLogBuffer[i] = combatLogBuffer[i - 1];
        combatLogBuffer[0] = line; // add the new line to the buffer
        string result = combatLogBuffer[combatLogSize-1]; // create the new buffer string
        for (int i = combatLogSize - 2; i >= 0; i--) // add the rest of the buffer to it
            result = result + "\n" + combatLogBuffer[i];
        textCombatLog.text = result;
    }
}
