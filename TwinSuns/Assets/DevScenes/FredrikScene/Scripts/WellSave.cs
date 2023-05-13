using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WellSave : MonoBehaviour, IInteractable
{
    private bool inRange = true;
    public bool CanInteract => inRange;

    [SerializeField]
    private bool needToBeInside;
    public bool NeedToBeInside => needToBeInside;

    public static event Action OnPlayerSave;

    [SerializeField] private GameObject wellBadWater;
    [SerializeField] private GameObject wellClearWater;

    private bool firstInteract;

    public void OnInteractionClick()
    {
        if (!firstInteract)
        {
            wellBadWater.SetActive(false);
            wellClearWater.SetActive(true);
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
