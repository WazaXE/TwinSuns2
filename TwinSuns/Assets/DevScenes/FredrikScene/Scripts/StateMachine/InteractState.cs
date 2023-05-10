using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InteractState : PlayerState 
{

    public override void OnValidate(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Awake() { }
    public override void Start() { }

    public override void Enter() {
    }
    public override void Exit() {
    }
    public override void FixedUpdate() 
    {
    }
    public override void Update() {
    }
}
