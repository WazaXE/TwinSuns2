using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CChaseState : CState
{
    //Transform target;
    public float speed = 2f;

    public override void OnValidate(CSM stateMachine)
    {
        base.OnValidate(stateMachine);
        if (speed < 0)
        {
            Debug.LogWarning("CChaseState: Speed may not be negative");
            speed = 0f;
        }
    }

    public override void Enter()
    {
        //target = stateMachine.ReturnClosestFollow();
        stateMachine.currentTarget = stateMachine.ReturnClosestFollow();
        stateMachine.navMeshAgent.speed = speed;
    }

    public override void FixedUpdate()
    {
        if (stateMachine.canAttack && stateMachine.vision.InRange(stateMachine.currentTarget.position))
        {
            stateMachine.Transit(stateMachine.attackState);
            return;
        }

        stateMachine.navMeshAgent.destination = stateMachine.currentTarget.position;

        if (!stateMachine.vision.InRange(stateMachine.currentTarget.position))
        {
            stateMachine.Transit(stateMachine.idleState);
            return;
        }

    }
}
