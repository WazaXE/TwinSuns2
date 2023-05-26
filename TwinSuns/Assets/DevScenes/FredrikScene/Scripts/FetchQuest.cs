using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;



[RequireComponent(typeof(Collider))]
public class FetchQuest : MonoBehaviour
{

    [SerializeField] private DialogueManager manager;   
    

    [SerializeField] private string variableName;
    [SerializeField] private bool variableBoolValue;







    private void OnTriggerEnter(Collider other)
    {
        IPlayerDamageable collided = other.GetComponent<IPlayerDamageable>();

        if (collided != null)
        {
            manager.SetVariable(variableName, variableBoolValue);

            Destroy(this.gameObject);
        }




    }


}
