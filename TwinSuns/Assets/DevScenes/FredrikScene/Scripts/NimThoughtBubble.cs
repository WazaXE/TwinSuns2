using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NimThoughtBubble : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] private TextMeshPro nimTextBox;
    [SerializeField] private GameObject thoughtBubble;
    [SerializeField] private string nimThoughtText;
    [SerializeField] private float timeUntilGone;
    [SerializeField] private bool oneShot;


    private bool firstTime = true;
    private bool isActive;
    private float mark;

    private void Awake()
    {
        thoughtBubble.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        IPlayerDamageable collided = other.GetComponent<IPlayerDamageable>();

        if (collided != null)
        {
            if ((oneShot && firstTime) || !oneShot)
            {
                mark = Time.time;
                isActive = true;
                nimTextBox.text = nimThoughtText;
                thoughtBubble.SetActive(true);
                firstTime = false;
            }

        }




    }


    private void Update()
    {


        if (isActive)
        {
            float elapsedTime = Time.time - mark;

            if (elapsedTime > timeUntilGone)
            {
                thoughtBubble.SetActive(false);
                isActive = false;
            }

        }
    }

}
