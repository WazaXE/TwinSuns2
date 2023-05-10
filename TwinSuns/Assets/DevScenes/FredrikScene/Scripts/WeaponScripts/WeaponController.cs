using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    //Declare weapons used
    public GameObject Sword;

    public bool IsAttacking = false;

    public GameObject Player; 

    [Tooltip("How long the player will be locked for in the attack-state")]
    public float AttackTime = 1.0f;


    [HideInInspector] public AttackState attackState;

    private StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponentInParent<StateMachine>();

        attackState = stateMachine.attackState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwordAttack()
    {
        IsAttacking = true;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        Invoke("ResetAttackBool", AttackTime);
        //StartCoroutine(ResetAttackBool());
    }

    //IEnumerator ResetAttackBool()
    void ResetAttackBool()
    {
        IsAttacking = false;

        var stateMachine = Player.GetComponent<StateMachine>();

        //Return to Free state
        stateMachine.Transit(stateMachine.freeState);
    }

    public void DoDam()
    {
        //attackState.Attack(); //Eventuellt skicka med vapen-stats som damage
    }

}
