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

    // M�todo para reproducir el sonido de la explosi�n
    public void PlayExplosionSound()
    {
        audioSource.Play();
    }
}
