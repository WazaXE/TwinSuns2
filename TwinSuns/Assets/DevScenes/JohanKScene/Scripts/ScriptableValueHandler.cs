using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableValueHandler : MonoBehaviour
{
    [SerializeField] private BooleanObject_Scriptable booleanScriptable;
    private AudioManTwin audioManTwin;
    public StudioEventEmitter studioEventEmitter;

    private void Awake()
    {
        audioManTwin = GetComponent<AudioManTwin>();

        if (booleanScriptable.boolean)
        {
            //audioManTwin.musicAudio.tutorialMusicInstance.setParameterByName("Intro", 1.0f);
            studioEventEmitter.SetParameter("Parameter 1", 10);
        }
    }
    public bool ReturnScriptableBoolean() { return booleanScriptable.boolean; }
    

}
