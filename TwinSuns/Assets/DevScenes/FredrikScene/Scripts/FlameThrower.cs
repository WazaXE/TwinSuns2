using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody rb;

    private Transform playerTransform;

    [SerializeField] private DamageType damageType = DamageType.Fire;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        // Calculate the direction from the boss to the player
        Vector3 direction = (playerTransform.position - transform.position);
        transform.forward = direction;
    }



    private void OnTriggerEnter(Collider other)
    {

        IPlayerDamageable playerDamageable = other.GetComponent<IPlayerDamageable>();
        if (playerDamageable != null)
        {
            playerDamageable.TakeDamage();
            // Destroy the fireball upon collision with the player
            Destroy(gameObject);
        }
    }

}
