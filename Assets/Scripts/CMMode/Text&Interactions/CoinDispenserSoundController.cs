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

    // M�todo para reproducir el sonido de la m�quina dispensadora
    public void PlayCoinDispenseSound()
    {
        audioSource.Play();
    }
}
