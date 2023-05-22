using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private Shader whiteShader;  // The shader to switch to when hit
    private Shader originalShader;  // The original shader of the enemy
    private Renderer enemyRenderer;  // Reference to the enemy's renderer component

    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    [SerializeField] private float durationOfHit = 1f;

    private void Start()
    {
        // Get the original shader from the renderer
        enemyRenderer = GetComponent<Renderer>();
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
        Destroy(gameObject);
    }
}
