using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ladder : MonoBehaviour, IInteractable
{

    private bool inRange = true;
    public bool CanInteract => inRange;

    [SerializeField]
    private bool needToBeInside;
    public bool NeedToBeInside => needToBeInside;

    private Animator anim;

    private bool isOpen;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnInteractionClick()
    {

        if(!isOpen)
        {
            //Set parameter isOpen to true
            isOpen = true;
            anim.SetBool("isOpen", true);
        }
        else if (isOpen)
        {
            //If ladder is open and player interacts the player will climb up or down the ladder
        }

    }

    private void Toggler()
    {
    }
    public void InteractInRange()
    {

    }
    public void InteractOutOfRange()
    {

    }
    public Vector3 ReturnPosition()
    {
        return Vector3.zero;
    }
}
