using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    public int damageAmount = 7; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<zombieEnemy>().TakeDamage(damageAmount);//en collisionar amb el Enemy
            //Desactivar collider
            //Destruir en un temps 
           // Destroy(gameObject);//error en la destruccio no deixa acabar la animacio
        }
    }

}
