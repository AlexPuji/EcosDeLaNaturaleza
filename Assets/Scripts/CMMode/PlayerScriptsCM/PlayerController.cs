using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del jugador
    private float currentHealth; // Vida actual del jugador

    public Slider healthSlider; // Referencia al Slider de vida en la interfaz de usuario

    private static PlayerController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
    private void Start()
    {
        currentHealth = maxHealth;

        // Actualiza el valor inicial del Slider de vida
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

        
        Invoke("LoadSelectModeScene", 2f); 
    }

    private void LoadSelectModeScene()
    {
        SceneManager.LoadScene("SelectMode");
    }

}
