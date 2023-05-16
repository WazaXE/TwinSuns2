using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalStairs : MonoBehaviour, IDamageable
{

    [SerializeField]
    private Animator stairs;


    [SerializeField]
    private GameObject fire;

    private bool litOrNot = false;

    public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den g� s�nder direkt �nd�
    {
        TorchHit(dType);
    }

    private void TorchHit(DamageType damageType)
    {
        switch(damageType)
        {
            case DamageType.Normal:
                if (litOrNot == false) return;
                litOrNot = false;
                break;
            case DamageType.Fire:
                if (litOrNot == true) return;
                litOrNot = true;

                break;
        }
        fire.SetActive(litOrNot);
        stairs.SetBool("up", !stairs.GetBool("up"));

    }


}
