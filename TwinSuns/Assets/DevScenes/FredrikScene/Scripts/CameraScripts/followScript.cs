using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .03f);
    }
}
