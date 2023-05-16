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
            mark = Time.time;
            isActive = true;
            nimTextBox.text = nimThoughtText;
            thoughtBubble.SetActive(true);
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
