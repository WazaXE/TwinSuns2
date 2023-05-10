using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallButton : MonoBehaviour, IInteractable
{

    //I have no idea what these are but I included them because otherwise unity screamed at me
    private bool needToBeInside = false;
    private bool canEnterDialogue = true;
    public bool NeedToBeInside => needToBeInside;
    public bool CanInteract => canEnterDialogue;


    [SerializeField] private Animation door;
    private Animator animator;

    private void Start()
    {
        // Get the animator component on this object
        animator = GetComponent<Animator>();
        name = gameObject.name;

    }


    public void OnInteractionClick()
    {

        animator.SetBool("IsClick", true);
        door.Play("SecretDoorOpen");
        Destroy(this);

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
