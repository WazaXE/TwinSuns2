using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyableCactus : MonoBehaviour, IDamageable
{
    public GameObject destroyedCactus;
    [SerializeField]
    private float shrinkDelay = 2f;
    [SerializeField]
    private float fragScaleFactor = 1f;
    public CactusDestroyed CactusDestroyedEvent;

    public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den gå sönder direkt ändå
    {
        BreakCactus();
    }

    private void BreakCactus()
    {
        if (destroyedCactus != null)
        {
            CactusDestroyedEvent?.Invoke();

            GameObject fractObj = Instantiate(destroyedCactus, transform.position, transform.rotation);

            FracturedObject fo = fractObj.GetComponent<FracturedObject>();
            fo.Break(shrinkDelay, fragScaleFactor);

            //foreach (Transform t in fractObj.transform)
            //{
            //    //StartCoroutine(t.GetComponent<Debris>().Shrink(shrinkDelay,fragScaleFactor)); //Går att starta härifrån, men när man tar bort detta objekt så slutar coroutinen köra
            //    t.GetComponent<Debris>().StartShrink(shrinkDelay,fragScaleFactor);
            //}


            Destroy(this.gameObject);
        }
        
    }
}

[Serializable] public class CactusDestroyed : UnityEvent { }