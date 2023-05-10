using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] private TextMeshPro barkText;
    [SerializeField] private List<string> barkTexts;

    [Header("Trigger Settings")]
    [SerializeField] private bool random;
    [SerializeField] private bool timedBarks;
    [SerializeField] private float timeBetweenBarks;

    private bool isActive;
    private float mark;

    [Header("Lock Rotation")]
    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;

    private Vector3 originalRotation;

    private int index = 0;


    private void Awake()
    {
        originalRotation = transform.rotation.eulerAngles;
    }

    private void OnEnable()
    {

        if (barkTexts.Count > 0)
        {
            if (timedBarks)
            {
                mark = Time.time;
                isActive = true;
                index = 0;

                if (random)
                {
                    DisplayRandomBark();
                }
                else if (!random)
                {
                    DisplayBark(index);
                }

            }

            if (!timedBarks)
            {
                if (index >= barkTexts.Count)
                {
                    index = 0;
                }

                if (random)
                {
                    DisplayRandomBark();
                }
                else if (!random)
                {
                    DisplayBark(index);

                    index++;
                }
            }
        }

    }

    private void Update()
    {
        if(isActive && timedBarks)
        {

            float elapsedTime = Time.time - mark;

            if (elapsedTime > timeBetweenBarks  && !random)
            {
                index++;
                DisplayBark(index);
                mark = Time.time;
            } else if (elapsedTime > timeBetweenBarks && random)
            {
                DisplayRandomBark();
                mark = Time.time;
            }

        } 
    }

    private void DisplayBark(int i)
    {
        barkText.text = barkTexts[i];
    }

    private void DisplayRandomBark()
    {
        barkText.text = barkTexts[Random.Range(0, barkTexts.Count)];
    }

    private void OnDisable()
    {
        isActive = false;
    }


    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        //Modify rotation to lock dimensions
        Vector3 rotation = transform.rotation.eulerAngles;
        if (lockX) { rotation.x = originalRotation.x; }
        if (lockY) { rotation.y = originalRotation.y; }
        if (lockZ) { rotation.z = originalRotation.z; }
        transform.rotation = Quaternion.Euler(rotation);
    }
}
