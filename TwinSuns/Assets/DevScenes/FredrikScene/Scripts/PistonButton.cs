using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonButton : MonoBehaviour, IInteractable
{

    //I have no idea what these are but I included them because otherwise unity screamed at me
    private bool needToBeInside = false;
    private bool canEnterDialogue = true;
    public bool NeedToBeInside => needToBeInside;
    public bool CanInteract => canEnterDialogue;

    [SerializeField] private Animator animator;

    [SerializeField] private string nameOfParameter;
    [SerializeField] private bool boolValue;

    private Animator animatorOfButton;

    [SerializeField] private GameObject visualCue;


    private void Start()
    {
        // Get the animator component on this object
        animatorOfButton = GetComponent<Animator>();
        name = gameObject.name;

    }

    public void OnInteractionClick()
    {

        animatorOfButton.SetBool("IsClick", true);

        animator.SetBool(nameOfParameter, boolValue);

        visualCue.SetActive(false);

        Destroy(this);
    }



    public void InteractInRange()
    {
        visualCue.SetActive(true);
    }

    public void InteractOutOfRange()
    {
    }

    public Vector3 ReturnPosition()
    {
        return transform.position;
    }

}
