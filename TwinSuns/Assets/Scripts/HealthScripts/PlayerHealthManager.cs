using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthManager : MonoBehaviour, IPlayerDamageable
{

    public static event Action OnPlayerDamaged;

    public float maxHealth;

    [HideInInspector]
    public float health;


    private void OnEnable()
    {
        //WellSave.OnPlayerRestore += RestoreHealth();
    }

    private void OnDisable()
    {
        //WellSave.OnPlayerRestore -= RestoreHealth();
    }


    // Start is called before the first frame update
    private void Start()
    {
        //Set health to max health on game start
        health = maxHealth;

        //Invoke event to refresh health so that it displays correct
        OnPlayerDamaged?.Invoke();
    }

    public void TakeDamage()
    {
        //Execute this code whenever player takes damage

        health -= 1;
        OnPlayerDamaged?.Invoke();
    }

    public void RestoreHealth()
    {
        //Execute this code whenever player restores health

        health = maxHealth;
    }

}
