using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject doorCamera;
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private float waitTimeSeconds = 3.0f;


    void Start()
    {
        doorCamera.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PanToDoor()
    {
        doorCamera.SetActive(true);
        playerCamera.SetActive(false);

        Invoke("ResetCamera", waitTimeSeconds);
    }

    private void ResetCamera()
    {
        playerCamera.SetActive(true);
        doorCamera.SetActive(false);
    }
}
