using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool CanInteract { get; }

    bool NeedToBeInside { get; }
    void InteractInRange();
    void InteractOutOfRange();
    void OnInteractionClick();

    Vector3 ReturnPosition();

}
