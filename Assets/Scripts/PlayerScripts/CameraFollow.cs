using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 

    
    public float smoothSpeed = 0.125f;

    
    void LateUpdate()
    {
        if (target != null)
        {
            
            Vector3 desiredPosition = target.position;
            desiredPosition.z = transform.position.z; 

            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
