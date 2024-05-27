using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSoundController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido de la explosión
    public void PlayExplosionSound()
    {
        audioSource.Play();
    }
}
