using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


[System.Serializable]
public class HurtState : PlayerState
{
    public EventReference eventRef;

    public string damageEvent = "event:/Player/Damaged/Player_Damaged";
    public override void OnValidate(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Awake() { }
    public override void Start() { }

    public override void Enter() 
    {
        RuntimeManager.PlayOneShot(damageEvent);
    }
    public override void Exit() { }
    public override void FixedUpdate() { }
}
