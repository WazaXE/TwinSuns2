using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerMovement
{
    private StateMachine stateMachine;

    //public bool legacyMovement = false;

    private Vector3 Forward
    {
        get
        {
            return new Vector3(stateMachine.cam.forward.x, 0, stateMachine.cam.forward.z).normalized;
        }
    }

    private Vector3 Right
    {
        get
        {
            return new Vector3(stateMachine.cam.right.x, 0, stateMachine.cam.right.z);
        }
    }

    private bool listen = false;
    private bool doGravity = false;

    private Vector3 lastPos;
    private Vector3 velocity;

    private Vector3 moveHorizontal;
    private float moveVertical;
    public void OnValidate(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    public void Calculate(bool listen, bool doGravity)
    {
        this.listen = listen;
        this.doGravity = doGravity;

        FetchInput();
        FetchCollision();
        CalculateVelocity();

        CalculateHorizontal();
        //GetJumpApex();
        CalculateGravity();
        PerformMovement();
        GenerateAV();
        UpdateAnimator();

    }

    #region Fetch Input Details

    public FrameInput _input;
    private void FetchInput()
    {
        Vector2 leftStick = Vector2.zero;
        bool sprintHold = false;
        bool dashPress = false;
        //bool jumpPress = false;
        //bool jumpRelease = false;

        if (listen)
        {
            leftStick = stateMachine.move.ReadValue<Vector2>();
            sprintHold = stateMachine.sprint.ReadValue<float>() > 0;
            dashPress = stateMachine.dash.WasPressedThisFrame();
            //jumpPress = stateMachine.jump.WasPressedThisFrame();
            //jumpRelease = stateMachine.jump.WasReleasedThisFrame();
        }

        //_input = new FrameInput(leftStick.x, leftStick.y, sprintHold, dashPress, jumpPress, jumpRelease);
        _input = new FrameInput(leftStick.x, leftStick.y, sprintHold, dashPress);
    }

    #endregion

    #region Fetch Collision Details
    bool collisionDown = false;
    void FetchCollision()
    {
        collisionDown = stateMachine.isGrounded;
    }

    #endregion

    #region Calculate Velocity


    void CalculateVelocity()
    {
        if (lastPos != null) velocity = stateMachine.transform.position - lastPos / Time.deltaTime;
        else velocity = Vector3.zero;
        lastPos = stateMachine.transform.position;
    }

    #endregion

    #region Horizontal Movement

    [Header("Horizontal Movement")]
    [SerializeField][Tooltip("The rate at which the players speed is accelerated when moving")] private float moveAcceleration = 10f;
    [SerializeField][Tooltip("The maximal speed of which the player is normally able to move")] private float maxSpeed = 5f;
    [SerializeField] [Tooltip("The maximal speed of which the player is able to move when sprinting")] private float maxSprintSpeed = 9f;
    [SerializeField][Tooltip("The rate at which the player is deaccelerated when input is missing")] private float moveRetardation = 15f;

    //[SerializeField][Tooltip("Whether the player should get a horizontal boost in the apex of their jump.")] private bool doApexBoost;
    //[SerializeField][Tooltip("The bonus acceleration gained in the apex of the jump.")] private float apexBoost = 2f;

    [SerializeField][Tooltip("The minimal amount of stick movement required (0-1) to be registered as movement input.")][Range(0f, 1f)] private float axisThreshhold = 0.1f;

    private float turnSmoothVelocity;
    [SerializeField][Tooltip("Time for the controller to interpolate rotation in movement")] private float turnSmoothTime = 0.1f;

    void CalculateHorizontal()
    {
        if (Mathf.Abs(_input.x) >= axisThreshhold || Mathf.Abs(_input.y) >= axisThreshhold)
        {
            float frameMaxSpeed = 0f;
            if (_input.sprintHold) frameMaxSpeed = maxSprintSpeed;
            else frameMaxSpeed = maxSpeed;
            moveHorizontal += (Forward * _input.y * Time.deltaTime * moveAcceleration) +
                              (Right * _input.x * Time.deltaTime * moveAcceleration);

            moveHorizontal = Vector3.ClampMagnitude(moveHorizontal, frameMaxSpeed);

            Vector3 direction = new Vector3(_input.x, 0, _input.y);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + stateMachine.cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(stateMachine.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            stateMachine.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        else
        {
            moveHorizontal = Vector3.MoveTowards(moveHorizontal, Vector3.zero, moveRetardation * Time.deltaTime);
        }
    }

    #endregion

    #region Calculate Gravity

    [Header("Gravity")]
    //[SerializeField][Tooltip("The minimal force of which the player is affected by gravity")] private float minFallSpeed = 20f;
    //[SerializeField][Tooltip("The maximal force of which the player is affected by gravity")] private float maxFallSpeed = 30f;
    [SerializeField][Tooltip("The terminal velocity of the player")] private float fallClamp = -10f;

    public float gravityConstant = -10f;

    void CalculateGravity()
    {
        if (!collisionDown)
        {
            float mg = gravityConstant * Time.deltaTime;

            moveVertical += mg;

            moveVertical = Mathf.Clamp(moveVertical, fallClamp, Mathf.Infinity);
        }
        else
        {
            moveVertical = 0;
        }
    }

    #endregion

    /**
    #region Calculate Jump

    [SerializeField][Tooltip("The force of which the player is propelled when jumping")] private float jumpForce = 10f;

    [SerializeField][Tooltip("Whether or not the player should be able to coyote jump")] private bool useCoyoteTime = false;
    [SerializeField][Tooltip("The duration of which the player may coyote jump")] private float coyoteTime = 0.2f;
    private float coyoteTimer = 0f;
    private bool canJumpCoyote = false;


    [SerializeField][Tooltip("Whether or not the player should be able to cancel their jump")] private bool useJumpCancel = false;
    [SerializeField][Tooltip("The multiplicative force of which the gravity is multiplied with in the event that the player canceled their jump")] private float jumpCancelGravityModifier = 3.5f;
    private bool jumpCanceled = false;

    //Jump Buffering will be included in the implementation of input buffering

    [SerializeField][Tooltip("At which vertical velocity the player is considered to be in the apex of their jump")] private float jumpApexThreshhold = 5f;
    private float apexPoint = 0f;

    void GetJumpApex()
    {
        if (collisionDown)
        {
            apexPoint = 0f;
        }
        else
        {
            apexPoint = Mathf.InverseLerp(jumpApexThreshhold, 0f, Mathf.Abs(velocity.y));
            fallSpeed = Mathf.Lerp(minFallSpeed, maxFallSpeed, apexPoint);
        }
    }


    void CalculateJump()
    {
        coyoteTimer -= Time.deltaTime;

        if (collisionDown)
        {
            coyoteTimer = coyoteTime;
        }
        else if (coyoteTimer < 0)
        {
            canJumpCoyote = false;
        }

        bool triggerDefault = (collisionDown && _input.jumpPress);
        bool triggerCoyote = useCoyoteTime && canJumpCoyote && _input.jumpPress && !collisionDown;

        if (triggerDefault || triggerCoyote)
        {
            jumpCanceled = false;
            canJumpCoyote = false;
            coyoteTimer = 0;
            moveVertical = jumpForce;
            //Jump Event?
        }

        if (!collisionDown && _input.jumpRelease && velocity.y > 0 && !jumpCanceled)
        {
            jumpCanceled = true;
        }

        //Om spelaren slår i taket, sätt vertikal hastighet till noll.
        //Kräver kollisionscheck uppåt
        //if (collisionUp && moveVertical > 0) moveVertical = 0; 


    }

    #endregion
    **/
    #region Perform Movement

    void PerformMovement()
    {
        Vector3 finalMove = new Vector3(moveHorizontal.x, moveVertical, moveHorizontal.z);
        stateMachine.MovePlayer(finalMove.normalized, finalMove.magnitude);
    }

    #endregion

    #region Calculate Legacy Movement
    /*
    [Header("Legacy Movement")]

    private float turnSmoothVelocity;

    [Tooltip("Time for the controller to interpolate rotation in movement")] public float turnSmoothTime = 0.1f;
    [Tooltip("The normal walking speed")]public float speed = 6;

    [Tooltip("The speed modifier when sprinting")]public float sprintModifier = 2;

    void CalculateLegacy()
    {
        Vector3 direction = new Vector3(_input.x, 0f, _input.y);
        
        //Vector3 direction = new Vector3(stateMachine.ReturnMovement().x, 0f, stateMachine.ReturnMovement().y);

        //Execute Walk

        if (direction.magnitude >= 0.1f)
        {


            //To be discussed
            //if (direction.magnitude > 1) direction = direction.normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + stateMachine.cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(stateMachine.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            stateMachine.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //moveDir.Normalize();


            //Input for sprint 
            if (_input.sprintHold) moveDir *= sprintModifier;
            stateMachine.MovePlayer(moveDir, speed * direction.magnitude);
        }


        if (doGravity) CalculateLegacyGravity();

    }

    void CalculateLegacyGravity()
    {
        if (stateMachine.isGrounded && velocity.y <= 0)
        {
            velocity.y = 0;
            stateMachine.actionAllowed = true;
        }

        //Apply gravity if not on ground
        if (!stateMachine.isGrounded)
        {

            velocity.y += gravityConstant * Time.deltaTime;

            if (velocity.y < fallClamp)
            {
                velocity.y = fallClamp;
            }

        }

        stateMachine.controller.Move(velocity * Time.deltaTime);
    }
    
    */
    #endregion

    #region Generate Audiovisuals

    [Header("Audiovisuals")]

    [Tooltip("The smallest magnitude of the players horizontal movement that should qualify for audiovisual effects")]public float walkingThreshhold = 0.3f;
    [Tooltip("The particle systems that should be active when the player walks")]public List<ParticleSystem> particleSystems = new List<ParticleSystem>();
    private float lastMagnitude = 0;
    void GenerateAV()
    {
        if (moveHorizontal.magnitude > walkingThreshhold && lastMagnitude <= walkingThreshhold)
        {
            foreach(ParticleSystem particleSystem in particleSystems)
            {
                particleSystem.Play();
            }
        }
        else if (moveHorizontal.magnitude <= walkingThreshhold && lastMagnitude >= walkingThreshhold)
        {
            foreach (ParticleSystem particleSystem in particleSystems)
            {
                particleSystem.Stop();
            }
        }
        lastMagnitude = moveHorizontal.magnitude;

    }

    public GameObject footprintDecal;
    public Transform rightFoot;
    public Transform leftFoot;

    public void FootPrint(bool right)
    {
        Vector3 playerRot = stateMachine.transform.rotation.eulerAngles;
        if (right)
        {
            GameObject.Instantiate(footprintDecal, rightFoot.position, Quaternion.Euler(90, 180 + playerRot.y, 0));
        }
        else
        {
            GameObject.Instantiate(footprintDecal, leftFoot.position, Quaternion.Euler(90, 180 + playerRot.y, 0));
        }

    }

    #endregion

    #region Update Animator

    private void UpdateAnimator()
    {
        stateMachine.animator.SetFloat("Horizontal", moveHorizontal.magnitude);
    }

    #endregion
}
