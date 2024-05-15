using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieEnemy : MonoBehaviour
{
    public int maxHealth = 50; // Vida máxima del enemigo
    private int currentHealth; // Vida actual del enemigo

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Zombie takes " + damageAmount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Zombie has died.");
        Destroy(gameObject); // Destruir el enemigo
    }

}
