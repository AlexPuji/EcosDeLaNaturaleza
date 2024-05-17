using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionFM : MonoBehaviour
{
    private PlayerControllerFM playerControllerFm;

    private void Awake()
    {
        playerControllerFm = FindObjectOfType<PlayerControllerFM>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Verificar si la colisi�n es con el jugador.
        {
            Debug.Log("Zombie collided with player.");

            if (playerControllerFm != null)
            {
                float damageAmount = 10f; // Define aqu� la cantidad de da�o que inflige el enemigo
                playerControllerFm.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("PlayerControllerFM not found!");
            }
        }
    }
}
