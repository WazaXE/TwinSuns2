using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTemple : MonoBehaviour, IDamageable
{

    [SerializeField]
    private Animator door1;

    [SerializeField]
    private Animator door2;

    [SerializeField]
    private GameObject fire;


    public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den g� s�nder direkt �nd�
    {
        TorchHit(dType);
    }

    private void TorchHit(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Normal:
                break;
            case DamageType.Fire:
                door1.SetBool("IsUp", true);
                door2.SetBool("IsUp", true);
                fire.SetActive(true);
                //här får ni lägga in något coolt med cameran och ljuset!


                break;
        }

    }


}
