using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Colisionó con un enemigo, así que lo eliminamos
            Destroy(collision.gameObject);
            // También destruimos la bala
            Destroy(gameObject);
        }
    }

}
