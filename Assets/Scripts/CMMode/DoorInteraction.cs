using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float interactDistance = 2f; // Distancia a la que el jugador puede interactuar
    public GameObject messageText; // Objeto de texto para mostrar el mensaje

    private bool playerInRange = false; // Variable para rastrear si el jugador está dentro del rango de interacción

    private void Update()
    {
        // Verifica si el jugador está dentro del rango de interacción y muestra el mensaje
        if (playerInRange)
        {
            messageText.SetActive(true);
        }
        else
        {
            messageText.SetActive(false);
        }

        // Verifica si el jugador presiona la tecla para interactuar
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Aquí puedes realizar cualquier acción relacionada con la interacción, como abrir la puerta
            Debug.Log("Presiona 'E' para entrar.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador está dentro del rango de interacción
            playerInRange = true;
            Debug.Log("Player entered trigger zone."); // Mensaje de depuración
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador sale del rango de interacción
            playerInRange = false;
            Debug.Log("Player exited trigger zone."); // Mensaje de depuración
        }
    }
}
