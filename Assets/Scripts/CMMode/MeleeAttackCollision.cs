using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    public int damageAmount = 7; // Cantidad de daño infligido por la colisión

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Colisionó con un enemigo, así que le quitamos vida al enemigo
            collision.gameObject.GetComponent<zombieEnemy>().TakeDamage(damageAmount);
            // También destruimos la bala
            Destroy(gameObject);
        }
    }

}
