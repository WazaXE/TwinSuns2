using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IInteractable
{
    //I have no idea what these are but I included them because otherwise unity screamed at me
    private bool needToBeInside = true;
    private bool canEnterDialogue = true;
    public bool NeedToBeInside => needToBeInside;
    public bool CanInteract => canEnterDialogue;

    [SerializeField] private GameObject quests;

    [SerializeField] private string questType;

    private Quest Quest { get; set; }

    public bool AssignedQuest { get; set; }

    public bool HelpedQuestGiver { get; set; }



    public void OnInteractionClick()
    {
        if(!AssignedQuest && !HelpedQuestGiver)
        {
            //Assign quest to player
            AssignQuest();
        }
        else if(AssignedQuest && !HelpedQuestGiver)
        {
            //Quest is given but not completed, check to be sure
            CheckQuestStatus();
        } else
        {
            //Quest assigned and completed
        }
    }

    private void AssignQuest()
    {
        AssignedQuest = true;

        //Add quest component through lookup
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));

    }

    private void CheckQuestStatus()
    {
        if(Quest.Completed)
        {
            //Quest is completed
            Quest.GiveReward();
            HelpedQuestGiver = true;
            AssignedQuest = false;
        } else
        {
            //Quest is not completed
        }
    }

    public void InteractInRange()
    {

    }

    public void InteractOutOfRange()
    {

    }

    public Vector3 ReturnPosition()
    {
        return transform.position;
    }
}
