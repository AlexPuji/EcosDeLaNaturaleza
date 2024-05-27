using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private ZombieSoundManager zombieSoundManager; // Referencia al ZombieSoundManager
    private PlayerController playerController;
    public float attackForce = 4000f; // Fuerza de retroceso al jugador

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        zombieSoundManager = FindObjectOfType<ZombieSoundManager>(); // Buscar el ZombieSoundManager en la escena
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Zombie collided with player.");

            if (playerController != null)
            {
                float damageAmount = 10f; // Daño del enemigo
                playerController.TakeDamage(damageAmount);

                Vector2 pushDirection = (other.transform.position - transform.position).normalized;
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * attackForce);

                if (zombieSoundManager != null)
                {
                    // Llamar al método PlayCollisionSound() del ZombieSoundManager
                    zombieSoundManager.PlayCollisionSound();
                }
                else
                {
                    Debug.LogWarning("ZombieSoundManager not found!");
                }
            }
            else
            {
                Debug.LogWarning("PlayerController not found!");
            }
        }
    }
}
