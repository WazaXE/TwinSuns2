using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour
{


    [SerializeField] private float lifeTime = 1.0f;

    private float mark;

    // Start is called before the first frame update
    void Start()
    {
        mark = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - mark;

        if (elapsedTime > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
