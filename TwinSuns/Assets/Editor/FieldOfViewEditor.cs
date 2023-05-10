using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Alert))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        Alert alert = (Alert)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(alert.transform.position, Vector3.up, Vector3.forward, 360, alert.viewRadius);

        Vector3 viewAngleLeft = DirectionFromAngle(alert.transform.eulerAngles.y, -alert.viewAngle / 2);
        Vector3 viewAngleRight = DirectionFromAngle(alert.transform.eulerAngles.y, alert.viewAngle / 2);

        Handles.color = Color.white;
        Handles.DrawLine(alert.transform.position, alert.transform.position + viewAngleLeft * alert.viewRadius);
        Handles.DrawLine(alert.transform.position, alert.transform.position + viewAngleRight * alert.viewRadius);

        if (alert.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(alert.transform.position, alert.playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
