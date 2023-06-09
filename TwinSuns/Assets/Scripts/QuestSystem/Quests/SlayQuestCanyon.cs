using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayQuestCanyon : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        QuestName = "Canyon Slay Quest";
        Description = "Kill an enemy";
        CurrencyReward = 10;

        Goals.Add(new KillGoal(this, 0, "Kill 1 enemy", false, 0, 1));

        Goals.ForEach(g => g.Initialize());
    }
}
