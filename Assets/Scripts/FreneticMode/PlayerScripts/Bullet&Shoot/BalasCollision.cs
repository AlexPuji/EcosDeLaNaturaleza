using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            
            if (enemyHealth != null)
            {
                
                enemyHealth.TakeDamage();
            }

            
            Destroy(gameObject);
        }
    }
}
