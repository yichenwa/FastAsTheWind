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

        base.Start();
    }

    public override void SpecialOnClick(MainPanelButton caller)
    {
        if (QuestsStatus.testQuestStatus == 0)
        {
            Debug.Log("Special clicked");
            caller.mainPanel.gameObject.SetActive(false);

            DialogueManager.SetUpDialogue(smithFirst);

            DialoguePanelManager dpm = caller.dialoguePanel.GetComponent<DialoguePanelManager>();
            //dpm.currentScript = DialogueManager.dScript;

            caller.dialoguePanel.SetActive(true);
            dpm.Setup(0);
        }
    }
}
