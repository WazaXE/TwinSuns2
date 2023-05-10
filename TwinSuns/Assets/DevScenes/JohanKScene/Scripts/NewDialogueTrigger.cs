using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class NewDialogueTrigger : MonoBehaviour, IInteractable
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Portrait images")]
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;

    [Header("Trigger dialogue options")]
    [SerializeField] private bool triggerByEnter;
    [SerializeField] private bool isOneshot;

    private bool canEnterDialogue = true;
    public bool CanInteract => canEnterDialogue;

    private bool needToBeInside = false;
    public bool NeedToBeInside => needToBeInside;

    public UnityEvent dialogueTriggered;

    private void Awake()
    {
        visualCue.SetActive(false);
    }


    public void InteractInRange()
    {
        //Aktivera visual 
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (CanInteract && !triggerByEnter)
            {
                visualCue.SetActive(true);
            }
        }
        //Om triggerByEnter så skall dialogen triggas här direkt
        if (triggerByEnter && CanInteract)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, leftSprite, rightSprite);
            dialogueTriggered?.Invoke();

            if (isOneshot)
            {
                canEnterDialogue = false;
            }
        }
    }
    public void InteractOutOfRange()
    {
        //if (CanInteract)
        //{
        //    visualCue.SetActive(false);
        //}

        visualCue.SetActive(false);
    }

    public void OnInteractionClick()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, leftSprite, rightSprite);
            dialogueTriggered?.Invoke();

            if (isOneshot)
            {
                canEnterDialogue = false;
            }
        }
    }
    public Vector3 ReturnPosition()
    {
        return transform.position;
    }


}
