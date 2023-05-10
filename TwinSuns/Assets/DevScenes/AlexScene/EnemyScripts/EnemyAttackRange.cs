using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackRange : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public LayerMask enemyLayerMask;
    public float attackRange = 1f;
    public GameObject player;
    private RaycastHit hit;

    public bool isInRange;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, (player.transform.position - transform.position));
        if (Physics.Raycast(ray, out hit, attackRange, ~enemyLayerMask))
        {
            if (hit.collider.gameObject == player)
            {
                navMeshAgent.isStopped = true;
                isInRange = true;
            }
        }
        else
            isInRange = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * attackRange);
    }
}
