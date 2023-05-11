using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CChaseState : CState
{
    Transform target;

    public override void Enter()
    {
        target = stateMachine.ReturnClosestFollow();
    }

    public override void FixedUpdate()
    {
        
    }
}
