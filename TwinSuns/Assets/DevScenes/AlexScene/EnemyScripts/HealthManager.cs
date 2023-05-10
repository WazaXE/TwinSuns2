using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable] public class EventTest : UnityEvent { }

public class HealthManager : MonoBehaviour, IDamageable
{
    [HideInInspector] public ChasePlayer chasePlayer;
    [SerializeField]
    private int lives = 1;
    public int enemyLives => lives;

    public EventTest damageTaken;

    public EventTest dead;
    void Start()
    {
        chasePlayer = GetComponent<ChasePlayer>();
    }
    void Update()
    {
        if (enemyLives < 5)
        {
            damageTaken?.Invoke();
        }
        if(enemyLives <= 0)
        {
            dead?.Invoke();
        }
    }

    public void TakeDamage(int amount, DamageType dType = DamageType.Normal)
    {
        damageTaken?.Invoke();
        lives =- amount;
    }
}