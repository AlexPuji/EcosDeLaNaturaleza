using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; // Referencia al jugador

    public float smoothSpeed = 0.125f;

    private void OnEnable()
    {
        // Busca automáticamente al jugador en la escena al activarse la cámara
        FindPlayer();
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position;
            desiredPosition.z = transform.position.z;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            // Si no se encuentra al jugador, intenta buscarlo nuevamente
            FindPlayer();
        }
    }

    private void FindPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("No se pudo encontrar al jugador en la escena.");
        }
    }
}
