using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    private static PlayerController instance;

    private float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private void Awake()
    {
        // Aseg�rate de que solo haya una instancia en ejecuci�n
        if (instance != null && instance != this)
        {
            // Si ya hay una instancia en ejecuci�n, destruye este GameObject
            Destroy(gameObject);
        }
        else
        {
            // Si este es el �nico jugador, aseg�rate de que no se destruya al cambiar de escena
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player takes " + damageAmount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        // Aqu� podr�as agregar c�digo para reiniciar el nivel o mostrar un mensaje de game over.
    }

    private void Update()
    {
        // Detectar los l�mites del �rea permitida en la escena actual
        MapAreaBounds areaBounds = FindObjectOfType<MapAreaBounds>();
        if (areaBounds != null)
        {
            // Obtener los l�mites del �rea permitida
            Vector2 minBounds = areaBounds.minBounds;
            Vector2 maxBounds = areaBounds.maxBounds;

            // Obtener la entrada de movimiento del jugador
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calcular la posici�n deseada del jugador
            Vector3 desiredPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

            // Limitar la posici�n del jugador dentro del �rea permitida
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            // Aplicar la posici�n limitada al jugador
            transform.position = desiredPosition;
        }
    }
}
