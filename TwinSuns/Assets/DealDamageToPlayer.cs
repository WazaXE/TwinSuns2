using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        IPlayerDamageable hit = other.GetComponent<IPlayerDamageable>();

        if (hit != null)
        {
            hit.TakeDamage();
        }
    }

}
