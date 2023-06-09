using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamageable : MonoBehaviour, IDamageable
{
    public int ID { get; set; }

    [SerializeField] private Shader whiteShader;  // The shader to switch to when hit
    private Shader originalShader;  // The original shader of the enemy
    [SerializeField] private Renderer enemyRenderer;  // Reference to the enemy's renderer component

    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    [SerializeField] private float durationOfHit = 1f;

    public static event Action<int> OnEnemyDeath;

    private void Start()
    {
        // Get the original shader from the renderer
        originalShader = enemyRenderer.material.shader;

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount, DamageType dtype = DamageType.Normal)
    {
        StartCoroutine(ChangeShaderForDuration(whiteShader, durationOfHit));  // Switch to white shader for 1 second
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator ChangeShaderForDuration(Shader newShader, float duration)
    {
        // Switch to the new shader
        enemyRenderer.material.shader = newShader;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Revert back to the original shader
        enemyRenderer.material.shader = originalShader;
    }

    private void Die()
    {
        OnEnemyDeath?.Invoke(ID);
        Destroy(gameObject);
    }
}
