using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform point0, point1, point2, point3;
    public Transform point4;

    public Vector3 GetPoint(float t)
    {
        // Define the parameter ranges for each segment
        if (t <= 0.25f)
        {
            // First segment (straight line)
            return Vector3.Lerp(point0.position, point1.position, t / 0.25f);
        }
        else if (t <= 0.75f)
        {
            // Second segment (Bezier curve)
            float bezierT = (t - 0.25f) / 0.5f;
            return GetBezierPoint(point1.position, point2.position, point3.position, bezierT);
        }
        else
        {
            // Third segment (straight line)
            return Vector3.Lerp(point3.position, point4.position, (t - 0.75f) / 0.25f);
        }
    }

    private Vector3 GetBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0; // first term
        p += 2 * u * t * p1; // second term
        p += tt * p2; // third term

        return p;
    }

    private void OnDrawGizmos()
    {
        // Draw the path in the editor
        Gizmos.color = Color.green;
        Vector3 previousPoint = point0.position;
        for (int i = 1; i <= 50; i++)
        {
            float t = i / 50f;
            Vector3 point = GetPoint(t);
            Gizmos.DrawLine(previousPoint, point);
            previousPoint = point;
        }
    }

    public void RandomizeSecondAndThirdPoints()
    {
        float xDistance = 6.0f;
        float zDistance = 50.0f;

        point2.position = point1.position + new Vector3(Random.Range(-xDistance, xDistance), 0, Random.Range(-zDistance, zDistance));
        point3.position = point2.position + new Vector3(xDistance, 0, zDistance);
    }
}
