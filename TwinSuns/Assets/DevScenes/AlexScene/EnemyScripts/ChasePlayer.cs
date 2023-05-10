using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private Transform moveToTransform;
    private NavMeshAgent navMeshAgent;
        public Animator cactiAnimator;



    public bool isIdle = true;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        cactiAnimator = GetComponent<Animator>();

    }
    void Update()
    {
        if (isIdle == false)
        {
            navMeshAgent.destination = moveToTransform.position;

            cactiAnimator.SetFloat("Speed", 5);



        }
    }
}
