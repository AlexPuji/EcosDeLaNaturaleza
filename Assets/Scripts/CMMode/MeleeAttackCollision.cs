using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    public int damageAmount = 7; // Cantidad de da�o infligido por la colisi�n

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Colision� con un enemigo, as� que le quitamos vida al enemigo
            collision.gameObject.GetComponent<zombieEnemy>().TakeDamage(damageAmount);
            // Tambi�n destruimos la bala
            Destroy(gameObject);
        }
    }

}
