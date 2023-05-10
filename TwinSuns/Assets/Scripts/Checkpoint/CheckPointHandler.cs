using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    [SerializeField]
    private int currentPointIndex = 0;
    [SerializeField]
    private Transform currentRespawnpoint;
    public Transform Respawnpoint => currentRespawnpoint;

    public CheckPointSingle[] CheckPoints;

    private void Start()
    {
        CheckPoints = gameObject.GetComponentsInChildren<CheckPointSingle>();

        //Prenumerera på Event samt sätta spawnpoint till första checkpoint
        if (CheckPoints.Length > 0)
        {
            currentRespawnpoint = CheckPoints[0].RespawnTransform;
            currentPointIndex = CheckPoints[0].PointIndex;

            foreach (CheckPointSingle cp in CheckPoints)
            {
                cp.pointCheck += NewCheckpoint;
            }



        }
        else //Just in case I guess
        {
            currentRespawnpoint = this.transform;
        }
    }

    private void NewCheckpoint(int pointIndex, Transform respawnPoint)
    {
        currentPointIndex = pointIndex;
        currentRespawnpoint = respawnPoint;

        foreach (CheckPointSingle cp in CheckPoints)
        {
            if (cp.PointIndex <= currentPointIndex) //<= så alla under samt den kolliderade avaktiveras
            {
                cp.gameObject.SetActive(false);
                cp.pointCheck -= NewCheckpoint;
            }

        }
    }

}
