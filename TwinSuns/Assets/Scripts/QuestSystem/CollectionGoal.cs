using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{

    public string ItemID { get; set; }

    public CollectionGoal(Quest quest, string itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Initialize()
    {
        base.Initialize();
        FetchQuest.OnItemPickUp += ItemPickedUp;
    }

    private void OnDestroy()
    {
        FetchQuest.OnItemPickUp -= ItemPickedUp;
    }

    private void ItemPickedUp(string item)
    {
        if (item == this.ItemID)
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
