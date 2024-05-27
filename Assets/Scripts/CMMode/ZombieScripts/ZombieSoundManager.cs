using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundManager : MonoBehaviour
{
    public float detectionDistance = 5f; // Distancia de detección del jugador
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

        // Asegurarse de que el sonido de detección no se reproduzca al inicio
        audioSource.playOnAwake = false;

        if (detectionSound == null)
        {
            Debug.LogWarning("¡No se ha asignado ningún sonido de detección al ZombieSoundManager!");
        }
    }

    void Update()
    {
        if (!hasDetectedPlayer)
        {
            // Verificar si el jugador está dentro del rango de detección
            if (IsPlayerWithinDetectionRange())
            {
                // Reproducir el sonido de detección
                PlayDetectionSound();
                hasDetectedPlayer = true;
            }
        }
    }

    bool IsPlayerWithinDetectionRange()
    {
        // Calcular la distancia entre el zombie y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Devolver true si la distancia es menor que la distancia de detección del zombie
        return distanceToPlayer < detectionDistance;
    }

    void PlayDetectionSound()
    {
        // Verificar si el AudioSource y el AudioClip de detección están asignados
        if (audioSource != null && detectionSound != null)
        {
            // Reproducir el sonido de detección una vez
            audioSource.PlayOneShot(detectionSound);
        }
    }

    public void PlayCollisionSound()
    {
        // Verificar si el AudioSource y el AudioClip de colisión están asignados
        if (audioSource != null && collisionSound != null)
        {
            // Reproducir el sonido de colisión una vez
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
