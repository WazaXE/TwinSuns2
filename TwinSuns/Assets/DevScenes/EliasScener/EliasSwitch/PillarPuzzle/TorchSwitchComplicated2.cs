using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwitchComplicated2 : MonoBehaviour, IDamageable
{

    [SerializeField]
    private Animator pillar1;

    [SerializeField]
    private Animator pillar2;

    [SerializeField]
    private GameObject fire;

    [SerializeField] private bool litOrNot = true;

    private void Awake()
    {
        fire.SetActive(litOrNot);

        if(litOrNot)
        {
            pillar1.SetBool("out", true);
            pillar2.SetBool("out", true);
        } else
        {
            pillar1.SetBool("out", false);
            pillar2.SetBool("out", false);
        }

    }


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
        pillar1.SetBool("out", !pillar1.GetBool("out"));
        pillar2.SetBool("out", !pillar2.GetBool("out"));

    }


}
