using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    //This is a template for dialogue. Default is set to 4 sets, each with 4 options, designed so that there is no need to remove anything if the script needs fewer

    public string dialogueOutlinePath; //Path file to dialogue script (script in the theater sense of the word)
    //Outline should be
    //(number of DialogueSets)
    //(string for npc dialogue in first DialogueSet), (number of DAChoices)
    //(string of text for first DAChoice in first DialogueSet), (int for nextSet), (int for executed method)
    //(repeat above for all DAChoices)
    //(repeat above 3 lines for all DialogueSets)

    private DialogueScript dScript = new DialogueScript(); 

	// Use this for initialization
	void Start () {

        DialogueSet dSet0 = new DialogueSet();
        dSet0.npcDialogue = "";
            DAChoice ds0c0 = new DAChoice();
            ds0c0.dialogue = "";
            ds0c0.nextSet = 1;
            ds0c0.executedAction = -1;
            dSet0.choiceSetArray[0] = ds0c0;
            DAChoice ds0c1 = new DAChoice();
            ds0c1.dialogue = "";
            ds0c1.nextSet = 1;
            ds0c1.executedAction = -1;
            dSet0.choiceSetArray[0] = ds0c0;
            DAChoice ds0c2 = new DAChoice();
            ds0c2.dialogue = "";
            ds0c2.nextSet = 1;
            ds0c2.executedAction = -1;
            dSet0.choiceSetArray[0] = ds0c0;
            DAChoice ds0c3 = new DAChoice();
            ds0c3.dialogue = "";
            ds0c3.nextSet = 1;
            ds0c3.executedAction = -1;
            dSet0.choiceSetArray[0] = ds0c0;
        dScript.dialogueScript[0] = dSet0;

    }

    private void CreateDAChoiceSet(string dialogue, int nextSet, int executedAction)
    {

    }

    public void ExecuteActions()
    {
        int arrayLoc = 0; //convenience variable, so that the following block of code can be copy-pasted in various dialogue scripts

        if (dScript.ExecuteActions(arrayLoc)) 
        {
            //Call the first of the potential methods
        }
        arrayLoc++;
    }
	
	public void ClearScript()
    {

    }
}
