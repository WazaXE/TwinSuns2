using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [Range (0, 360)] public float viewAngle;
    public float viewRadius;

    public GameObject playerRef;

    public LayerMask targetLayerMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    [Tooltip ("Hur ofta den ska uppdatera och kolla om spelaren är i sitt FOV")]
    public float delayUpdate;

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOWRoutine());
    }

    private IEnumerator FOWRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(delayUpdate);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, viewRadius, targetLayerMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
