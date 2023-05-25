using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firePoint;
    private Transform playerTransform;

    [SerializeField] private float coolDown;

    private float mark;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float elapsedTime = Time.time - mark;

        // Check if the RT button is pressed
        if (elapsedTime > coolDown)
        {
            ShootFireball();
            mark = Time.time;
            elapsedTime = 0;
        }
    }

    private void ShootFireball()
    {
        // Calculate the direction from the boss to the player
        Vector3 direction = (playerTransform.position - firePoint.position).normalized;

        // Instantiate the fireball at the fire point's position and rotation
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // Get the Fireball script component from the fireball object
        Fireball fireballScript = fireball.GetComponent<Fireball>();

        // Check if the fireball script exists
        if (fireballScript != null)
        {
            // Set the direction for the fireball
            fireballScript.SetDirection(direction);

            // Call any necessary methods on the fireball script
            fireballScript.Launch();
        }
    }
}
