using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private DamageType damageType = DamageType.Fire;

    private Vector3 direction;
    private Rigidbody rb;
    public EventReference fireballsound;
    public EventInstance fireballInstance;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fireballInstance = FMODUnity.RuntimeManager.CreateInstance(fireballsound);
        fireballInstance.start();
        fireballInstance.release();
    }

    public void Launch()
    {
        rb.velocity = transform.forward * speed;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = (dir + Vector3.up * 0.05f).normalized;
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
        int layerMask = LayerMask.GetMask("Enviroment"); // Set the layer mask to the "Environment" layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, speed * Time.deltaTime, layerMask))
        {
            // Check if the raycast hit an object on the "Environment" layer
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enviroment"))
            {
                Debug.Log("Collided with Environment");
                // Destroy the fireball upon collision with any object
                Destroy(gameObject);
            }
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
