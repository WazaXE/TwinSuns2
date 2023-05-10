using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    [SerializeField] private BoxCollider doorCollider;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            doorCollider.enabled = true;
            Destroy(gameObject);
        }


    }



}
