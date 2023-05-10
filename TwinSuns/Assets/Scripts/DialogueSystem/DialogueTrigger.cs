using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    public PlayerInput Inputs;
    private InputAction interact;

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

    private bool playerInRange = false;

    private void Awake()
    {
        Inputs = new PlayerInput();

        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        //If player in range
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (canEnterDialogue)
            {
                visualCue.SetActive(true);
            }

        }
        //If player not in range
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //If colliding with player
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;

            if (triggerByEnter && canEnterDialogue)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, leftSprite, rightSprite);

                if (isOneshot)
                {
                    canEnterDialogue = false;
                }
            }

        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //If exiting collision with player
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;


        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        //If player in range
        //if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        //{
        //    if (canEnterDialogue)
        //    {
        //        visualCue.SetActive(true);
        //    }

            //If interact button is pressed
            if (!triggerByEnter && canEnterDialogue && !DialogueManager.GetInstance().dialogueIsPlaying && playerInRange)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, leftSprite, rightSprite);

                //If dialogue is meant to only be played once
                if (isOneshot)
                {
                    canEnterDialogue = false;
                }

            }

        //}
        //If player not in range
        //else
        //{
        //    visualCue.SetActive(false);
        //}
    }

    public void OnEnable()
    {
        interact = Inputs.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    public void OnDisable()
    {
        interact.Disable();
    }
}
