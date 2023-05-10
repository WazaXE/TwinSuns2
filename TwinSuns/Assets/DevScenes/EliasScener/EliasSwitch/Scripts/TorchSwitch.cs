using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwitch: MonoBehaviour, IDamageable
{

    [SerializeField]
    private Animator door;

    [SerializeField]
    private GameObject fire;

    private bool litOrNot;

    private bool openOrNot = true;


  public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den g� s�nder direkt �nd�
{
    TorchHit();
}

private void TorchHit()
{
    litOrNot =! litOrNot;
    openOrNot = !openOrNot;
    door.SetBool("open", openOrNot);
    fire.SetActive(litOrNot);
}


}
