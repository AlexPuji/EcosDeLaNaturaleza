using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundManager : MonoBehaviour
{
    public float detectionDistance = 5f; // Distancia de detecci�n del jugador
    public AudioClip detectionSound; // Sonido a reproducir cuando se detecta al jugador
    public AudioClip collisionSound; // Sonido a reproducir cuando el zombie colisiona con el jugador
    private AudioSource audioSource;
    private bool hasDetectedPlayer = false;
    private Transform player; // Referencia al jugador

    void Start()
    {
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Obtener la referencia al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Agregar un componente AudioSource si no existe
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asegurarse de que el sonido de detecci�n no se reproduzca al inicio
        audioSource.playOnAwake = false;

        if (detectionSound == null)
        {
            Debug.LogWarning("�No se ha asignado ning�n sonido de detecci�n al ZombieSoundManager!");
        }
    }

    void Update()
    {
        if (!hasDetectedPlayer)
        {
            // Verificar si el jugador est� dentro del rango de detecci�n
            if (IsPlayerWithinDetectionRange())
            {
                // Reproducir el sonido de detecci�n
                PlayDetectionSound();
                hasDetectedPlayer = true;
            }
        }
    }

    bool IsPlayerWithinDetectionRange()
    {
        // Calcular la distancia entre el zombie y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Devolver true si la distancia es menor que la distancia de detecci�n del zombie
        return distanceToPlayer < detectionDistance;
    }

    void PlayDetectionSound()
    {
        // Verificar si el AudioSource y el AudioClip de detecci�n est�n asignados
        if (audioSource != null && detectionSound != null)
        {
            // Reproducir el sonido de detecci�n una vez
            audioSource.PlayOneShot(detectionSound);
        }
    }

    public void PlayCollisionSound()
    {
        // Verificar si el AudioSource y el AudioClip de colisi�n est�n asignados
        if (audioSource != null && collisionSound != null)
        {
            // Reproducir el sonido de colisi�n una vez
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
