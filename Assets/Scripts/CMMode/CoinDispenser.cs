using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenser : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public float interactDistance = 2f; // Distancia a la que el jugador puede interactuar
    public GameObject pressEText; // Objeto de texto para mostrar el mensaje "Press 'E'"
    public GameObject emptyText; // Objeto de texto para mostrar el mensaje "Empty"
    public float coinSpawnRadius = 1.5f; // Radio alrededor de la máquina donde pueden aparecer las monedas

    private bool playerInRange = false; // Variable para rastrear si el jugador está dentro del rango de interacción
    private int interactionsRemaining = 2; // Número máximo de interacciones permitidas

    private void Update()
    {
        // Verifica si el jugador está dentro del rango de interacción
        if (playerInRange)
        {
            // Muestra el mensaje "Press 'E'" si quedan interacciones disponibles
            if (interactionsRemaining > 0)
            {
                pressEText.SetActive(true);
                emptyText.SetActive(false);
            }
            else
            {
                // Si no quedan interacciones disponibles, muestra el mensaje "Empty"
                pressEText.SetActive(false);
                emptyText.SetActive(true);
            }
        }
        else
        {
            pressEText.SetActive(false);
            emptyText.SetActive(false);
        }

        // Verifica si el jugador presiona la tecla para interactuar y si quedan interacciones disponibles
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && interactionsRemaining > 0)
        {
            InteractWithVendingMachine();
            interactionsRemaining--; // Reduce el número de interacciones restantes
        }
    }

    private void InteractWithVendingMachine()
    {
        // Genera un número aleatorio entre 1 y 5 para determinar cuántas monedas soltar
        int numberOfCoinsToSpawn = Random.Range(1, 6);

        // Genera las monedas
        for (int i = 0; i < numberOfCoinsToSpawn; i++)
        {
            // Genera una posición aleatoria dentro de un círculo alrededor de la máquina
            Vector3 randomSpawnPosition = Random.insideUnitCircle * coinSpawnRadius;
            Vector3 spawnPosition = transform.position + randomSpawnPosition;

            // Instancia la moneda en la posición aleatoria
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
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
