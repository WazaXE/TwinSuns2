using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public float attackRange = 3f;
    public float blockDuration = 1f;
    public float movementSpeed = 3f;
    public float detectionRange = 10f;

    [SerializeField] private float attackDuration = 1f;

    private bool isBlocking = false;
    private bool canAttack = true;
    private Transform playerTransform;
    private IPlayerDamageable playerDamageable;
    private NavMeshAgent navMeshAgent;
    private NavMeshObstacle navMeshObstacle;

    private Animator anim;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerDamageable = playerTransform.GetComponent<IPlayerDamageable>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        anim = GetComponent<Animator>();

        navMeshAgent.enabled = false;
        navMeshObstacle.enabled = true;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer <= attackRange && canAttack)
            {
                Attack();
            }
            else if (distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            Idle();
        }

        if (isBlocking)
        {
            blockDuration -= Time.deltaTime;

            if (blockDuration <= 0f)
            {
                StopBlocking();
            }
        }
    }

    private void Idle()
    {
        navMeshAgent.enabled = false;
        navMeshObstacle.enabled = true;
        anim.SetBool("isFly", false);
    }

    private void MoveTowardsPlayer()
    {
        navMeshAgent.enabled = true;
        navMeshObstacle.enabled = false;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= attackRange)
        {
            navMeshAgent.isStopped = true;
            anim.SetBool("isFly", false);
        }
        else
        {
            navMeshAgent.SetDestination(playerTransform.position);
            navMeshAgent.speed = movementSpeed;
            navMeshAgent.isStopped = false;
            anim.SetBool("isFly", true);
        }
    }

    private void Attack()
    {
        playerDamageable.TakeDamage();
        canAttack = false;
        StartCoroutine(ResetAttackCooldown());
    }

    private IEnumerator ResetAttackCooldown()
    {
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(attackDuration);
        canAttack = true;
        anim.SetBool("isAttack", false);
    }

    private void StartBlocking()
    {
        isBlocking = true;
    }

    private void StopBlocking()
    {
        blockDuration = 1f;
        isBlocking = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}