using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // Reference to the character's Transform
    public float smoothSpeed = 0.125f; // The smoothness of camera movement
    public Vector3 offset; // The offset from the character

    void LateUpdate()
    {
        if (target == null)
        {
            // If the target is not set, do nothing
            return;
        }

        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z; // Maintain the camera's original z position

        // Use Mathf.SmoothDamp to smoothly interpolate the camera's position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
