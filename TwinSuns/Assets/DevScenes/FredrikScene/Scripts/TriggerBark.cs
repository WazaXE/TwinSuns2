using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBark : MonoBehaviour, IInteractable
{
    [Header("Speech Bubble")]
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private bool isOneShot;

    private bool firstTime = true;
    private bool canEnterDialogue = true;
    public bool CanInteract => canEnterDialogue;

    private bool needToBeInside = false;
    public bool NeedToBeInside => needToBeInside;

    private void Awake()
    {
        speechBubble.SetActive(false);
    }

    public void InteractInRange()
    {
        if (isOneShot && firstTime)
        {
            speechBubble.SetActive(true);
            firstTime = false;
        }
        else if (!isOneShot)
        {
            speechBubble.SetActive(true);
        }

    }
    public void InteractOutOfRange()
    {

        speechBubble.SetActive(false);

    }

    public void OnInteractionClick()
    {
       
    }
    public Vector3 ReturnPosition()
    {
        return transform.position;
    }


}
