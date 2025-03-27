using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVVisualizer : MonoBehaviour
{
    public float vieWAngle = 60f;

    public float viewDistance = 5f;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 foward = transform.forward * viewDistance;

        Vector3 leftBoundary = Quaternion.Euler(0, -vieWAngle / 2, 0) * foward;

        Vector3 rightBoundary = Quaternion.Euler(0, vieWAngle / 2, 0) * foward;


        Gizmos.DrawRay(transform.position, leftBoundary);
        Gizmos.DrawRay(transform.position, rightBoundary);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, foward);

    }
}
