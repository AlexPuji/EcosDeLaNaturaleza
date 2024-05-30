using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSoundPlayer : MonoBehaviour
{
    public AudioSource collectSoundAudio; // Referencia pública al AudioSource

    void Start()
    {
        if (collectSoundAudio == null)
        {
            Debug.LogWarning("AudioSource para el sonido de recolección no asignado.");
        }
    }

    public void PlayCollectSound()
    {
        if (collectSoundAudio != null)
        {
            Debug.Log("Reproduciendo sonido: " + collectSoundAudio.clip.name);
            collectSoundAudio.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource para el sonido de recolección no encontrado.");
        }
    }
}
