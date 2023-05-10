using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]

public class cameraTriggerVolume : MonoBehaviour
{
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private CinemachineFreeLook defaultCam;


    BoxCollider box;
    Rigidbody rb;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();

        box.isTrigger = true;
        box.size = boxSize;

        rb.isKinematic = true;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //If not bottom rig switch to bottom rig
            if (CameraSwitcher.ActiveCamera != defaultCam.GetRig(2))
            {
                CameraSwitcher.SwitchCamera(defaultCam.GetRig(2));
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //If already bottom rig switch to middle rig
            if (CameraSwitcher.ActiveCamera == defaultCam.GetRig(2))
            {
                CameraSwitcher.SwitchCamera(defaultCam.GetRig(1));
            }
        }
    }

}
