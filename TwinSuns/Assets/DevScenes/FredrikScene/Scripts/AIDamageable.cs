using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamageable : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount, DamageType dtype = DamageType.Normal)
    {
        // You can add additional logic here to handle different damage types
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement logic for AI death
        Destroy(gameObject);
    }
}
