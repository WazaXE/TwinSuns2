using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeZoneController : MonoBehaviour
{
    [SerializeField] private Transform referencePoint;
    [SerializeField] private GameObject player;
    private Transform playerTransform;

    //S� antingen anv�nder jag en StudioEventEmitter och f�rs�ker g�ra saker d�r igenom.
    //Kan vara s� att jag beh�ver typ PLay() sedan Release() eller n�got
    [SerializeField]
    FMODUnity.StudioEventEmitter emitter;

    //ELler ska skapar jag eventen och det sj�lv, verkar fungera att anv�nda. f�r se hur det blir med parameter sen
    public EventReference musicEvent;
    private EventInstance musicInstance;





    [SerializeField] private float distanceMultiplier = 0.25f;

    bool isInRoom = false;

    private float distance = 50;

    private float finalValue = 1;
    private void Awake()
    {
        playerTransform = player.transform;
        //emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }
    private void Start()
    {


        //musicInstance = RuntimeManager.CreateInstance(musicEvent);
        //musicInstance.start();
        //musicInstance.release(); //�ven om jag releasar s� kan man pausa osv, f�rst�r inte riktigt
        
    }

    void Update()
    {



        if (!isInRoom) return;

        CalculateDistance();
        SendValue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isInRoom = true;
            musicInstance.setPaused(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInRoom = false;
            if (distance >= 10)
            {
                SendExitValue();
            }
            else
            {
                //basically om man g�r ut fram�t, testar att stanna musiken
                musicInstance.setPaused(true); //Detta verkar fungera
            }
        }
    }
    private void CalculateDistance()
    {
        Vector3 distanceVector = referencePoint.position - playerTransform.position;

        distance = Vector3.Dot(distanceVector, referencePoint.forward);

    }

    private void SendValue()
    {
        finalValue = AdjustValue();
        //Skicka parameterv�rde h�r//

        print(finalValue);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Parameter 1", finalValue);
        //musicInstance.setVolume(distance / 42);
        //musicInstance.setParameterByName("Intro",finalValue);



    }
    private void SendExitValue()
    {
        finalValue = 1;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Parameter 1", finalValue);
        //musicInstance.setParameterByName("Intro",finalValue);
    }

    private float AdjustValue()
    {
        float newDistance;

        newDistance = 11 - (distance * distanceMultiplier);

        newDistance = Mathf.Clamp(newDistance, 1, 10);
        return newDistance;
    }
}
