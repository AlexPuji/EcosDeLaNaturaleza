using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorSoundController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido de la puerta cerrada
    public void PlayLockedDoorSound()
    {
        audioSource.Play();
    }
}
