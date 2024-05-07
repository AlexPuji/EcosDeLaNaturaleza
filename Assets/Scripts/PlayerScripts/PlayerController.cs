using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxLife = 100f;
    public float currentLife;

    public LifeBar lifeBar;

    void Start()
    {
        currentLife = maxLife;
        lifeBar.SetMaxLife(maxLife);
    }

    void Update()
    {
        // Aqu� ir�a la l�gica para reducir la vida del jugador cuando recibe da�o, por ejemplo.
        // Despu�s de actualizar la vida del jugador, actualiza tambi�n la barra de vida.
        lifeBar.SetLife(currentLife);
    }
    public void TakeDamage(float amount)
    {
        currentLife -= amount;
        // Actualizar la barra de vida
        lifeBar.SetLife(currentLife);

        // Verificar si el jugador ha muerto
        if (currentLife <= 0)
        {
            // Realizar acciones adicionales cuando el jugador muere, como reiniciar el nivel o mostrar un men� de juego
            // Por ejemplo:
            Die();
        }
    }
    public void Die()
    {
        // Aqu� puedes implementar acciones adicionales cuando el jugador muere,
        // como reiniciar el nivel o mostrar un men� de juego.
        // Por ejemplo, puedes cargar una escena de Game Over:
        // SceneManager.LoadScene("GameOverScene");
    }
}
