using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    WeaponController weaponController;
    [SerializeField]
    private float attackCooldown = 1.0f;
    public float AttackCooldown => attackCooldown; //samma sak som: get { return attackCooldown

    private void Start()
    {
        weaponController = GetComponentInParent<WeaponController>();
    }


    public void DoDam()
    {
        weaponController.DoDam();
    }

    public void StartAttack()
    {

    }

    public void EndAttack()
    {

    }

}
