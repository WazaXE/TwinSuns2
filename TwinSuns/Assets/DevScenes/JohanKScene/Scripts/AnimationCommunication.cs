using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AnimationCommunication : MonoBehaviour
{

    public UnityEvent startWeaponAttackEvent;
    public UnityEvent stopWeaponAttackEvent;
    public UnityEvent rightFootPrint;
    public UnityEvent leftFootPrint;
    public UnityEvent attackEnd;
    public UnityEvent attackChainAllowed;

    public void StartWeaponAttack()
    {
        startWeaponAttackEvent?.Invoke();
    }

    public void StopWeaponAttack()
    {
        stopWeaponAttackEvent?.Invoke();
    }

    public void RightFootPrint()
    {
        rightFootPrint?.Invoke();
    }

    public void LeftFootPrint()
    {
        leftFootPrint?.Invoke();
    }

    public void AttackEnd()
    {
        attackEnd?.Invoke();
    }
    public void AttackChainAllowed()
    {
        attackChainAllowed?.Invoke();
    }

}
