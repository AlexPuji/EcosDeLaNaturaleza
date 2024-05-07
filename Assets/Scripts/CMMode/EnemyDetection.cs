using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionDistance = 5f; // La distancia a la que el enemigo detectar� al jugador
    public float movementSpeed = 3f; // La velocidad a la que el enemigo se mover� hacia el jugador
    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar el jugador por su etiqueta
    }

    void Update()
    {
        // Calculando la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador est� dentro de la distancia de detecci�n
        if (distanceToPlayer < detectionDistance)
        {
            // Calculando la direcci�n hacia la cual el enemigo deber�a moverse
            Vector2 direction = (player.position - transform.position).normalized;

            // Moviendo el enemigo hacia el jugador con la velocidad actualizada
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
    }
}
