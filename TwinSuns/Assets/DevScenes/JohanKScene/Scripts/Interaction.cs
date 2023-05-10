using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Collider))]
public class Interaction : MonoBehaviour
{
    //Vill kanske sedan att det ska kolla om en interactable �r OneSot s� den kan tas bort omedelbart fr�n listan, eller inte ens lggas till vid t.ex. triggerbyenter

    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponentInParent<StateMachine>();    
    }
    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable == null) return;

        //Om den inte kan interageras med = return
        if (!interactable.CanInteract) return;


        interactable.InteractInRange();




        //stateMachine.interactables.Add(interactable);
        stateMachine.interactables.Add(other.gameObject);



    }
    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable == null) return;

        //Remove funktionen tittar redan om objektet �r i listan. Ingen risk f�r errors
        //stateMachine.interactables.Remove(interactable);
        stateMachine.interactables.Remove(other.gameObject);

        interactable.InteractOutOfRange();
    }

    public void TryInteraction()
    {
        //Sortera f�rst
        //if (stateMachine.interactables.Count >= 1)
        //{
        //    stateMachine.interactables = stateMachine.interactables.OrderBy(
        //        x => Vector3.Distance(this.transform.position, x.ReturnPosition())
        //        ).ToList();


        //    //Interragera sedan med den n�rmsta
        //    if (stateMachine.interactables[0].CanInteract)
        //    {
        //        stateMachine.interactables[0].OnInteractionClick();
        //    }

            

        //}

        if (stateMachine.interactables.Count >= 1)
        {
            stateMachine.interactables = stateMachine.interactables.OrderBy(
                x => Vector3.Distance(this.transform.position, x.transform.position)
                ).ToList();


            IInteractable interactable1 = stateMachine.interactables[0].GetComponent<IInteractable>();
            if (!interactable1.CanInteract) return; 

            //h�r kolla bounds om den har boolen needtobeinside, sedan om spelaren �r inom boxen, annars return
            if (interactable1.NeedToBeInside)
            {
                if (!stateMachine.interactables[0].GetComponent<Collider>().bounds.Contains(this.transform.position))
                {
                    return;
                }
            }

            //interagera sedan med den n�rmsta
            interactable1.OnInteractionClick();

        }


    }

}
