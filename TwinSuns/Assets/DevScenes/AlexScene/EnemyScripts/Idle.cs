using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    //public Transform playerTransform;
    [HideInInspector] public ChasePlayer chasePlayer;
    [SerializeField]
    private float timeBeforeChase = 3.0f;
    
    void Start()
    {
        chasePlayer = GetComponent<ChasePlayer>();
    }
    void Update()
    {
        
    }

    public void Damaged()
    {
        Invoke("StopIdle", timeBeforeChase);
        chasePlayer.cactiAnimator.SetBool("Awake", true);
    }

    private void StopIdle()
    {
        chasePlayer.isIdle = false;

    }

}
