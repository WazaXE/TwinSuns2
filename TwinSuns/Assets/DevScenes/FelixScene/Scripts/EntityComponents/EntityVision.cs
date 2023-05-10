using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SphereCollider))]
public class EntityVision : MonoBehaviour
{
    float range = 1f;
    public Transform center;

    private void OnValidate()
    {
        if (range < 0)
        {
            range = 0;
            Debug.LogWarning("EntityVision: Vision range cannot be negative.");
        }

        if (center == null)
        {
            center = gameObject.transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
    }

    public bool InRange(Vector3 _object)
    {
        return Vector3.Magnitude(_object - center.position) <= range;
    }

}
