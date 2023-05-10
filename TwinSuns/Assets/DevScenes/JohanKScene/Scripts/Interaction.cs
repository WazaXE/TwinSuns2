using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Collider))]
public class Interaction : MonoBehaviour
{
    //Vill kanske sedan att det ska kolla om en interactable är OneSot så den kan tas bort omedelbart från listan, eller inte ens lggas till vid t.ex. triggerbyenter

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

        //Remove funktionen tittar redan om objektet är i listan. Ingen risk för errors
        //stateMachine.interactables.Remove(interactable);
        stateMachine.interactables.Remove(other.gameObject);

        interactable.InteractOutOfRange();
    }

    public void TryInteraction()
    {
        //Sortera först
        //if (stateMachine.interactables.Count >= 1)
        //{
        //    stateMachine.interactables = stateMachine.interactables.OrderBy(
        //        x => Vector3.Distance(this.transform.position, x.ReturnPosition())
        //        ).ToList();


        //    //Interragera sedan med den närmsta
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

            //här kolla bounds om den har boolen needtobeinside, sedan om spelaren är inom boxen, annars return
            if (interactable1.NeedToBeInside)
            {
                if (!stateMachine.interactables[0].GetComponent<Collider>().bounds.Contains(this.transform.position))
                {
                    return;
                }
            }

            //interagera sedan med den närmsta
            interactable1.OnInteractionClick();

        }


    }

}
