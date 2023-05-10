using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
//Jumping out of commision
public class JumpState : PlayerState 
{

    private Vector3 velocity;

    private float timestamp; 

    [SerializeField] float speed = 1;

    [SerializeField] float jumpHeight = 3;

    private float turnSmoothVelocity;

    public float turnSmoothTime = 0.1f;
    public override void OnValidate(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Awake() { }
    public override void Start() 
    { 
    
        //Call sound effect here


    }

    public override void Enter() {

        //Execute jump
        //velocity.y = Mathf.Sqrt(jumpHeight * -2 * stateMachine.gravity);

        timestamp = Time.time;

    }
    public override void Exit() {
        stateMachine.actionAllowed = true;
    }
    public override void FixedUpdate() {


        if (stateMachine.isGrounded && Time.time > (timestamp + 0.5f))
        {
            stateMachine.Transit(stateMachine.freeState);
        }
        else
        {
            MovementInAir();

            stateMachine.controller.Move(velocity * Time.fixedDeltaTime);

            //velocity.y += stateMachine.gravity * Time.deltaTime;

        }


        /*
        if (velocity.y < stateMachine.maxFallspeed)
        {
            velocity.y = stateMachine.maxFallspeed;
        }
        */
    }
    public override void Update() {

    }

    private void MovementInAir()
    {
        //Walk input

        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        //Execute Walk

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + stateMachine.cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(stateMachine.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            stateMachine.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.Normalize();

            stateMachine.MovePlayer(moveDir, speed);





        }
    }
}
