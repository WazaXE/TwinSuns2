using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigButton : MonoBehaviour, IInteractable
{

    //I have no idea what these are but I included them because otherwise unity screamed at me
    private bool needToBeInside = true;
    private bool canEnterDialogue = true;
    public bool NeedToBeInside => needToBeInside;
    public bool CanInteract => canEnterDialogue;

    public UnityEvent buttonPressed;


    private Animator animatorOfButton;

    private void Awake()
    {
        animatorOfButton = GetComponent<Animator>();
    }

    public void OnInteractionClick()
    {
        buttonPressed?.Invoke();

        animatorOfButton.SetBool("IsClick", true);

        UpdateOpenDoorScript();


    }

    private void UpdateOpenDoorScript()
    {
        // Find the OpenDoor script in the scene
        OpenDoor openDoorScript = FindObjectOfType<OpenDoor>();

        // Update the button pressed variables
        if (openDoorScript != null)
        {
            if (gameObject.name == "BigButton1")
            {
                openDoorScript.buttonOnePressed = true;
            }
            else if (gameObject.name == "BigButton2")
            {
                openDoorScript.buttonTwoPressed = true;
            }
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
