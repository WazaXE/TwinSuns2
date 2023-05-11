using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CIdleState : CState
{
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (stateMachine.vision.InRange(stateMachine.ReturnClosestFollow().position))
        {
            stateMachine.Transit(stateMachine.chaseState);
        }
    }
}
