using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class CactusDestroying : MonoBehaviour
{
    private AudioManTwin audioManTwin;

    [SerializeField]
    private GameObject camp;
    [SerializeField]
    private GameObject Day;
    [SerializeField]
    private GameObject Night;


    [SerializeField] private GameObject oldChief;

    [SerializeField]
    private float blackTime = 2f;
    private CameraFade cameraFade;


    private GameObject[] cactusList;
    [SerializeField]
    private int cactusAmount;

    private void Start()
    {
        cameraFade = FindObjectOfType<CameraFade>();
        camp.SetActive(false);

        cactusAmount = transform.childCount;

        audioManTwin = FindObjectOfType<AudioManTwin>();
    }

    public void SubtractCactus()
    {
        cactusAmount--;

        if (cactusAmount <= 0)
        {
            cameraFade.ToggleFade();
            Invoke("SpawnCamp", blackTime);
        }
    }

    private void SpawnCamp()
    {

        //Trigger this when all Cacti are destroyed
        camp.SetActive(true);
        cameraFade.ToggleFade();

        audioManTwin.interactablesAudio.BuildingAudio(this.gameObject);

        //Switch post processing 
        Day.SetActive(false);
        Night.SetActive(true);
        //walla bror nu har vi annan light


        //Byt plats på Chief Turum
        oldChief.SetActive(false);
    }

}

