using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private DamageType damageType = DamageType.Fire;

    private Vector3 direction;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch()
    {
        rb.velocity = transform.forward * speed;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        // Adjust the fireball's rotation to face the desired direction
        transform.forward = direction;
    }

    private void Update()
    {
        // Move the fireball in the Update method instead of using Rigidbody velocity

        // Calculate the new position
        Vector3 newPosition = transform.position + transform.forward * speed * Time.deltaTime;

        // Perform a raycast from the current position to the new position
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, speed * Time.deltaTime))
        {
            // Check if the raycast hit an object with the "Environment" tag
            if (hit.collider.CompareTag("Environment"))
            {
                Debug.Log("Collided with Environment");
            }

            // Destroy the fireball upon collision with any object
            Destroy(gameObject);
        }
        else
        {
            // Update the position if no collision occurred
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount, damageType);
            // Destroy the fireball upon collision with any object
            Destroy(gameObject);
        }

        IPlayerDamageable playerDamageable = other.GetComponent<IPlayerDamageable>();
        if (playerDamageable != null)
        {
            playerDamageable.TakeDamage();
            // Destroy the fireball upon collision with the player
            Destroy(gameObject);
        }
    }
}
