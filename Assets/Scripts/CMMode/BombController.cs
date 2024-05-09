using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Animator animator;
    private Collider2D bombCollider; // Referencia al collider de la bomba

    private bool hasDetonated = false; // Flag para controlar si la bomba ya ha detonado

    private void Start()
    {
        animator = GetComponent<Animator>();
        bombCollider = GetComponent<Collider2D>(); // Obtener el collider de la bomba
    }

    private IEnumerator DetonateBomb()
    {
        if (!hasDetonated)
        {
            // Si la bomba a�n no ha detonado, activa el par�metro "DetectedPlayer" en el Animator.
            animator.SetBool("DetectedPlayer", true);
            hasDetonated = true; // Marcar que la bomba ha detonado

            // Desactivar el collider de la bomba para evitar m�ltiples detonaciones
            bombCollider.enabled = false;

            // Esperar un momento antes de permitir que la bomba detone nuevamente
            yield return new WaitForSeconds(1f);

            // Destruir la bomba despu�s de que termine la animaci�n de explosi�n
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasDetonated && (other.CompareTag("Player") || other.CompareTag("Enemy")))
        {
            StartCoroutine(DetonateBomb());
        }
    }
}
