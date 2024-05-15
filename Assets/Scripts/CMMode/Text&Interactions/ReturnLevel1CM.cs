using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToWorld : MonoBehaviour
{
    public Text messageText; // Referencia al componente Text del mensaje

    private bool playerInRange = false; // Variable para rastrear si el jugador est� dentro del rango de interacci�n

    private void Start()
    {
        // Aseg�rate de que el mensaje est� desactivado al inicio
        messageText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Verifica si el jugador est� dentro del rango de interacci�n y muestra el mensaje
        if (playerInRange)
        {
            messageText.gameObject.SetActive(true);
        }
        else
        {
            messageText.gameObject.SetActive(false);
        }

        // Verifica si el jugador presiona la tecla para interactuar
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Carga la escena del nivel principal
            SceneManager.LoadScene("Level 1 CM");
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
