using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    [SerializeField] bool onlyOnce = false;
    private int i = 0;

    public UnityEvent triggerBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (onlyOnce && i >= 1) return;
            i++;
            triggerBox?.Invoke();
        }
    }



}
