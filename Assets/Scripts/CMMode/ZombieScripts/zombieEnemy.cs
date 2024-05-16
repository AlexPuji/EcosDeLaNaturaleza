using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombieEnemy : MonoBehaviour
{
    public int maxHealth = 50; // Vida m�xima del enemigo
    private int currentHealth; // Vida actual del enemigo

    // Referencia al Slider de la barra de vida del zombie (estar� disponible en el inspector)
    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        // Configura el valor m�ximo del slider
        healthSlider.maxValue = maxHealth;
        // Actualiza el valor del slider con la vida actual del zombie
        healthSlider.value = currentHealth;
    }

    // M�todo para que el zombie reciba da�o
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Zombie takes " + damageAmount + " damage. Current health: " + currentHealth);

        // Actualiza el valor del slider con la vida actual del zombie
        healthSlider.value = currentHealth;

        // Verifica si el zombie ha perdido toda su vida y muere
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo llamado cuando el zombie muere
    private void Die()
    {
        Debug.Log("Zombie has died.");
        Destroy(gameObject); // Destruye el enemigo
    }
}
