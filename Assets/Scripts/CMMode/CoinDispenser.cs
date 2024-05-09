using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenser : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public float interactDistance = 2f; // Distancia a la que el jugador puede interactuar
    public GameObject pressEText; // Objeto de texto para mostrar el mensaje "Press 'E'"
    public GameObject emptyText; // Objeto de texto para mostrar el mensaje "Empty"
    public float coinSpawnRadius = 1.5f; // Radio alrededor de la m�quina donde pueden aparecer las monedas

    private bool playerInRange = false; // Variable para rastrear si el jugador est� dentro del rango de interacci�n
    private int interactionsRemaining = 2; // N�mero m�ximo de interacciones permitidas

    private void Update()
    {
        // Verifica si el jugador est� dentro del rango de interacci�n
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
            interactionsRemaining--; // Reduce el n�mero de interacciones restantes
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
