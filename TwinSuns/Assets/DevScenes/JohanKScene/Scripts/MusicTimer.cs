using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MusicTimer : MonoBehaviour
{
    private AudioManTwin audioManTwin;

    [SerializeField] private float timeBeforeChange = 10;
    [SerializeField] private int parameterValue = 1;
    [SerializeField] private BooleanObject_Scriptable booleanScriptable;


    private void Awake()
    {
        audioManTwin = GetComponent<AudioManTwin>();

    }
    private void Start()
    {
        Invoke("ChangeParameter", timeBeforeChange);
    }


    private void ChangeParameter()
    {
        //audioManTwin.musicAudio.AdjustTutorialMusicParameter();
        booleanScriptable.boolean = true;
    }
}
