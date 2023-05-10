using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandPoof : MonoBehaviour, IInteractable
{

    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject sandPile;
    [SerializeField] private GameObject treasure;

    private bool needToBeInside = false;
    private bool canEnterDialogue = true;
    public bool NeedToBeInside => needToBeInside;
    public bool CanInteract => canEnterDialogue;

    public void InteractInRange()
    {

    }
    public void InteractOutOfRange()
    {

    }
    public void OnInteractionClick()
    {
        particle.Play();
        Object.Destroy(sandPile.gameObject);
        treasure.SetActive(true);
    }

    public Vector3 ReturnPosition()
    {
        return transform.position;
    }

}
