using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

[System.Serializable]
public class DashState : PlayerState
{

    public float dashTime = 1f;

    public float maxDashSpeed = 5f;

    public float coolDown = 2f;

    private float turnSmoothVelocity;

    public float turnSmoothTime = 0.1f;

    public AnimationCurve speedCurve;

    private Vector3 dir;

    private Vector3 Dir
    {
        get
        {
            return dir.normalized;
        }

        set
        {
            dir = value.normalized;
        }
    }

    float timer = 0;
    Vector3 moveDir;

    public override void Start()
    {

    }
    public override void Awake()
    {

    }

    public override void Enter()
    {
        stateMachine.animator.SetTrigger("Roll");


        Vector2 leftStick = stateMachine.move.ReadValue<Vector2>();
        if (Mathf.Abs(leftStick.x) < 0.1f) leftStick.x = 0;
        if (Mathf.Abs(leftStick.y) < 0.1f) leftStick.y = 0;
        Dir = new Vector3(leftStick.x, 0, leftStick.y);

        timer = 0;

        float targetAngle;

        if (Dir.magnitude == 0)
        {
            Dir = stateMachine.transform.rotation * Vector3.forward;
            targetAngle = Mathf.Atan2(Dir.x, Dir.z) * Mathf.Rad2Deg;
        }
        else
        {
            targetAngle = Mathf.Atan2(Dir.x, Dir.z) * Mathf.Rad2Deg + stateMachine.cam.eulerAngles.y;
        }

        float angle = Mathf.SmoothDampAngle(stateMachine.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        stateMachine.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        moveDir.Normalize();
    }

    public override void Exit()
    {
        stateMachine.StartCoroutine(stateMachine.DashCooldown(coolDown));
        stateMachine.actionAllowed = true;
    }



    public override void FixedUpdate()
    {

        if (timer > dashTime)
        {
            stateMachine.Transit(stateMachine.freeState);
        }
        else
        {
            Roll();
        }
        timer += Time.fixedDeltaTime;


    }

    private void Roll()
    {
        float percent = timer / dashTime;
        float current = maxDashSpeed * speedCurve.Evaluate(percent);
        Debug.Log(current / maxDashSpeed);

        stateMachine.MovePlayer(moveDir, current);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(stateMachine.transform.position, stateMachine.transform.position + Dir * 4);
    }
}