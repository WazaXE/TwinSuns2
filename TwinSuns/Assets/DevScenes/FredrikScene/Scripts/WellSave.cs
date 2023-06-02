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

    private bool firstInteract = true;

    [SerializeField] private GameObject visualCue;

    public void OnInteractionClick()
    {
        if (firstInteract)
        {
            wellBadWater.SetActive(false);
            wellClearWater.SetActive(true);

            // Trigger the OnPlayerSave event
            OnPlayerSave?.Invoke();
        }
        else
        {
            OnPlayerSave?.Invoke();
        }

    }

    private void Toggler()
    {

    }
    public void InteractInRange()
    {
        visualCue.SetActive(true);
    }
    public void InteractOutOfRange()
    {
        visualCue.SetActive(false);
    }
    public Vector3 ReturnPosition()
    {
        return Vector3.zero;
    }
}
