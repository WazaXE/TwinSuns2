using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;



[RequireComponent(typeof(Collider))]
public class FetchQuest : MonoBehaviour
{

   


    [SerializeField] private string variableName;
    [SerializeField] private bool variableBoolValue;

    [SerializeField] private TextAsset inkAsset;

    private Story inkStory;

    private void Awake()
    {
        string inkText = inkAsset.text;
        inkStory = new Story(inkText);
    }





    private void OnTriggerEnter(Collider other)
    {
        IPlayerDamageable collided = other.GetComponent<IPlayerDamageable>();

        if (collided != null)
        {
            inkStory.variablesState[variableName] = variableBoolValue;

            Destroy(this.gameObject);
        }




    }


}
