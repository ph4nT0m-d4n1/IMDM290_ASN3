/*using UnityEngine;
using UnityEngine.Splines;

public class splineFollower : MonoBehaviour
{
    
    public SplineContainer splineContainer;
    public float speed = 1f;
    public float distanceTravelled = 0f;

    // Update is called once per frame
    void Update()
    {
        if (splineConatiner == null) return;
        if (distanceTravelled > 1f) prdistanceTravelledogress -= 1f;

        Spline spline = splineContainer.Spline;
        if (spline == null) return; 

        spline.Evaluate(distanceTravelled, out Vector3 position, out Vector3 tangent);

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(tangent);
    }
}
*/