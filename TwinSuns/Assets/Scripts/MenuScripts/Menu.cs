using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public GameObject pauseFirstButton;
    public GameObject optionsFirstButton;
    public GameObject optionsClosedButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Escape"))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            //Clear selected object

            EventSystem.current.SetSelectedGameObject(null);

            //Set new selected object

            EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            optionsMenu.SetActive(false);
        }
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);

        //Clear selected object

        EventSystem.current.SetSelectedGameObject(null);

        //Set new selected object

        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);

        //Clear selected object

        EventSystem.current.SetSelectedGameObject(null);

        //Set new selected object

        EventSystem.current.SetSelectedGameObject(optionsFirstButton);

        SceneManager.LoadScene(0);
    }



}
