using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Splines;

public class CameraSplineFollower : MonoBehaviour
{
    public SplineAnimate splineAnimate;  // Drag the Cube's SplineAnimate here

    void LateUpdate()
    {
        if (splineAnimate == null) return;

        // Get SplineContainer from SplineAnimate
        SplineContainer splineContainer = splineAnimate.Container;
        if (splineContainer == null) return;

        // Get current progress along the spline (0 to 1)
        float progress = splineAnimate.NormalizedTime;

        // Get position and tangent at current progress
        Vector3 position = (Vector3)splineContainer.Spline.EvaluatePosition(progress);
        Vector3 tangent = math.normalize((Vector3)splineContainer.Spline.EvaluateTangent(progress));

        // Move the camera to the current spline position
        transform.position = position;

        // Make the camera face the movement direction (tangent)
        if (tangent != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(tangent, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
