using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{

    [SerializeField]
    private InputAction action;
    /*[SerializeField]
    private CinemachineVirtualCamera vcam1;
    [SerializeField]
    private CinemachineVirtualCamera vcam2;*/


    private Animator animator;


    private bool topdown = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }


    void Start()
    {
        action.performed += ctx => SwitchState();
    }

    private void SwitchState()
    {
        if(topdown)
        {
            animator.Play("OverShoulderCamera");
        }
        else
        {
            animator.Play("TopDownCamera");
        }
        topdown = !topdown;
    }

    /*private void SwitchPriority()
    {
        if(topdown)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
        topdown = !topdown;
    }*/

}
