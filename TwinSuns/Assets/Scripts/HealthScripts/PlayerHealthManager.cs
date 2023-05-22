using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthManager : MonoBehaviour, IPlayerDamageable
{

    public static event Action OnPlayerDamaged;

    public CheckPointHandler checkPointHandler;

    public float maxHealth;

    [HideInInspector]
    public float health;


    // Start is called before the first frame update
    private void Start()
    {
        //Set health to max health on game start
        health = maxHealth;

        //Invoke event to refresh health so that it displays correct
        OnPlayerDamaged?.Invoke();

        if (checkPointHandler == null) checkPointHandler = FindObjectOfType<CheckPointHandler>();
    }

    public void TakeDamage()
    {
        //Execute this code whenever player takes damage

        health -= 1;

        if (health <= 0) {
            health = maxHealth;
            CharacterController playerController = gameObject.GetComponent<CharacterController>();
            playerController.enabled = false;
            gameObject.transform.position = checkPointHandler.Respawnpoint.position;
            playerController.enabled = true;
        }
        OnPlayerDamaged?.Invoke();
    }

    public void RestoreHealth()
    {
        //Execute this code whenever player restores health

        health = maxHealth;
        OnPlayerDamaged?.Invoke();
    }

}
