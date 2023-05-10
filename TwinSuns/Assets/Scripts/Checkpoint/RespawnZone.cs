using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class RespawnZone : MonoBehaviour
{
    public BoxCollider boxCollider;
    public CheckPointHandler checkPointHandler;

    private void OnValidate()
    {
        if (boxCollider == null) boxCollider = GetComponent<BoxCollider>();
        if (checkPointHandler == null) checkPointHandler = FindObjectOfType<CheckPointHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!checkPointHandler)
            {
                Debug.LogError("RespawnZone: Tried to respawn the player at the last checkpoint, but the scene seems to be missing a checkpoint handler.");
                return;
            }
            CharacterController playerController = other.gameObject.GetComponent<CharacterController>();
            playerController.enabled = false;
            other.gameObject.transform.position = checkPointHandler.Respawnpoint.position;
            playerController.enabled = true;
        }
    }

}
