using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyNormalHit : MonoBehaviour, IDamageable
{


    [SerializeField] private UnityEvent fireHit;
    [SerializeField] private UnityEvent notFireHit;
    [SerializeField] private UnityEvent plankBreak;

    public void TakeDamage(int damage, DamageType dType = DamageType.Normal)
    {
        Hit(dType);
    }

    private void Hit(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Normal:
                notFireHit?.Invoke();
                StartCoroutine(Destroy());
                break;
            case DamageType.Fire:
                fireHit?.Invoke();
                StartCoroutine(Destroy());
                break;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);


        Destroy(this.gameObject);
    }




}