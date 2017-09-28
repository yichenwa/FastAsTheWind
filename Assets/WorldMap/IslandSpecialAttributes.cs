using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpecialAttributes : IslandAttributes
{
    public string smithFirst;
    public string smithReturnUnknown;
    public string smithReturnKnown;
    public string smithReturnHated;
    public string smithReturnIncomplete;
    public string smithReturnComplete;
    private DialogueManager manager;


    public override void Start()
    {
        hasSpecial = true;

        actions = 5;

        base.Start();
    }

    public override void SpecialOnClick(MainPanelButton caller)
    {
        if (QuestsStatus.testQuestStatus == 0)
        {
            caller.mainPanel.gameObject.SetActive(false);

            DialogueManager.SetUpDialogue("Assets/DialogueTextFiles/" + smithFirst);

            DialoguePanelManager dpm = caller.dialoguePanel.GetComponent<DialoguePanelManager>();
            //dpm.currentScript = DialogueManager.dScript;

            caller.dialoguePanel.SetActive(true);
            dpm.Setup(0);
        }
    }

    public override void TriggerDialogueConsequences(bool[] actions)
    {
        if (actions[0] == true)
        {
            ActionZero();
        }

        if (actions[1] == true)
        {
            ActionOne();
        }

        if (actions[2] == true)
        {
            ActionTwo();
        }

        if (actions[3] == true)
        {
            ActionThree();
        }

        if (actions[4] == true)
        {
            ActionFour();
        }

        //if (actions[5] == true)
        //{
        //    ActionFive();
        //}

        //if (actions[6] == true)
        //{
        //    ActionSix();
        //}

        //if (actions[7] == true)
        //{
        //    ActionSeven();
        //}
    }

    private void ActionZero()
    {
        QuestsStatus.testQuestStatus = 10;
    }

    private void ActionOne()
    {
        QuestsStatus.testQuestStatus = 20;
    }

    private void ActionTwo()
    {
        QuestsStatus.testQuestStatus = -10;
    }

    private void ActionThree()
    {
        QuestsStatus.testQuestStatus = 30;
    }

    private void ActionFour()
    {
        QuestsStatus.testQuestStatus = 40;
        QuestsStatus.testQuestActive = true;
    }

    //private void ActionFive()
    //{

    //}

    //private void ActionSix()
    //{

    //}

    //private void ActionSeven()
    //{

    //}
}
