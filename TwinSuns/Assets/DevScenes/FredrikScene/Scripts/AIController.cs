using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public float attackRange = 3f;
    public float blockDuration = 1f;
    public float movementSpeed = 3f;

    [SerializeField] private float attackDuration = 1f;

    private bool isBlocking = false;
    private bool canAttack = true;
    private Transform playerTransform;
    private IPlayerDamageable playerDamageable;
    private NavMeshAgent navMeshAgent;

    private Animator anim;

    private void Start()
    {
        // Find and store the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the player's damageable component
        playerDamageable = playerTransform.GetComponent<IPlayerDamageable>();

        // Get the NavMeshAgent component for movement
        navMeshAgent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= attackRange && canAttack)
        {
            Attack();
        }
        else if (distanceToPlayer > attackRange)
        {
            // Move towards the player if they are out of attack range
            MoveTowardsPlayer();
        }

        // You can add conditions for blocking here
        // For example, if the player is using an ability, the AI can start blocking

        // If the AI is currently blocking, count down the block duration
        if (isBlocking)
        {
            blockDuration -= Time.deltaTime;

            if (blockDuration <= 0f)
            {
                StopBlocking();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // If within or very close to the attack range, stop moving
        if (distanceToPlayer <= attackRange)
        {
            navMeshAgent.isStopped = true;
        }
        else
        {
            // Calculate the direction from the AI to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Normalize the direction vector
            directionToPlayer.Normalize();

            // Calculate the target position within the attack range
            Vector3 targetPosition = playerTransform.position - directionToPlayer * attackRange;

            // Set the destination for the NavMeshAgent to the target position
            navMeshAgent.SetDestination(targetPosition);

            // Adjust the NavMeshAgent's speed to the desired movement speed
            navMeshAgent.speed = movementSpeed;

            // Resume movement
            navMeshAgent.isStopped = false;
        }
    }

    private void Attack()
    {
        // Trigger the attack animation or any other attack-related behavior

        // Call the TakeDamage() method on the player's damageable component
        playerDamageable.TakeDamage();

        // Disable further attacks for a cooldown period
        canAttack = false;

        // Start a cooldown coroutine
        StartCoroutine(ResetAttackCooldown());
    }

    private IEnumerator ResetAttackCooldown()
    {
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(attackDuration); // Change the cooldown duration as needed
        canAttack = true;
        anim.SetBool("isAttack", false);

    }
    private void StartBlocking()
    {
        // Trigger the block animation or any other blocking-related behavior

        // Set the isBlocking flag to true
        isBlocking = true;
    }

    private void StopBlocking()
    {
        // Stop the block animation or any other blocking-related behavior

        // Reset the block duration and isBlocking flag
        blockDuration = 1f; // Change the block duration as needed
        isBlocking = false;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}