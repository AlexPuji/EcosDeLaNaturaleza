using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionDistance = 5f; // La distancia a la que el enemigo detectar� al jugador
    public float movementSpeed = 3f; // La velocidad a la que el enemigo se mover� hacia el jugador
    public float roamSpeed = 1f; // La velocidad de "paseo" cuando el jugador no est� detectado
    public float roamInterval = 1.5f; // Intervalo de tiempo entre cambios de direcci�n durante el "paseo"
    private Transform player; // Referencia al transform del jugador
    private Animator animator;
    private bool isMoving = false;
    private Vector3 roamDirection; // Direcci�n de "paseo"
    private float nextRoamTime; // Tiempo para el pr�ximo cambio de direcci�n de "paseo"

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar el jugador por su etiqueta
        animator = GetComponent<Animator>();

        // Inicializar la direcci�n de "paseo" de forma aleatoria
        roamDirection = Random.insideUnitCircle.normalized;
        nextRoamTime = Time.time + Random.Range(0f, roamInterval);
    }

    void Update()
    {
        // Calculando la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador est� dentro de la distancia de detecci�n
        if (distanceToPlayer < detectionDistance)
        {
            // Calculando la direcci�n hacia la cual el enemigo deber�a moverse
            Vector2 direction = (player.position - transform.position).normalized;

            // Mirando en la direcci�n del jugador
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

            // Actualizando el par�metro IsMoving del Animator
            isMoving = true;
        }
        else
        {
            // Si el jugador no est� detectado, realizar el "paseo"
            Roam();

            // Actualizar el par�metro IsMoving en el Animator
            animator.SetBool("IsMoving", isMoving);
        }
    }

    // Funci�n para el comportamiento de "paseo"
    void Roam()
    {
        // Si es hora de cambiar la direcci�n de "paseo"
        if (Time.time >= nextRoamTime)
        {
            // Cambiar la direcci�n de "paseo" de forma aleatoria
            roamDirection = Random.insideUnitCircle.normalized;

            // Calcular el pr�ximo tiempo de cambio de direcci�n
            nextRoamTime = Time.time + roamInterval;
        }

        // Mover al enemigo en la direcci�n de "paseo" con la velocidad de "paseo"
        transform.Translate(roamDirection * roamSpeed * Time.deltaTime);

        // Actualizar la variable de movimiento
        isMoving = true;
    }
}
