using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionDistance = 5f; // La distancia a la que el enemigo detectará al jugador
    public float movementSpeed = 3f; // La velocidad a la que el enemigo se moverá hacia el jugador
    public float roamSpeed = 1f; // La velocidad de "paseo" cuando el jugador no está detectado
    public float roamInterval = 1.5f; // Intervalo de tiempo entre cambios de dirección durante el "paseo"
    private Transform player; // Referencia al transform del jugador
    private Animator animator;
    private bool isMoving = false;
    private Vector3 roamDirection; // Dirección de "paseo"
    private float nextRoamTime; // Tiempo para el próximo cambio de dirección de "paseo"

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar el jugador por su etiqueta
        animator = GetComponent<Animator>();

        // Inicializar la dirección de "paseo" de forma aleatoria
        roamDirection = Random.insideUnitCircle.normalized;
        nextRoamTime = Time.time + Random.Range(0f, roamInterval);
    }

    void Update()
    {
        // Calculando la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro de la distancia de detección
        if (distanceToPlayer < detectionDistance)
        {
            // Calculando la dirección hacia la cual el enemigo debería moverse
            Vector2 direction = (player.position - transform.position).normalized;

            // Mirando en la dirección del jugador
            if (direction.x > 0)
            {
                // Mirando hacia la derecha
                transform.localScale = new Vector3(-0.75f, 0.75f, 1); // Voltear hacia la derecha
            }
            else if (direction.x < 0)
            {
                // Mirando hacia la izquierda
                transform.localScale = new Vector3(0.75f, 0.75f, 1); // Voltear hacia la izquierda
            }

            // Moviendo el enemigo hacia el jugador con la velocidad actualizada
            transform.Translate(direction * movementSpeed * Time.deltaTime);

            // Actualizando el parámetro IsMoving del Animator
            isMoving = true;
        }
        else
        {
            // Si el jugador no está detectado, realizar el "paseo"
            Roam();

            // Actualizar el parámetro IsMoving en el Animator
            animator.SetBool("IsMoving", isMoving);
        }
    }

    // Función para el comportamiento de "paseo"
    void Roam()
    {
        // Si es hora de cambiar la dirección de "paseo"
        if (Time.time >= nextRoamTime)
        {
            // Cambiar la dirección de "paseo" de forma aleatoria
            roamDirection = Random.insideUnitCircle.normalized;

            // Calcular el próximo tiempo de cambio de dirección
            nextRoamTime = Time.time + roamInterval;
        }

        // Mover al enemigo en la dirección de "paseo" con la velocidad de "paseo"
        transform.Translate(roamDirection * roamSpeed * Time.deltaTime);

        // Actualizar la variable de movimiento
        isMoving = true;
    }
}
