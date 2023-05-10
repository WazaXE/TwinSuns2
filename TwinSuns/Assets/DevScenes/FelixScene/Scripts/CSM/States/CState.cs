using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CState
{
    [HideInInspector] public CSM stateMachine = null;
    protected bool hasExited = false;

    public virtual void OnValidate(CSM stateMachine)
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
