using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class StateMachine : MonoBehaviour
{
    //InputActions public för att kunna läsas av alla tillstånd
    public PlayerInput Inputs;
    [HideInInspector] public InputAction move;
    [HideInInspector] public InputAction attack;
    [HideInInspector] public InputAction dash;
    [HideInInspector] public InputAction interact;
    [HideInInspector] public InputAction enchant;
    //[HideInInspector] public InputAction jump;
    [HideInInspector] public InputAction sprint;

    [SerializeField] public CharacterController controller;

    [SerializeField] public Transform cam; //Behöver eventuellt vara i StateMachine sen
    public Animator animator;

    [HideInInspector]
    public WeaponHandler weaponHandler;
    [HideInInspector]
    public bool inCombat = false;

    //Johans SKIT
    //public List<IInteractable> interactables = new List<IInteractable>();
    [HideInInspector]
    public List<GameObject> interactables = new List<GameObject>(); //Listan med interactables som ska kommas åt och hanteras av "interaction"
    public Interaction playerInteraction;

    //Instantiate varje state
    public FreeState freeState = new FreeState();
    public DashState dashState = new DashState();
    public CombatState combatState = new CombatState();
    public AttackState attackState = new AttackState();
    //public JumpState jumpState = new JumpState();
    public InteractState interactState = new InteractState();
    public EnchantState enchantState = new EnchantState();

    private PlayerState currentState = null;

    //Player Movement Script

    [SerializeField] public PlayerMovement playerMovement = new PlayerMovement();

    //Input buffer variables

    [HideInInspector] public List<ActionItem> inputBuffer = new List<ActionItem>();
    public BackendSettingsObject backendSettings;

    //public List<ActionItem> inputBuffer = new List<ActionItem>(); //Input buffer
    //private ActionItem actionItem;

    [HideInInspector]   public bool actionAllowed = true; //Set to true whenever we want to process from input buffer, set to false whenever an action has to wait in buffer

    [HideInInspector]   public bool isGrounded;

    [HideInInspector]   public bool mayDash = true;

    [HideInInspector] public bool mayEnchant = true;

    //public float gravity = -10f;

    //public float maxFallspeed = -40;


    [Header("Ground check things")]
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.1f;



    public void OnValidate()
    {


        //Onvalidate alla scripts
        freeState.OnValidate(this);
        dashState.OnValidate(this);
        combatState.OnValidate(this);
        attackState.OnValidate(this);
        //jumpState.OnValidate(this);
        interactState.OnValidate(this);
        enchantState.OnValidate(this);

        playerMovement.OnValidate(this);
    }

    public void Awake()
    {
        playerInteraction = GetComponentInChildren<Interaction>();
        weaponHandler = GetComponent<WeaponHandler>();



        if (cam == null)
        {
            cam = Camera.main.transform;
        }



        //Awake på alla states
        freeState.Awake();
        dashState.Awake();
        combatState.Awake();
        attackState.Awake();
        //jumpState.Awake();
        interactState.Awake();
        enchantState.Awake();
        //audioManTwin = GameObject.Find("AudioManTwin").GetComponent<AudioManTwin>();

        //OnValidate runnar ej i build, och måste därför stå med här
        freeState.OnValidate(this);
        dashState.OnValidate(this);
        attackState.OnValidate(this);
        //jumpState.OnValidate(this);
        interactState.OnValidate(this);
        enchantState.OnValidate(this);

        playerMovement.OnValidate(this);



        Inputs = new PlayerInput();
        //https://www.youtube.com/watch?v=HmXU4dZbaMw&ab_channel=BMo
        //Video for new input, look at to fix movement
    }

    public void Start()
    {
        //Starta alla states
        freeState.Start();
        dashState.Start();
        combatState.Start();
        attackState.Start();
        //jumpState.Start();
        interactState.Start();
        enchantState.Start();


        //Set state to start-state and enter
        currentState = freeState;
        currentState.Enter();

    }

    public void Transit(PlayerState playerState)
    {
        currentState.Exit();
        currentState = playerState;
        currentState.Enter();

    }

    public void Update()
    {

        currentState.Update();
    }
    public void FixedUpdate()
    {
        currentState.FixedUpdate();
        playerMovement.Calculate(currentState.listenToInput, currentState.doGravity);

        //check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    public void MovePlayer(Vector3 direction, float speed)
    {
        controller.Move(direction * speed * Time.fixedDeltaTime);
    }

    public IEnumerator DashCooldown(float seconds)
    {
        mayDash = false;
        yield return new WaitForSeconds(seconds);
        mayDash = true;
    }
    public IEnumerator EnchantCooldown(float seconds)
    {
        mayEnchant = false;
        yield return new WaitForSeconds(seconds);
        mayEnchant |= true;
    }

    public ActionItem CheckBuffer(int startIndex)
    {
        if (startIndex >= inputBuffer.Count) return null;
        List<ActionItem> expiredActions = new List<ActionItem>();
        for(int i = startIndex; i < inputBuffer.Count; i++)
        {
            ActionItem action = inputBuffer[i];
            if (action.CheckIfValid(backendSettings.buffering))
            {
                CleanBuffer(expiredActions);
                return action;
            }
            else expiredActions.Add(action);
        }
        CleanBuffer(expiredActions);
        return null;
    }

    private void CleanBuffer(List<ActionItem> expiredActions)
    {
        foreach(ActionItem expiredAction in expiredActions)
        {
            inputBuffer.Remove(expiredAction);
        }
    }

    public void ConsumeAction(ActionItem action)
    {
        inputBuffer.Remove(action);
    }

    /*
    private void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        Debug.Log(value);
    }
    */


    //public void TryBufferedAction()
    //{
    //    if (actionItem != null)
    //    {
    //        if (isGrounded)
    //        {
    //            if (actionItem.CheckIfValid())
    //            {
    //                DoAction(actionItem);
    //                actionItem = null;
    //            }
    //        }

    //    }

    //    /*
    //    if (inputBuffer.Count > 0)
    //    {
    //        //foreach (ActionItem ai in inputBuffer.ToArray()) // ToArray is used to iterate on the actual list
    //        //{
    //        //    inputBuffer.Remove(ai); //Remove element from buffer

    //        //    if (ai.CheckIfValid())
    //        //    {
    //        //        //If the action is within the allowed buffer time
    //        //        DoAction(ai);
    //        //        break; //This makes sure only one element is processed from the inputBuffer
    //        //    }

    //        //}

    //        actionItem = inputBuffer[inputBuffer.Count -1];

    //        inputBuffer.Clear();

    //        if (actionItem.CheckIfValid())
    //        {
    //            Debug.Log("if");
    //            DoAction(actionItem);
    //            actionItem = null;
    //        }

    //    }
    //    else if (actionItem != null)
    //    {
    //        Debug.Log("else if");
    //        if (actionItem.CheckIfValid())
    //        {
    //            DoAction(actionItem);
    //            actionItem = null;
    //        }        
    //    }
    //    */
    //}

    //private void DoAction(ActionItem ai)
    //{

    //    switch (ai.Action)
    //    {
    //        /**
    //        case ActionItem.InputAction.Jump:
    //            Transit(jumpState);
    //            break;
    //        **/

    //        case ActionItem.InputAction.Attack:
    //            Transit(attackState);
    //            break;
    //        case ActionItem.InputAction.Dash:
    //            Transit(dashState);
    //            break;
    //        default:
    //            Transit(freeState);
    //            break;

    //    }
    //    actionAllowed = false; // Needs to be set to true somewhere
    //}
    


    public void OnEnable()
    {
        move = Inputs.Player.Move;
        move.Enable();

        attack = Inputs.Player.Attack;
        attack.Enable();
        attack.performed += Attack;

        
        dash = Inputs.Player.Dash;
        dash.Enable();
        dash.performed += Dash;

        interact = Inputs.Player.Interact;
        interact.Enable();
        interact.performed += Interact;

        enchant = Inputs.Player.Enchant;
        enchant.Enable();
        enchant.performed += Enchant;

        /**
        jump = Inputs.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
        **/
        sprint = Inputs.Player.Sprint;
        sprint.Enable();    

    }

    public void OnDisable()
    {
        move.Disable();

        attack.Disable();
        attack.performed -= Attack;

        dash.Disable();
        dash.performed -= Dash;

        interact.Disable();
        interact.performed -= Interact;

        //jump.Disable();
        sprint.Disable();
    }

    private void Attack(InputAction.CallbackContext context)
    {
        inputBuffer.Add(new ActionItem(ActionItem.InputAction.Attack, Time.time));

    }

    private void Dash(InputAction.CallbackContext context)
    {
        inputBuffer.Add(new ActionItem(ActionItem.InputAction.Dash, Time.time));

    }
    /*
    private void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed dash");

        Debug.Log("Dashing!");
        //inputBuffer.Add(new ActionItem(ActionItem.InputAction.Dash, Time.time));
        actionItem = new ActionItem(ActionItem.InputAction.Dash, Time.time);
    }
    */
    private void Interact(InputAction.CallbackContext context)
    {
        inputBuffer.Add(new ActionItem(ActionItem.InputAction.Interact, Time.time));
    }

    private void Enchant(InputAction.CallbackContext context)
    {
        inputBuffer.Add(new ActionItem(ActionItem.InputAction.Enchant, Time.time));
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed jump");

        Debug.Log("Jumping");
        //inputBuffer.Add(new ActionItem(ActionItem.InputAction.Jump, Time.time));

        //audioManTwin.playerAudio.PlayerJumpAudio(controller.gameObject);
        

    }
    private AudioManTwin audioManTwin;

    public void RightFootPrint()
    {
        playerMovement.FootPrint(true);
    }

    public void LeftFootPrint()
    {
        playerMovement.FootPrint(false);
    }

    public void OnAttackEnd()
    {
        attackState.OnAttackEnd();
    }
    public void OnAttackChainAllowed()
    {
        attackState.OnAttackChainAllowed();
    }

}
