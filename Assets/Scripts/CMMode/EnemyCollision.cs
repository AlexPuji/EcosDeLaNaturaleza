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
        if (other.gameObject.CompareTag("Player")) // Verificar si la colisi�n es con el jugador.
        {
            Debug.Log("Zombie collided with player.");

            if (playerController != null)
            {
                float damageAmount = 10f; // Define aqu� la cantidad de da�o que inflige el enemigo
                playerController.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("PlayerController not found!");
            }
        }
    }
}
