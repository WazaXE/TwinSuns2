using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{

    [Header("Params")]
    [SerializeField] private float timeBetweenLetters = 0.1f;

    [Header("Load Global JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private Image continueIcon;


    private Sprite leftSprite;
    private Sprite rightSprite;


    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Animator layoutAnimator;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private Coroutine displayLineCoroutine;

    private bool canContinueToNextLine = false;

    [SerializeField] private StateMachine stateMachine;

    private bool skipText = false;

    private const string PORTRAIT_TAG = "portrait";
    private const string SPEAKER_TAG = "speaker";
    private const string LAYOUT_TAG = "layout";

    private DialogueVariables dialogueVariables;


    [SerializeField] private EventChannel eventChannel;


    private void Awake()
    {
        if (instance != null) {
            Debug.LogWarning("Found more than one Dialogue Manager in scene");
        }
        instance = this;

        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    private void Start()
    {

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //Get layout animator
        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        //Get all of choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, Sprite leftSprite, Sprite rightSprite)
    {

        //Enter interact state
        stateMachine.Transit(stateMachine.interactState);

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        //Start listening for variabels when entering story
        dialogueVariables.StartListening(currentStory);

        //Save Sprites
        this.leftSprite = leftSprite;
        this.rightSprite = rightSprite;

        //Reset tags
        displayNameText.text = "?";
        layoutAnimator.Play("right");

        ContinueStory();

    }


    private IEnumerator ExitDialogueMode()
    {

        yield return new WaitForSeconds(0.2f);

        //Stop listening to variabels when story ends
        dialogueVariables.StopListening(currentStory);

        //Move to free state
        stateMachine.Transit(stateMachine.freeState);

        //Call eventChannel
        if (eventChannel) eventChannel.DialogueEnd();

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void Update()
    {
        //Return if dialogue is not playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        //Handle dialogue

        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && Input.GetButtonDown("Jump"))
        {
            ContinueStory();
        }

        //if player press button to continue before line is finished display
        else if (Input.GetButtonDown("Jump") && !canContinueToNextLine)
        {
            skipText = true;
        }

    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //set text for current dialogue line

            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            //Handling of tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            //If not able to continue story
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        //Set text to full line but visible characters to 0
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;


        //Hide items while text is typing
        continueIcon.enabled = false;
        HideChoices();

        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;

        //display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {

            //if player press button to continue before line is finished display
            if(skipText)
            {
                dialogueText.maxVisibleCharacters = line.Length;
                skipText = false;
                break;
            }

            //Check for rich text tag if found add without waiting
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;

                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                //If not rich add the next letter

                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(timeBetweenLetters);
            }

        }
        //actions after line has finished displaying

        //display choices if any
        DisplayChoices();


        continueIcon.enabled = true;
        skipText = false;
        canContinueToNextLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //Loop through each tag
        foreach ( string tag in currentTags)
        {

            //Parse tag
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Did not contain right number of tags");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            //Handle tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    if (tagValue == "left") {
                        portraitImage.sprite = leftSprite;
                    }
                    else if (tagValue == "right") {
                        portraitImage.sprite = rightSprite;
                    }
                    else {
                        Debug.Log("Portrait can only be left or right");
                    }
                    break;
                default:
                    Debug.LogWarning("Tag came in but couldn't be handled");
                    break;
            }
        }

    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //Check if UI can support number of incoming choices
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than UI can support.");
        }

        int index = 0;

        //enable and initialize number of choices given

        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        //Go through remaining choices and make sure they are hidden

        for (int i = index; i < choices.Length; i++) 
            {
            choices[i].gameObject.SetActive(false);  
            }

        StartCoroutine(SelectFirstChoice());

    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);

        if (variableValue == null)
        {
            Debug.LogWarning("Ink variable was null: " + variableName);

        }
        return variableValue;
    }



    //Call this whenever you want the application to end
    public void OnApplicationQuit()
    {
        if (dialogueVariables != null)
        {
            dialogueVariables.SaveVariables();
        }

    }


}
