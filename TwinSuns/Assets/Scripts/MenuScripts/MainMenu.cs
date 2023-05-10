using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    private AudioManTwin audioManTwin;

    public GameObject firstButton;
    public GameObject optionFirstButton;


   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

       
    }

    public void GoToSettingsMenu()
    {
        //SceneManager.LoadScene(); //Add settings menu


        //Clear selected object

        EventSystem.current.SetSelectedGameObject(null);

        //Set new selected object

        EventSystem.current.SetSelectedGameObject(optionFirstButton);


    }

    public void ButtonPressedSound() 
    {
        audioManTwin.menuAudio.MenuPressAudio(this.gameObject);
    }
    public void ButtonHoveredSound()
    {
        audioManTwin.menuAudio.MenuHoverAudio(this.gameObject);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        //Clear selected object

        EventSystem.current.SetSelectedGameObject(null);

        //Set new selected object

        EventSystem.current.SetSelectedGameObject(firstButton);

        audioManTwin = FindObjectOfType<AudioManTwin>();
    }
}
