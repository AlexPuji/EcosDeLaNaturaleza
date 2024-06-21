using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerFM : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth; 

    public Slider healthSlider; 

    private static PlayerControllerFM instance;

    
    private void Start()
    {
        currentHealth = maxHealth;

        
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player takes damage. Current health: " + currentHealth);

        
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
    private void Die()
    {
        Debug.Log("Player has died.");
        gameObject.SetActive(false);

        
        SceneManager.LoadScene("Final Scene");
    }

}
