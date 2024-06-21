using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackCollision : MonoBehaviour
{
    public int damageAmount = 7;
    public float attackForce = 500f;
    public AudioClip hitSound; // Sonido de golpe al enemigo
    private Collider2D attackCollider;
    private bool hasHitEnemy = false;
    private AudioSource audioSource; // Referencia al AudioSource

    void Start()
    {
        // Collider del ataque
        attackCollider = GetComponent<Collider2D>();

        // Obtener el AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Añadir un componente AudioSource si no existe
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasHitEnemy && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // Retroceso del enemigo
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(pushDirection * attackForce);
            }

            // Daño al enemigo
            collision.gameObject.GetComponent<ZombieEnemy>().TakeDamage(damageAmount);

            // Reproducir el sonido de golpe al enemigo
            if (hitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

            // Marcar que ha golpeado al enemigo
            hasHitEnemy = true;

            // Desactivar el collider temporalmente
            StartCoroutine(DisableColliderForAnimation());

            // Destruir el ataque después de un tiempo
            StartCoroutine(DestroyAfterDelay());
        }
    }

    IEnumerator DisableColliderForAnimation()
    {
        // Desactivar el collider
        attackCollider.enabled = false;

        yield return new WaitForSeconds(1f);

        // Activar el collider nuevamente
        attackCollider.enabled = true;

        // Reiniciar la bandera de golpeo al enemigo
        hasHitEnemy = false;
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(1f);

        // Destruir el objeto del ataque
        Destroy(gameObject);
    }
}
