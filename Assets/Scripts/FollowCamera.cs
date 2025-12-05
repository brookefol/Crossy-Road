using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;    // Your Fox object
    public Vector3 offset;      // Camera offset from Fox
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Optional: keep camera looking at the target
        transform.LookAt(target);
    }
}