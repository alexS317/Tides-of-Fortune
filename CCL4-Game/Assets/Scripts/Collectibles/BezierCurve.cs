using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField] private Transform[] controlPoints;

    private Vector3 _gizmoPosition; // Vector 3 for 3D curve

    // Make the curve visible in the scene (makes it a lot easier to set it by moving the control points)
    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            // Bezier curve formula for 4 control points
            _gizmoPosition = (Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                              3 * t * Mathf.Pow(1 - t, 2) * controlPoints[1].position +
                              3 * Mathf.Pow(t, 2) * (1 - t) * controlPoints[2].position +
                              Mathf.Pow(t, 3) * controlPoints[3].position);

            Gizmos.DrawSphere(_gizmoPosition, 0.25f);
        }
    }
}