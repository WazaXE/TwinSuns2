using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimatorHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private InterractType_ animType;
    [SerializeField] private InterractType_ dialogueEndType;
    [SerializeField] private EventChannel eventChannel;



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InterractedWith()
    {
        Interracted(animType);
    }
    public void InterractedWithDialogue()
    {
        Interracted(animType);
        eventChannel.OnDialogueEndEvent += DialogueEnded;
    }
    private void DialogueEnded()
    {
        Interracted(dialogueEndType);
        eventChannel.OnDialogueEndEvent -= DialogueEnded;

    }
    private void Interracted(InterractType_ iType)
    {
        switch (iType.iType)
        {
            case AnimatorType._bool:
                animator.SetBool(iType.parameterName, iType._boolValue);

                break;
            case AnimatorType._float:
                animator.SetFloat(iType.parameterName, iType._floatValue);
                break;
            case AnimatorType._int:
                animator.SetInteger(iType.parameterName, iType._intValue);

                break;
            case AnimatorType._trigger:
                animator.SetTrigger(iType.parameterName);

                break;
            default:
                break;
        }
    }

}

public enum AnimatorType
{
    _bool,
    _float, 
    _int,
    _trigger

}

[System.Serializable]
public class InterractType_
{
    public string parameterName;
    public AnimatorType iType;
    public bool _boolValue;
    public float _floatValue;
    public int _intValue;

}