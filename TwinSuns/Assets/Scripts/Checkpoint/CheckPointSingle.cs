using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CheckPointSingle : MonoBehaviour
{
    [SerializeField]
    private Transform respawnTransform;
    public Transform RespawnTransform => respawnTransform;

    [SerializeField]
    private int pointIndex;
    public int PointIndex => pointIndex;

    public UnityAction<int, Transform> pointCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pointCheck.Invoke(pointIndex, RespawnTransform);  //?.Invoke borde inte behövas
        }
    }
}
