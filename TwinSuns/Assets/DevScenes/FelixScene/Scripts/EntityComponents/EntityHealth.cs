using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{
    public UnityEvent OnEntityHealthOut;

    private int health;
    public int maxHealth;
    

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            if (health > 0 && value <= 0) OnEntityHealthOut.Invoke();

            health = Mathf.Clamp(value, 0, maxHealth);
        }
    }

}
