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

    [SerializeField] private Animator bigDoor1;
    [SerializeField] private Animator bigDoor2;
    [SerializeField] private GameObject lamp1;
    [SerializeField] private GameObject lamp2;
    private Animator animator;
    private string name;

    private void Start()
    {
        // Get the animator component on this object
        animator = GetComponent<Animator>();
        name = gameObject.name;

    }


    public void OnInteractionClick()
    {

            if (name == "BigButton1")
            {
                animator.SetBool("IsClick", true);
                bigDoor1.SetBool("door1", true);
                bigDoor2.SetBool("door1", true);
                lamp1.GetComponent<Renderer>().material.color = Color.green;

            }
            else
            {
                animator.SetBool("IsClick", true);
                bigDoor1.SetBool("door2", true);
                bigDoor2.SetBool("door2", true);
                lamp2.GetComponent<Renderer>().material.color = Color.green;

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
