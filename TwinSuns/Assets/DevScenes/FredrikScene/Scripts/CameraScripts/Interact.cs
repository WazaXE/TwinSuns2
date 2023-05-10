using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Interact : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera thirdPersonCam;
    [SerializeField] CinemachineVirtualCamera interactCam;

    private void OnEnable()
    {
        CameraSwitcher.Register(thirdPersonCam);
        CameraSwitcher.Register(interactCam);
        CameraSwitcher.SwitchCamera(thirdPersonCam);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(thirdPersonCam);
        CameraSwitcher.Unregister(interactCam);
    }

    // Update is called once per frame
    void Update()
    {
        //Switching camera between Third person and interact
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Hej");
            //If we are currently in third person perspective
            if(CameraSwitcher.IsActiveCamera(thirdPersonCam))
            {
                CameraSwitcher.SwitchCamera(interactCam);
            }
            //If we are curently interacting with an AI
            else if (CameraSwitcher.IsActiveCamera(interactCam))
            {
                CameraSwitcher.SwitchCamera(thirdPersonCam);
            }
        }
    }
}
