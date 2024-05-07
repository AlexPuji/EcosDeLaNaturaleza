using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float interactDistance = 2f; // Distancia a la que el jugador puede interactuar
    public GameObject messageText; // Objeto de texto para mostrar el mensaje

    private bool playerInRange = false; // Variable para rastrear si el jugador est� dentro del rango de interacci�n

    private void Update()
    {
        // Verifica si el jugador est� dentro del rango de interacci�n y muestra el mensaje
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
            // Aqu� puedes realizar cualquier acci�n relacionada con la interacci�n, como abrir la puerta
            Debug.Log("Presiona 'E' para entrar.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador est� dentro del rango de interacci�n
            playerInRange = true;
            Debug.Log("Player entered trigger zone."); // Mensaje de depuraci�n
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador sale del rango de interacci�n
            playerInRange = false;
            Debug.Log("Player exited trigger zone."); // Mensaje de depuraci�n
        }
    }
}
