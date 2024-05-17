using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 1.5f;
    private Transform target;
    private Animator animator; // Referencia al componente Animator
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null && playerObject.activeSelf)
        {
            target = playerObject.transform;
        }
        else
        {
            GameObject[] playerReserveObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject playerReserveObject in playerReserveObjects)
            {
                if (playerReserveObject.activeSelf)
                {
                    target = playerReserveObject.transform;
                    break;
                }
            }
        }

        if (target == null)
        {
            Debug.LogError("No se encontr� ning�n objeto activo con el tag Player");
        }

        // Obtener el componente Animator
        animator = GetComponent<Animator>();

        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Configurar el par�metro "IsMoving" del Animator seg�n el movimiento
            bool isMoving = direction.magnitude > 0.1f;
            animator.SetBool("IsMoving", isMoving);

            // Cambiar la direcci�n del enemigo seg�n la direcci�n del jugador
            if (direction.x > 0)
            {
                // Mirando hacia la derecha
                transform.localScale = new Vector3(-0.75f, 0.75f, 1);
            }
            else if (direction.x < 0)
            {
                // Mirando hacia la izquierda
                transform.localScale = new Vector3(0.75f, 0.75f, 1);
            }
        }
    }

    
    
}
