using UnityEngine;

public class FollowBezierCurve : MonoBehaviour
{
    public BezierCurve bezierCurve;
    public float duration = 5.0f; // Time taken to complete the path
    private float t = 0.0f;

    void Update()
    {
        // Update the parameter t based on the duration
        t += Time.deltaTime / duration;

        // Clamp t to the range [0, 1]
        t = Mathf.Clamp01(t);

        // Get the point on the Bezier curve at t
        Vector3 position = bezierCurve.GetPoint(t);

        // Update the object's position
        transform.position = position;

        // Optionally, reset t to 0 if you want the object to loop back to the start
        // if (t >= 1.0f)
        // {
        //     t = 0.0f;
        // }

        // Check for input to randomize the second and third points
        if (Input.GetKeyDown(KeyCode.O))
        {
            bezierCurve.RandomizeSecondAndThirdPoints();
            t = 0.0f; // Reset the path traversal
        }
    }
}
