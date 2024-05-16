using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    public int damageAmount = 7;
    public float attackForce = 500f; // Intensidad del retroceso
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
                // Calcula la direcci�n del retroceso (hacia atr�s desde el punto de impacto)
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

                // Aplica la fuerza de retroceso al enemigo
                enemyRigidbody.AddForce(pushDirection * attackForce);
            }

            // Aplica el da�o al enemigo
            collision.gameObject.GetComponent<zombieEnemy>().TakeDamage(damageAmount);

            // Ha pegado al enemigo
            hasHitEnemy = true;

            // Desactivar el collider para la animaci�n
            StartCoroutine(DisableColliderForAnimation());

            // Destruir el objeto despu�s de un tiempo
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DisableColliderForAnimation()
    {
        // Desactivar el collider
        attackCollider.enabled = false;

        // Esperar un segundo para la animaci�n
        yield return new WaitForSeconds(1f);

        // Activar el collider
        attackCollider.enabled = true;

        // Reiniciar la bandera de golpe al enemigo
        hasHitEnemy = false;
    }

    IEnumerator DestroyAfterDelay()
    {
        // Esperar unos segundos para destruir el objeto
        yield return new WaitForSeconds(1f);

        // Destruir el objeto 
        Destroy(gameObject);
    }

}
