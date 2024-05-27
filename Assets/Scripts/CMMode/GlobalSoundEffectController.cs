using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundEffectController : MonoBehaviour
{
    public static GlobalSoundEffectController instance;

    private float volume = 1.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetVolume(float volume)
    {
        this.volume = volume;
        UpdateSoundEffectsVolume();
    }

    public float GetVolume()
    {
        return volume;
    }

    public void UpdateSoundEffectsVolume()
    {
        // Buscar todos los objetos con el tag "SoundEffect" y ajustar su volumen
        GameObject[] soundEffectObjects = GameObject.FindGameObjectsWithTag("SoundEffect");
        foreach (GameObject obj in soundEffectObjects)
        {
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = volume;
            }
        }
    }
}
