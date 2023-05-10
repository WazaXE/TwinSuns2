using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class FreeState : PlayerState
{


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
        /*
        stateMachine.attack.performed += Attack;
        stateMachine.dash.performed += Dash;
        stateMachine.interact.performed += Interact;
        */

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

    }

    int bufferIndex = 0;
    public override void FixedUpdate()
    {
        bufferIndex = 0;
        CheckInput();
        //if (hasExited) return;


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
        }
    }
    #endregion

    #region Actions
    void Attack(ActionItem action)
    {
        stateMachine.ConsumeAction(action);
        //stateMachine.Transit(stateMachine.attackState);
        stateMachine.Transit(stateMachine.combatState);

        //H�r vill jag v�l egentligen att animation f�r vapnet dras fram ska spelas
        //Och egentligen d�rigenom sedan kalla p� WeaponHandlers "DrawWeapon()"
        stateMachine.weaponHandler.DrawWeapon();

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
        //Kommer beh�va transita h�r sedan f�r andra objekt �n NPCs
        //T�nker m�jligtvis att t.ex. Interactables ska ha ett event som prenumereras p� s� man kommer ur interactState
        //Ist�llet f�r att de har en h�rd referens till StateMachine
    }
    #endregion

}
