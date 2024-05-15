using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReserveFollow : MonoBehaviour
{
    public GameObject player; //Referenci del character1

    void Update()
    {
        // Verificar si el jugador está activo
        if (player != null && player.activeSelf)
        {
            // ajustar el P.reserve a la posicion de jugador
            transform.position = player.transform.position;
        }
    }
}
