using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSoundController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido al abrir el cofre
    public void PlayOpenSound()
    {
        audioSource.Play();
    }
}
