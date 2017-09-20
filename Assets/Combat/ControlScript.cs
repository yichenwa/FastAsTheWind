using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour {

    public GameObject combatScripts; // to get a non-static reference to the ViewScript Object
    private ModelScript modelScript; // to get a non-static reference to the ViewScript Object

    // Use this for initialization
    void Start () {
        modelScript = (ModelScript)combatScripts.GetComponent("ModelScript"); // to get a non-static reference to the ViewScript Object
    }

    // Update is called once per frame
	void Update () {
        // TODO: update valid controls (i.e. if out of ammo or on cooldown, disable fire button)
	}

    public void buttonFirePressed () { // called when the Fire button is pressed in the UI
        modelScript.Fire();
        
    }

    
}
