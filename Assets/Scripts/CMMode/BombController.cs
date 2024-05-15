using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Animator animator;
    private Collider2D bombCollider; 

    private bool hasDetonated = false; //Per saber si la bomba ha explotat

    private void Start()
    {
        animator = GetComponent<Animator>();
        bombCollider = GetComponent<Collider2D>(); 
    }

    private IEnumerator DetonateBomb()
    {
        if (!hasDetonated)
        {
            //activar el Parametre en cas de que la bomba no exploti
            animator.SetBool("DetectedPlayer", true);
            hasDetonated = true; // Marcar que la bomba ha detonado

            
            bombCollider.enabled = false;

            
            yield return new WaitForSeconds(1f);

            
            Destroy(gameObject);
        }
    }
    //Explotar al detectar el tag de Player o Enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasDetonated && (other.CompareTag("Player") || other.CompareTag("Enemy")))
        {
            StartCoroutine(DetonateBomb());
        }
    }
}
