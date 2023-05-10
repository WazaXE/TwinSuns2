using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireMask : MonoBehaviour, IInteractable
{

    private bool inRange = true;
    public bool CanInteract => inRange;

    [SerializeField]
    private bool needToBeInside;
    public bool NeedToBeInside => needToBeInside;

    [SerializeField] private Animator anim;

    private bool isOpen;

    public void OnInteractionClick()
    {
    }

    private void Toggler()
    {
    }
    public void InteractInRange()
    {
        if (!isOpen)
        {
            //Set parameter isOpen to true
            isOpen = true;
            anim.SetBool("isOpen", true);

            //Play animation that Nim is happy
            //Unlock fire sword enchantement

        }
    }
    public void InteractOutOfRange()
    {

    }
    public Vector3 ReturnPosition()
    {
        return Vector3.zero;
    }
}
