using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5;
    public int currentLives;
    public GameObject playerReserve;

    public delegate void PlayerDeathAction();
    public static event PlayerDeathAction OnPlayerDeath;

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
        Debug.Log("El jugador ha muerto.");
        gameObject.SetActive(false);
        playerReserve.SetActive(true);

        // Avis al Game Manager (No sabia el que era Invoke, he volgut probar, Fins ara sol feia destroy....)
        OnPlayerDeath?.Invoke();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReceiveHit();
        }
    }
}


