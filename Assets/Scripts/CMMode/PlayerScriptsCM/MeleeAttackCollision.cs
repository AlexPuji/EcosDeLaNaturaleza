using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    public int damageAmount = 7;
    public float attackForce = 500f; 
    private Collider2D attackCollider;
    private bool hasHitEnemy = false;

    void Start()
    {
        // Collider 
        attackCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasHitEnemy && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // retroceso direccio
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

                //retroceso l enemic
                enemyRigidbody.AddForce(pushDirection * attackForce);
            }

            // dmg al enemic
            collision.gameObject.GetComponent<ZombieEnemy>().TakeDamage(damageAmount);

            
            hasHitEnemy = true;

            
            StartCoroutine(DisableColliderForAnimation());

            //destruir despues de una estona
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DisableColliderForAnimation()
    {
        
        attackCollider.enabled = false;

        
        yield return new WaitForSeconds(1f);

        
        attackCollider.enabled = true;

        
        hasHitEnemy = false;
    }

    IEnumerator DestroyAfterDelay()
    {
        
        yield return new WaitForSeconds(1f);

        
        Destroy(gameObject);
    }

}
