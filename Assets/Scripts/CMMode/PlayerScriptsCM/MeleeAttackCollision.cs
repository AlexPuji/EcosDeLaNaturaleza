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
                // Calcula la dirección del retroceso (hacia atrás desde el punto de impacto)
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

                // Aplica la fuerza de retroceso al enemigo
                enemyRigidbody.AddForce(pushDirection * attackForce);
            }

            // Aplica el daño al enemigo
            collision.gameObject.GetComponent<zombieEnemy>().TakeDamage(damageAmount);

            // Ha pegado al enemigo
            hasHitEnemy = true;

            // Desactivar el collider para la animación
            StartCoroutine(DisableColliderForAnimation());

            // Destruir el objeto después de un tiempo
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DisableColliderForAnimation()
    {
        // Desactivar el collider
        attackCollider.enabled = false;

        // Esperar un segundo para la animación
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
