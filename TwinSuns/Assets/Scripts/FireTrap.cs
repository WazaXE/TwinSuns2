using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    [SerializeField] private GameObject fire;

    [SerializeField] private float timeBetweenTrap = 1;

    private bool activeOrNot;


    void Start()
    {
        //Start first coroutine
        StartCoroutine(ShootFire());
    }


    IEnumerator ShootFire()
    {
        //Set float value to how long between the fire switches direction
        yield return new WaitForSeconds(timeBetweenTrap);

        activeOrNot = !activeOrNot;

        fire.SetActive(activeOrNot);

        //Repeat forever
        StartCoroutine(ShootFire());
    }


}
