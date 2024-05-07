using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieEnemy : MonoBehaviour
{
    public int maxHits = 4; // Número máximo de toques necesarios para morir
    private int currentHits = 0; // Número actual de toques recibidos

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que colisiona es un ataque melee del jugador
        if (other.CompareTag("MeleeAttack"))
        {
            // Incrementar el contador de toques
            currentHits++;

            // Destruir el ataque melee
            Destroy(other.gameObject);

            // Verificar si el zombie ha recibido suficientes toques para morir
            if (currentHits >= maxHits)
            {
                // Si el zombie ha recibido suficientes toques, destruirlo
                Destroy(gameObject);
            }
        }
    }
}
