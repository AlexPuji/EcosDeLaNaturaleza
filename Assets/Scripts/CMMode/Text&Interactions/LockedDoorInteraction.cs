using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorInteraction : MonoBehaviour
{
    public float interactDistance = 2f; // Distancia a la que el jugador puede interactuar
    public GameObject messageText; // Objeto de texto para mostrar el mensaje
    public bool isLocked = true; // Indica si la puerta está cerrada o no

    private bool playerInRange = false; // Variable para rastrear si el jugador está dentro del rango de interacción

    private void Update()
    {
        // Verifica si el jugador está dentro del rango de interacción y muestra el mensaje
        if (playerInRange)
        {
            // Verifica si el objeto de texto aún existe antes de intentar acceder a él
            if (messageText != null)
            {
                if (isLocked)
                {
                    messageText.SetActive(true); // Muestra el mensaje en pantalla
                }
                else
                {
                    Debug.Log("Presiona 'E' para entrar."); // Muestra el mensaje en la consola
                }
            }
        }
        else
        {
            // Verifica si el objeto de texto aún existe antes de intentar acceder a él
            if (messageText != null)
            {
                messageText.SetActive(false); // Oculta el mensaje cuando el jugador está fuera del rango
            }
        }

        // Verifica si el jugador presiona la tecla para interactuar
        if (playerInRange && !isLocked && Input.GetKeyDown(KeyCode.E))
        {
            // Aquí puedes realizar cualquier acción relacionada con la interacción, como abrir la puerta
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador está dentro del rango de interacción
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador sale del rango de interacción
            playerInRange = false;
        }
    }
}
