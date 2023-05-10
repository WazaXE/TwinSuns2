using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyPlank : MonoBehaviour, IDamageable
{

    [SerializeField] private GameObject fire;
    [SerializeField] private UnityEvent fireHit;
    [SerializeField] private UnityEvent notFireHit;
    [SerializeField] private UnityEvent plankBreak;

    public void TakeDamage(int damage, DamageType dType = DamageType.Normal)
    {
        PlankHit(dType);
    }

    private void PlankHit(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Normal:
                notFireHit?.Invoke();
                break;
            case DamageType.Fire:
                fireHit?.Invoke();
                if (fire) fire.SetActive(true);
                StartCoroutine(PlankDestroy());
                break;
        }
    }

    IEnumerator PlankDestroy()
    {
        yield return new WaitForSeconds(2f);

        plankBreak?.Invoke();
        Destroy(this.gameObject);
    }

}
