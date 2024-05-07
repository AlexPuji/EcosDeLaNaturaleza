using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Colision� con un enemigo, as� que lo eliminamos
            Destroy(collision.gameObject);
            // Tambi�n destruimos la bala
            Destroy(gameObject);
        }
    }

}
