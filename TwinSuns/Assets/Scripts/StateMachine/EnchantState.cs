using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class EnchantState : PlayerState
{
    [SerializeField]
    private float enchantCooldown = 8.0f;
    [SerializeField]
    private float enchantDuration = 5.0f;

    [SerializeField]
    private float timeInsideState = 1.0f;
    private float timer = 0;

    public override void Awake() { }
    public override void Start() { }

    public override void Enter()
    {
        timer = 0;
    }
    public override void Exit()
    {
        stateMachine.actionAllowed = true;
        stateMachine.StartCoroutine(stateMachine.EnchantCooldown(enchantCooldown));
        stateMachine.weaponHandler.EnchantWeapon(enchantDuration, DamageType.Fire); //skickar eld sålänge
    }

    public override void Update()
    {
        base.Update();

        //timePassed += Time.deltaTime;

        //clipLength = stateMachine.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        //clipSpeed = stateMachine.animator.GetCurrentAnimatorStateInfo(0).speed;


        //if (timePassed >= clipLength / clipSpeed && attack) //Om animationen är klar och attack har efterfrågats
        //{
        //    stateMachine.Transit(stateMachine.attackState);
        //    return;
        //}
        //if (timePassed >= clipLength / clipSpeed)
        //{
        //    stateMachine.Transit(stateMachine.combatState);
        //}


        timer += Time.deltaTime;

        if (timer >= timeInsideState)
        {
            LeaveState();
        }

    }

    int bufferIndex = 0;
    public override void FixedUpdate()
    {
        bufferIndex = 0;
        if (hasExited) return;
    }


    private void LeaveState()
    {
        stateMachine.Transit(stateMachine.combatState);
    }
}
