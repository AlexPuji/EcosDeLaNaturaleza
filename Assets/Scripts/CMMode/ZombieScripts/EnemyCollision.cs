using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private PlayerController playerController;
    public float attackForce = 4000f; // Fuerza de retroceso al jugador

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Colisión con el jugador para hacer daño
        {
            Debug.Log("Zombie collided with player.");

            if (playerController != null)
            {
                float damageAmount = 10f; // Daño del enemigo
                playerController.TakeDamage(damageAmount);

                // Aplicar fuerza de retroceso al jugador
                Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * attackForce);
            }
            else
            {
                Debug.LogWarning("PlayerController not found!");
            }
        }
    }
}
