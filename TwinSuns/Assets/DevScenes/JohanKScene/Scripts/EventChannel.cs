using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Event Channel", menuName = "Scriptable Objects/Event Channel")]
public class EventChannel : ScriptableObject
{
    public delegate void EventCallback();
    public event EventCallback OnDialogueEndEvent;

    public void DialogueEnd()
    {
        OnDialogueEndEvent?.Invoke();
    }

}
