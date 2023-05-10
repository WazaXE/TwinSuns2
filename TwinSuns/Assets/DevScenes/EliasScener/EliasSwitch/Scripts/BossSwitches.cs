using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitches : MonoBehaviour, IDamageable
{

    [SerializeField]
    private Animator pillar1;

    [SerializeField]
    private GameObject fire;

    private bool litOrNot = false;

    private bool openOrNot = false;

    private float timeSinceLastHit;


    public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den g� s�nder direkt �nd�
    {
        TorchHit();
    }

    public void TorchHit()
    {
        litOrNot = !litOrNot;
        openOrNot = !openOrNot;
        fire.SetActive(litOrNot);
        pillar1.SetBool("out", !pillar1.GetBool("out"));

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" && fire.activeSelf == false && Time.time - timeSinceLastHit >= 1f)
        {
            TorchHit();

        }
    }


}
