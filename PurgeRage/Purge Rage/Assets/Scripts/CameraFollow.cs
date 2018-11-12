using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //PUBLIC VARIABLES
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    //PRIVATE VARIABLES



    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
    }
}
