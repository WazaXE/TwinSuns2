using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using FMOD.Studio;
using FMODUnity;

public class ActivateTemple : MonoBehaviour, IDamageable
{
    public GameObject AmbianceTemple;


    [SerializeField]
    private Animator door1;

    [SerializeField]
    private Animator door2;

    [SerializeField]
    private GameObject fire;

    public UnityEvent fireLit;

    [SerializeField]
    private TMP_Text displayText;

    [SerializeField] private TMP_Text subTitle;

    [SerializeField]
    private float timeBeforeText = 1f;
    [SerializeField]
    private float timeToRemoveText = 2f;
    [SerializeField]
    private float timeToOpenDoors = 2f;


    public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den g� s�nder direkt �nd�
    {
        TorchHit(dType);
    }

    private void Start()
{
    displayText.enabled = false;
    subTitle.enabled = false;
}

    private void TorchHit(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Normal:
                break;
            case DamageType.Fire:
                Invoke("OpenDoors", timeToOpenDoors);
                Invoke("DisplayTextRoutine", timeBeforeText);
                fire.SetActive(true);
                fireLit?.Invoke();
               
                //här får ni lägga in något coolt med cameran och ljuset!


                break;
        }

    }


    private void DisplayTextRoutine()
{
    displayText.enabled = true;
    subTitle.enabled = true;
    Invoke("RemoveText", timeToRemoveText);

}

  private void RemoveText()
  {
    displayText.enabled = false;
    subTitle.enabled = false;
  }

    private void OpenDoors()
    {
      door1.SetBool("IsUp", true);
      door2.SetBool("IsUp", true);
    }


}
