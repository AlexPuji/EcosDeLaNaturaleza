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
        // Aquí iría la lógica para reducir la vida del jugador cuando recibe daño, por ejemplo.
        // Después de actualizar la vida del jugador, actualiza también la barra de vida.
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
            // Realizar acciones adicionales cuando el jugador muere, como reiniciar el nivel o mostrar un menú de juego
            // Por ejemplo:
            Die();
        }
    }
    public void Die()
    {
        // Aquí puedes implementar acciones adicionales cuando el jugador muere,
        // como reiniciar el nivel o mostrar un menú de juego.
        // Por ejemplo, puedes cargar una escena de Game Over:
        // SceneManager.LoadScene("GameOverScene");
    }
}
