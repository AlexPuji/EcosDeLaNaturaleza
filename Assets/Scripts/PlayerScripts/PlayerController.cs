using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private float moveSpeed = 5f; // Velocidad de movimiento del jugador

    private static PlayerController instance;

    private void Awake()
    {
        // Asegúrate de que solo haya una instancia en ejecución
        if (instance != null && instance != this)
        {
            // Si ya hay una instancia en ejecución, destruye este GameObject
            Destroy(gameObject);
        }
        else
        {
            // Si este es el único jugador, asegúrate de que no se destruya al cambiar de escena
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player takes damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        gameObject.SetActive(false);
        // Aquí puedes agregar código para reiniciar el nivel o mostrar un mensaje de game over.
    }

    private void Update()
    {
        // Detectar los límites del área permitida en la escena actual
        MapAreaBounds areaBounds = FindObjectOfType<MapAreaBounds>();
        if (areaBounds != null)
        {
            // Obtener los límites del área permitida
            Vector2 minBounds = areaBounds.minBounds;
            Vector2 maxBounds = areaBounds.maxBounds;

            // Obtener la entrada de movimiento del jugador
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calcular la posición deseada del jugador
            Vector3 desiredPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

            // Limitar la posición del jugador dentro del área permitida
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            // Aplicar la posición limitada al jugador
            transform.position = desiredPosition;
        }
    }
}
