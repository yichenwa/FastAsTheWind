using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript //A script contains an array of DialogueSet class objects
{
    public DialogueSet[] dialogueScript;

    private bool[] toExecuteMethods;


    public bool ExecuteActions(int index)
    {
        return toExecuteMethods[index];
    }
}

public class DialogueSet //A dialogue set contains a string for npc dialogue and an array of DAChoice class objects
{
    public string npcDialogue;
    public DAChoice[] choiceSetArray;
}

public class DAChoice //A DAChoice contains a string for player's potential dialogue, an int for the next set, and an int to indicate the to-be-executed action
{
    public string dialogue;
    public int nextSet;
    public int executedAction; //
}
