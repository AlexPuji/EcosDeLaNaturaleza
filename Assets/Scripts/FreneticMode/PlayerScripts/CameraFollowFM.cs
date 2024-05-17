using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFM : MonoBehaviour
{
    private Transform target; // Referencia al jugador
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        if (target == null)
        {
            // Si no se ha encontrado al jugador, intenta buscarlo nuevamente
            FindPlayer();
        }
        else
        {
            Vector3 desiredPosition = target.position;
            desiredPosition.z = transform.position.z;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    private void FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
    }
}
