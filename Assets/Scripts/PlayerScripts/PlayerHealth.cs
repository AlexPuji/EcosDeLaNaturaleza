using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5;
    public int currentLives;
    public string levelToLoad = "Level2"; // Nombre de la escena que deseas cargar

    public GameObject playerReserve; // Referencia al GameObject de reserva para el jugador

    void Start()
    {
        currentLives = maxLives;
    }

    public void ReceiveHit()
    {
        currentLives--;

        Debug.Log("El jugador ha recibido un golpe. Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false); // Desactivar el GameObject del jugador
        playerReserve.SetActive(true); // Activar el GameObject de reserva

        // Cargar la escena "Level 2"
        SceneManager.LoadScene(levelToLoad);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReceiveHit();
        }
    }
}


