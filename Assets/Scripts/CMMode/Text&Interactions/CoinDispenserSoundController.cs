using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDispenserSoundController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido de la máquina dispensadora
    public void PlayCoinDispenseSound()
    {
        audioSource.Play();
    }
}
