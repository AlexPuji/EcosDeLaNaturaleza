using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // El objetivo al que seguir

    void Update()
    {
        if (target != null)
        {
            // Actualiza la posición del objeto para que siga al objetivo
            transform.position = target.position;
        }
    }
}
