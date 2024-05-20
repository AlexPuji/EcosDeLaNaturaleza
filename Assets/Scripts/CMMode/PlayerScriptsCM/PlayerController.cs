using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f; // Vida m�xima del jugador
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

    // M�todo llamado al inicio para inicializar la vida del jugador
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

    // M�todo para que el jugador reciba da�o
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player takes damage. Current health: " + currentHealth);

        // Actualiza el valor del Slider de vida
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Verifica si el jugador ha perdido toda su vida y muere
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo llamado cuando el jugador muere
    private void Die()
    {
        Debug.Log("Player has died.");
        gameObject.SetActive(false);

        // Carga la escena "SelectMode" despu�s de un peque�o retraso
        Invoke("LoadSelectModeScene", 2f); // Espera 2 segundos antes de cargar la escena
    }

    private void LoadSelectModeScene()
    {
        SceneManager.LoadScene("SelectMode");
    }

}
