using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Collider))]
public class SleepTent : MonoBehaviour, IInteractable
{

    [SerializeField]
    private GameObject Day;
    [SerializeField]
    private GameObject Night;

    private CameraFade cameraFade;

    [SerializeField] private GameObject exitToFireTemple;

    private bool inRange = true;
    public bool CanInteract => inRange;

    [SerializeField]
    private bool needToBeInside;
    public bool NeedToBeInside => needToBeInside;

    [SerializeField] private GameObject exitDialogue, visualCue;


    //Start is called before the first frame update
    void Start()
    {
        cameraFade = FindObjectOfType<CameraFade>();

        visualCue.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {

    }

    public void OnInteractionClick()
    {

        cameraFade.ToggleFade();
        Invoke("Toggler", 2);




    }

    private void Toggler()
    {
        cameraFade.ToggleFade();

        //Switch post processing
        Night.SetActive(false);
        Day.SetActive(true);
        exitToFireTemple.SetActive(true);
        exitDialogue.SetActive(false);
    }
    public void InteractInRange()
    {
        visualCue.SetActive(true);
    }
    public void InteractOutOfRange()
    {
        visualCue.SetActive(false);
    }
    public Vector3 ReturnPosition()
    {
        return Vector3.zero;
    }

}
