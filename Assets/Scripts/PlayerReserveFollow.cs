using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReserveFollow : MonoBehaviour
{
    public GameObject player; // Referencia al GameObject del jugador

    void Update()
    {
        // Verificar si el jugador est� activo
        if (player != null && player.activeSelf)
        {
            // Mover el GameObject de reserva a la posici�n del jugador
            transform.position = player.transform.position;
        }
    }
}
