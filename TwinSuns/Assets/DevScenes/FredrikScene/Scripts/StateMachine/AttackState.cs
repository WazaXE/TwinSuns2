using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class AttackState : PlayerState 
{

    //public GameObject weaponHolder;
    //private WeaponController wController;
    //[SerializeField] public Transform weaponPointOrigin;
    //[SerializeField] public Vector3 weaponSize = new Vector3(1f,1f,1f);
    //[SerializeField] public float weaponSizeFloat = 2f;

    float TrueClipLength
    {
        get
        {
            return stateMachine.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length / stateMachine.animator.GetCurrentAnimatorStateInfo(0).speed;
        }
    }


    float timePassed;
    float clipLength;
    float clipSpeed;
    bool attack;
    [SerializeField]
    [Range(0f, 1f)][Tooltip("After what percentage of the duration of the attack animation that the player should be able to queue their next attack.")] float percentageToCallNextAttack = 0.5f;

    public override void Awake() { }
    public override void Start() { }

    public override void Enter() {

        //Time.timeScale = 0.2f;

        timePassed = 0;
        lastFrame = 0f;

    }
    public override void Exit() {
        //Time.timeScale = 1f;
        stateMachine.actionAllowed = true;
    }

    private float lastFrame = 0f;
    public override void Update()
    {
        base.Update();

    }

    int bufferIndex = 0;
    bool onChainAllowed;
    public override void FixedUpdate() 
    {
        timePassed += Time.fixedDeltaTime;
        /*
        clipLength = stateMachine.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        clipSpeed = stateMachine.animator.GetCurrentAnimatorStateInfo(0).speed;
        */

        
        if (!attack && onChainAllowed)
        {
            bufferIndex = 0;
            CheckInput();
        }
        lastFrame = timePassed;
    }
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
        }
    }
    void Attack(ActionItem action)
    {
        stateMachine.ConsumeAction(action);
        //stateMachine.Transit(stateMachine.attackState);
        //stateMachine.animator.SetTrigger("Attack");
        attack = true;
        stateMachine.animator.SetBool("Attack", true);
        //stateMachine.animator.SetBool("Attack", true);
    }

    public void OnAttackEnd()
    {
        if (attack)
        {
            stateMachine.Transit(stateMachine.attackState);
            return;
        }
        stateMachine.Transit(stateMachine.combatState);
    }
    public void OnAttackChainAllowed()
    {
        attack = false;
        stateMachine.animator.SetBool("Attack", false);
        onChainAllowed = true;
    }

}