using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

[RequireComponent(typeof(EntityVision), typeof(EntityHealth), typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class CSM : MonoBehaviour
{
    CState currentState;
    public CIdleState idleState = new CIdleState();
    public CAttackState attackState = new CAttackState();
    public CChaseState chaseState = new CChaseState();
    public CDeathState deathState = new CDeathState();

    public EntityVision vision;
    public EntityHealth health;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Rigidbody rb;

    public List<Transform> toFollow = new List<Transform>();

    public float attackCD = 5f;
    public bool canAttack = true;

    [HideInInspector] public Transform currentTarget;

    private void Awake()
    {
        idleState.OnValidate(this);
        attackState.OnValidate(this);
        chaseState.OnValidate(this);
        deathState.OnValidate(this);

    }

    private void OnValidate()
    {
        idleState.OnValidate(this);
        attackState.OnValidate(this);
        chaseState.OnValidate(this);
        deathState.OnValidate(this);

        vision = GetComponent<EntityVision>();
        health = GetComponent<EntityHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        idleState.Start();
        attackState.Start();
        chaseState.Start();
        deathState.Start();

        currentState = idleState;
        currentState.Enter();
    }

    public void Transit(CState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public Transform ReturnClosestFollow()
    {
        toFollow = toFollow.OrderBy(x => Vector3.Distance(transform.position, x.position)).ToList();
        return toFollow[0];
    }

    public IEnumerator AttackCoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
    }

}
