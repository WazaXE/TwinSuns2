using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedObject : MonoBehaviour
{
    [SerializeField]
    private Debris[] debris;

    //Objektet och dess children borde tas bort av child
    public void Break(float delay, float fragScaleFactor)
    {
        if (debris.Length > 0)
        {
            foreach (Debris d in debris)
            {
                d.StartShrink(delay, fragScaleFactor);
            }
        }

    }

}
