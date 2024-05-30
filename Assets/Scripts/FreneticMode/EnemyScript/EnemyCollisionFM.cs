using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionFM : MonoBehaviour
{
    private PlayerControllerFM playerControllerFm;
    public EnemyCollisionSound enemyCollisionSound; // Asegúrate de asignar manualmente el componente EnemyCollisionSound en el Inspector

    private void Start()
    {
        playerControllerFm = FindObjectOfType<PlayerControllerFM>();

        if (playerControllerFm == null)
        {
            Debug.LogWarning("PlayerControllerFM not found!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Verificar si la colisión es con el jugador.
        {
            Debug.Log("Zombie collided with player.");

            if (playerControllerFm != null)
            {
                float damageAmount = 10f; // Define aquí la cantidad de daño que inflige el enemigo
                playerControllerFm.TakeDamage(damageAmount);

                // Reproducir el sonido de colisión del enemigo
                if (enemyCollisionSound != null)
                {
                    enemyCollisionSound.PlayEnemyCollisionSound();
                }
                else
                {
                    Debug.LogWarning("EnemyCollisionSound component not assigned!");
                }
            }
            else
            {
                Debug.LogWarning("PlayerControllerFM not found!");
            }
        }
    }
}
