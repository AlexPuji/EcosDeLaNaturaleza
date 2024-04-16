using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        // Reducir la salud
        health -= damage;

        // Si la salud llega a cero o menos, destruye el GameObject del enemigo
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
