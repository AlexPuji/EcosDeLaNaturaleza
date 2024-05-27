using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenser : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public float interactDistance = 2f;
    public GameObject pressEText;
    public GameObject emptyText;
    public float coinSpawnRadius = 1.5f;
    public AudioClip coinDispenseSound; // Sonido de la máquina dispensadora
    public AudioSource audioSource; // AudioSource para reproducir el sonido

    private bool playerInRange = false;
    private int interactionsRemaining = 2;

    private void Update()
    {
        if (playerInRange)
        {
            if (interactionsRemaining > 0)
            {
                if (pressEText != null)
                    pressEText.SetActive(true);
                if (emptyText != null)
                    emptyText.SetActive(false);
            }
            else
            {
                if (pressEText != null)
                    pressEText.SetActive(false);
                if (emptyText != null)
                    emptyText.SetActive(true);
            }
        }
        else
        {
            if (pressEText != null)
                pressEText.SetActive(false);
            if (emptyText != null)
                emptyText.SetActive(false);
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E) && interactionsRemaining > 0)
        {
            InteractWithVendingMachine();
            interactionsRemaining--;

            // Reproducir el sonido de la máquina dispensadora
            if (coinDispenseSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinDispenseSound);
            }
        }
    }

    private void InteractWithVendingMachine()
    {
        int numberOfCoinsToSpawn = Random.Range(1, 6);

        for (int i = 0; i < numberOfCoinsToSpawn; i++)
        {
            Vector3 randomSpawnPosition = Random.insideUnitCircle * coinSpawnRadius;
            Vector3 spawnPosition = transform.position + randomSpawnPosition;

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
