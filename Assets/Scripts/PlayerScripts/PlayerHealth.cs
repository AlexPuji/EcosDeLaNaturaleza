using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5;
    public int currentLives;
    public string levelToLoad = "Level2"; 

    public GameObject playerReserve; //Reserve para hacer que los zombies siguan al jugador

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
        gameObject.SetActive(false); // Muerte
        playerReserve.SetActive(true); // Activa el Reserve

        // Cargar la escena del Mode
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


