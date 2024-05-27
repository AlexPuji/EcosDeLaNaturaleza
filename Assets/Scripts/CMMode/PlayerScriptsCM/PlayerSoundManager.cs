using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    private AudioSource walkAudioSource;
    private AudioSource attackAudioSource;
    private Rigidbody2D rb;
    private Animator animator;
    public float stepInterval = 0.5f; // Intervalo entre pasos en segundos
    private bool isWalking;

    void Start()
    {
        // Obteniendo ambos AudioSources
        AudioSource[] audioSources = GetComponents<AudioSource>();
        walkAudioSource = audioSources[0];
        attackAudioSource = audioSources[1];

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogWarning("No Animator component found on " + gameObject.name);
        }

        walkAudioSource.loop = false; // Asegúrate de que el sonido no se reproduzca en bucle por defecto
    }

    void Update()
    {
        // Verificar si el personaje se está moviendo
        if (animator.GetBool("IsRunning"))
        {
            if (!isWalking)
            {
                isWalking = true;
                StartCoroutine(PlayStepSound());
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                StopCoroutine(PlayStepSound());
            }
        }
    }

    private IEnumerator PlayStepSound()
    {
        while (isWalking)
        {
            walkAudioSource.Play();
            yield return new WaitForSeconds(stepInterval);
        }
    }

    // Método para reproducir el sonido de ataque
    public void PlayAttackSound()
    {
        attackAudioSource.Play();
    }
}
