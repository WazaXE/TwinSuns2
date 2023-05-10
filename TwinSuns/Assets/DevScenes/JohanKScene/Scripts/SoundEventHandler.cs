using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEventHandler : MonoBehaviour
{
    private AudioManTwin audioManTwin;

    private void Start()
    {
        audioManTwin = GetComponent<AudioManTwin>();
    }

    public void CactusDestroyed()
    {
        audioManTwin.interactablesAudio.CactusDestroyedAudio();
    }
    public void StartGameEvent()
    {
        audioManTwin.musicAudio.GameStart();
    }

}
