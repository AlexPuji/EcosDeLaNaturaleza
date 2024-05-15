using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Verificar si la colisión es con el jugador.
        {
            Debug.Log("Zombie collided with player.");

            if (playerController != null)
            {
                float damageAmount = 10f; // Define aquí la cantidad de daño que inflige el enemigo
                playerController.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("PlayerController not found!");
            }
        }
    }
}
