using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void TakeDamage(int damageAmount, DamageType dtype = DamageType.Normal);

}
public enum DamageType{
    Normal,
    Fire,
    Water,
    Wind,
    Earth
}
