using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;



[RequireComponent(typeof(Collider))]
public class FetchQuest : MonoBehaviour, IInteractable
{

    private bool canEnterDialogue = false;
    public bool CanInteract => canEnterDialogue;

    [SerializeField] private bool needToBeInside = true;
    public bool NeedToBeInside => needToBeInside;


    [SerializeField] private string variableName;
    [SerializeField] private bool variableBoolValue;

    [SerializeField] private TextAsset inkAsset;

    private Story inkStory;

    private void Awake()
    {
        string inkText = inkAsset.text;
        inkStory = new Story(inkText);
    }



    public void OnInteractionClick()
    {
        inkStory.variablesState[variableName] = variableBoolValue;
        Destroy(this.gameObject);
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
