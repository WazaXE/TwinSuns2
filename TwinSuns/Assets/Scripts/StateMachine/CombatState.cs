using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class CombatState : PlayerState
{
    [SerializeField]
    private float secondsBeforeCombatEnds = 10.0f;

    private float combatEndTimer;

    public override void OnValidate(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    public override void Start()
    {
        
    }
    public override void Awake()
    {

    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.inCombat = true;

        combatEndTimer = secondsBeforeCombatEnds;
    }

    public override void Exit()
    {
        base.Exit();
        /*
        stateMachine.attack.performed -= Attack;
        stateMachine.dash.performed -= Dash;
        stateMachine.interact.performed -= Interact;
        */
    }


    public override void Update()
    {
        //stateMachine.CheckInput();

        //if (stateMachine.actionAllowed)
        //{
        //    stateMachine.TryBufferedAction();
        //}


        combatEndTimer -= Time.deltaTime;
        if (combatEndTimer <= 0)
        {
            stateMachine.inCombat = false;
            stateMachine.Transit(stateMachine.freeState);
            stateMachine.weaponHandler.SheathWeapon();
        }
    }

    int bufferIndex = 0;
    public override void FixedUpdate()
    {
        bufferIndex = 0;
        CheckInput();
        if (hasExited) return;


    }

    #region Checking for Input
    private void CheckInput()
    {
        ActionItem action = stateMachine.CheckBuffer(bufferIndex);
        PerformAction(action);
    }

    private void PerformAction(ActionItem action)
    {
        if (action == null) return;

        switch (action.action)
        {
            case ActionItem.InputAction.Attack:
                Attack(action);
                break;

            case ActionItem.InputAction.Dash:
                Dash(action);
                break;

            case ActionItem.InputAction.Interact:
                Interact(action);
                break;

            case ActionItem.InputAction.Enchant:
                Enchant(action);
                break;
        }
    }
    #endregion

    #region Actions
    void Attack(ActionItem action)
    {
        stateMachine.ConsumeAction(action);
        stateMachine.animator.SetTrigger("FirstAttack");
        stateMachine.Transit(stateMachine.attackState);
    }

    void Dash(ActionItem action)
    {
        if (stateMachine.mayDash)
        {
            stateMachine.ConsumeAction(action);
            stateMachine.Transit(stateMachine.dashState);
        }
        else
        {
            bufferIndex++;
            CheckInput();
        }
    }

    void Interact(ActionItem action)
    {
        stateMachine.ConsumeAction(action);
        stateMachine.playerInteraction.TryInteraction();
        //Kommer behöva transita här sedan för andra objekt än NPCs
        //Tänker möjligtvis att t.ex. Interactables ska ha ett event som prenumereras på så man kommer ur interactState
        //Istället för att de har en hård referens till StateMachine
    }

    void Enchant(ActionItem action)
    {
        if (stateMachine.mayEnchant)
        {
            stateMachine.ConsumeAction(action);
            stateMachine.Transit(stateMachine.enchantState);
        }
        else
        {
            bufferIndex++;
            CheckInput();
        }


    }
    #endregion

}

