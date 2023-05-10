using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniDoors : MonoBehaviour, IDamageable
{

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private Animator door;

    [SerializeField]
    private Collider switch1;

    Color lerpedColor = Color.white;

    private Color colorCheck;

    private Renderer switchRenderer;

    private int hit;

    private float elapsedTime;

    private float startTime;

    private Color newSwitchColor;



    private bool opening = false;

    private bool closing = false;

    void Start()
    {
        switchRenderer = GetComponent<Renderer>();
        colorCheck = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;
        if (hit > 0)
        {
            lerpedColor = Color.Lerp(newSwitchColor, Color.white, (elapsedTime - 2) / 2);
            switchRenderer.material.color = lerpedColor;
            if (opening == false)
            {
                door.SetBool("opening", true);
                
                opening = true;

            }
            if (lerpedColor.Equals(colorCheck) && hit > 0)
            {
                hit = 0;
                if (closing == false)
                {
                    door.SetBool("closing", true);
                    closing = true;
                    door.SetBool("opening", false);
                    opening = false;
                    switch1.enabled = false;
                }
            }
        }
    }

    public void TakeDamage(int damage, DamageType dType = DamageType.Normal) //I detta fall ska den g� s�nder direkt �nd�
    {
        if (dType != DamageType.Fire) return;
        ChangeSwitchColor();
        door.SetTrigger("opening");
        switch1.enabled = true;
    }

    private void ChangeSwitchColor()
    {
        startTime = Time.time;
        hit += 1;
        newSwitchColor = Color.red;
    }


}
