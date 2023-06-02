using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private DashCooldownUI dashCooldownUI;
    [SerializeField] private StateMachine playerStateMachine;

    private void Start()
    {
        // Subscribe to the OnEnterDashState event
        playerStateMachine.dashState.OnEnterDashState += HandleEnterDashState;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnCooldownPercentageChanged event
        playerStateMachine.dashState.OnEnterDashState -= HandleEnterDashState;
    }

    private void HandleEnterDashState(float dashCooldown)
    {
        dashCooldownUI.StartLerpAlpha(dashCooldown);
    }
}
