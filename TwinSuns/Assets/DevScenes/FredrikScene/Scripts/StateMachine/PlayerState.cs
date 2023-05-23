using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerState
{
    [HideInInspector] public StateMachine stateMachine = null;
    protected bool hasExited = false;

    [Tooltip("Whether the player should listen to input while in this state")]public bool listenToInput;
    [Tooltip("Whether the player should be affected by gravity while in this state")] public bool doGravity;


    public virtual void OnValidate(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Awake() { }
    public virtual void Start() { }

    public virtual void Enter() { hasExited = false; }
    public virtual void Exit() { hasExited = true; }
    public virtual void FixedUpdate() { }
    public virtual void Update() { }
}
