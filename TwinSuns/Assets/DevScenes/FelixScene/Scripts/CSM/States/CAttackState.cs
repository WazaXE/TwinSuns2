using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CAttackState : CState
{
    public float jumpForce = 4f;

    public override void Enter()
    {
        stateMachine.navMeshAgent.enabled = false;
    }

    public override void Exit()
    {
        stateMachine.navMeshAgent.enabled = true;
        stateMachine.StartCoroutine(stateMachine.AttackCoolDown());
    }


    public override void FixedUpdate()
    {


    }

    public void ExecuteJump()
    {
        Vector3 horizontal = stateMachine.currentTarget.position - stateMachine.gameObject.transform.position;

        stateMachine.rb.AddForce(horizontal + Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnLanded()
    {
        stateMachine.Transit(stateMachine.chaseState);
    }
}
