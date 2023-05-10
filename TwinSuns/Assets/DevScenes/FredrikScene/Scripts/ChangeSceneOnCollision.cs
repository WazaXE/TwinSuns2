using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChangeSceneOnCollision : MonoBehaviour
{

    [SerializeField] private int loadScene;

    private TransitionManager transitionManager;
    [Tooltip("The ID of the exit the transition should lead to. Set to 0 if the scene should be loaded without specific exit")] 
    public int entryID = 0;

    [SerializeField]
    private float blackTime = 2f;
    private CameraFade cameraFade;


    private void Start()
    {
        cameraFade = FindObjectOfType<CameraFade>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            cameraFade.ToggleFade();
            Invoke("ChangeScene", blackTime);
        }
    }


    private void ChangeScene()
    {
        transitionManager = FindObjectOfType<TransitionManager>();

        if (transitionManager != null)
        {
            transitionManager.LoadScene(entryID, loadScene);
        }
        else
        {
            Debug.LogWarning("ChangeSceneOnCollision: The scene seems to be missing a transition manager. Transitioning without potential player transform information...");
            SceneManager.LoadScene(loadScene);
        }
    }

}
