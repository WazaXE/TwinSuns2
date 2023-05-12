using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables 
{

    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    private Story globalVariablesStory;

    private const string saveVariablesKey = "INK_VARIABLES";

    public void StartListening(Story story)
    {

        //Needs to be called before assigning listener
        VariablesToStory(story);

        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    }


    private void VariableChanged( string name, Ink.Runtime.Object value)
    {
        //Only maintain variables that were initialized from global ink file
        if (variables.ContainsKey(name)) {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        //Loop through each entry in dictionary 
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables )
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }

    public DialogueVariables(TextAsset loadGlobalJSON)
    {
        //Create story
        globalVariablesStory = new Story(loadGlobalJSON.text);

        //If we have saved data, load
        if (PlayerPrefs.HasKey(saveVariablesKey))
        {
            string JsonState = PlayerPrefs.GetString(saveVariablesKey);
            globalVariablesStory.state.LoadJson(JsonState);
        }

        //Initialize dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();

        //Loop through each global variable in GlobalVariables file

        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    public void SaveVariables()
    {
        if (globalVariablesStory != null)
        {
            //Load current state of variables
            VariablesToStory(globalVariablesStory);

            //This will have to be remade in the future if we want a better save system
            PlayerPrefs.SetString(saveVariablesKey, globalVariablesStory.state.ToJson());
        }
    }

    public void SetVariable(string variableName, bool variableBool)
    {

        globalVariablesStory.variablesState[variableName] = variableBool;

    }

}
