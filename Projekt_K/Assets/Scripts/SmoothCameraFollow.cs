using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 CameraOffset;
    public float followSpeed = 10f;
    public float xMin = 0f;
    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        Vector3 targetPos = target.position + CameraOffset;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followSpeed * Time.fixedDeltaTime);

        transform.position = smoothPos;
    }
}
