using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Collider))]
public class FetchQuest : MonoBehaviour, IInteractable
{

    private bool canEnterDialogue = false;
    public bool CanInteract => canEnterDialogue;

    [SerializeField] private bool needToBeInside = true;
    public bool NeedToBeInside => needToBeInside;


    [SerializeField] private string variableName;
    [SerializeField] private bool variableBoolValue;

    [Header("Load Global JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    private DialogueVariables dialogueVariables;


    private void Awake()
    {
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    public void OnInteractionClick()
    {
        Debug.Log("Hej");
        dialogueVariables.SetVariable(variableName, variableBoolValue);
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
