using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Animator animator;
    private Collider2D bombCollider;

    private bool hasDetonated = false; //Para saber si la bomba ha explotado
    public int damageAmount = 20; // Daño que hará la bomba

    private void Start()
    {
        animator = GetComponent<Animator>();
        bombCollider = GetComponent<Collider2D>();
    }

    private IEnumerator DetonateBomb()
    {
        if (!hasDetonated)
        {
            // Activar el parámetro en caso de que la bomba no haya explotado
            animator.SetBool("DetectedPlayer", true);
            hasDetonated = true; // Marcar que la bomba ha detonado

            bombCollider.enabled = false;

            // Esperar un segundo para que la animación de explosión se complete
            yield return new WaitForSeconds(1f);

            Destroy(gameObject);
        }
    }

    // Explota al detectar el tag de Player o Enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasDetonated && (other.CompareTag("Player") || other.CompareTag("Enemy")))
        {
            // Intentar obtener el componente del script de vida del objeto que activó la bomba
            if (other.CompareTag("Player"))
            {
                PlayerController playerController = other.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    // Aplicar daño al jugador
                    playerController.TakeDamage(damageAmount);
                }
            }
            else if (other.CompareTag("Enemy"))
            {
                ZombieEnemy zombieEnemy = other.GetComponent<ZombieEnemy>();
                if (zombieEnemy != null)
                {
                    // Aplicar daño al zombie
                    zombieEnemy.TakeDamage(damageAmount);
                }
            }

            StartCoroutine(DetonateBomb());
        }
    }
}
