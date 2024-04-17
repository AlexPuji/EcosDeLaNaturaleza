using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReserveFollow : MonoBehaviour
{
    public GameObject player; // Referencia al GameObject del jugador

    void Update()
    {
        // Verificar si el jugador está activo
        if (player != null && player.activeSelf)
        {
            // Mover el GameObject de reserva a la posición del jugador
            transform.position = player.transform.position;
        }
    }
}
