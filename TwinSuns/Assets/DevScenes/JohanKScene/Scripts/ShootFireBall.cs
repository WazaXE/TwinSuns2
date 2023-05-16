using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireBall : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        // Check if the RT button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            ShootFireball();
        }
    }

    private void ShootFireball()
    {
        // Instantiate the fireball at the fire point's position and rotation
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);

        // Get the Fireball script component from the fireball object
        Fireball fireballScript = fireball.GetComponent<Fireball>();

        // Check if the fireball script exists
        if (fireballScript != null)
        {
            // Call any necessary methods on the fireball script
            fireballScript.Launch();
        }
    }
}
