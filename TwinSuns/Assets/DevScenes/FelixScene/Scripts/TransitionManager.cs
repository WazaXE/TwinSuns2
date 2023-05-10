using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance = null;
    //It had to be done
    private StateMachine player;
    private List<TransitionExit> transitionExits;
    public int entryID;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {

        player = FindObjectOfType<StateMachine>();
        transitionExits = new List<TransitionExit>(FindObjectsOfType<TransitionExit>());
        if (entryID != 0 && player != null && instance == this)
        {
            TransitionExit chosenExit = null;
            int found = 0;
            foreach(TransitionExit exit in transitionExits)
            {
                if (entryID == exit.entryID)
                {
                    chosenExit = exit;
                    found++;
                }
            }


            if (found < 1)
            {
                Debug.LogError("TransitionManager: Tried to transition to exit with ID " + entryID + "but no exit with that ID was found.");
            }

            else if (found > 1)
            {
                Debug.LogError("TransitionManager: Tried to transition to exit with ID " + entryID + "but multiple exits with that ID were found.");
            }

            else
            {
                Debug.Log(chosenExit.gameObject.name);
                CharacterController controller = player.controller;
                if (controller == null)
                {
                    Debug.LogError("TransitionManager: The player found did not possess a Character Controller component.");
                    return;
                }
                controller.enabled = false;
                player.transform.position = chosenExit.transform.position;
                controller.enabled = true;
                player.transform.rotation = chosenExit.transform.rotation;
            }
        }
    }

    public void LoadScene(int entryID, int sceneID)
    {
        this.entryID = entryID;
        SceneManager.LoadScene(sceneID);
    }


}
