using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenser : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public float interactDistance = 2f; // Distancia a la que el jugador puede interactuar
    public GameObject messageText; // Objeto de texto para mostrar el mensaje
    public float coinSpawnRadius = 1.5f; // Radio alrededor de la m�quina donde pueden aparecer las monedas

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
            InteractWithVendingMachine();
        }
    }

    private void InteractWithVendingMachine()
    {
        // Genera un n�mero aleatorio entre 1 y 5 para determinar cu�ntas monedas soltar
        int numberOfCoinsToSpawn = Random.Range(1, 6);

        // Genera las monedas
        for (int i = 0; i < numberOfCoinsToSpawn; i++)
        {
            // Genera una posici�n aleatoria dentro de un c�rculo alrededor de la m�quina
            Vector3 randomSpawnPosition = Random.insideUnitCircle * coinSpawnRadius;
            Vector3 spawnPosition = transform.position + randomSpawnPosition;

            // Instancia la moneda en la posici�n aleatoria
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador est� dentro del rango de interacci�n
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador sale del rango de interacci�n
            playerInRange = false;
        }
    }
}
