using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsStatus : MonoBehaviour
{
    public static int testQuestStatus;
    //0 = starting; 10 = left blackwardsmith before getting any info; 20 = left after learning he doesn't smith anymore
    //-10: Threatened him, quest unable to be completed; 30 = left after learning of daughter; 40 = Accepted quest
    public static bool testQuestActive; //This is for the purpose of a potential quest log, only showing accepted quests

    public void NewGame()
    {
        testQuestStatus = 0; //Do this for all quest statuses
        testQuestActive = false;
    }
}
