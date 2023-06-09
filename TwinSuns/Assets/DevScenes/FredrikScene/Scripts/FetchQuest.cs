using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;

[RequireComponent(typeof(Collider))]
public class FetchQuest : MonoBehaviour
{

    [SerializeField] private DialogueManager manager;   
    

    [SerializeField] private string variableName;
    [SerializeField] private bool variableBoolValue;


    public static event Action<string> OnItemPickUp;

    [SerializeField] private string itemID;


    private void OnTriggerEnter(Collider other)
    {
        IPlayerDamageable collided = other.GetComponent<IPlayerDamageable>();

        if (collided != null)
        {
            manager.SetVariable(variableName, variableBoolValue);

            OnItemPickUp?.Invoke(itemID);

            Destroy(this.gameObject);
        }




    }


}
