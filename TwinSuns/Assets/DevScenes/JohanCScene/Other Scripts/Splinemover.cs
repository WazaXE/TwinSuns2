using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splinemover : MonoBehaviour
{
    public Spline spline;
    public Transform followObj;

    private Transform thisTransform;


    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.position = spline.WhereOnSpline(followObj.position);
    }
}
