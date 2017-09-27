using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpecialAttributes : IslandAttributes
{
    public override void SpecialOnClick(MainPanelButton caller)
    {
        if (QuestsStatus.testQuestStatus == 0)
        {
            //Load a dialogue script for first encounter with the "black wardsmith"
        }
    }
}
