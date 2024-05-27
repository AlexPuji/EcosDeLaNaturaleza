using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Verificar si GlobalSoundEffectController está inicializado correctamente
        if (GlobalSoundEffectController.instance != null)
        {
            // Asignar el valor inicial del volumen al slider
            volumeSlider.value = GlobalSoundEffectController.instance.GetVolume();

            // Añadir listener para cuando el valor del slider cambia
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            Debug.LogWarning("GlobalSoundEffectController is not initialized properly.");
        }
    }

    void SetVolume(float volume)
    {
        if (GlobalSoundEffectController.instance != null)
        {
            GlobalSoundEffectController.instance.SetVolume(volume);
        }
        else
        {
            Debug.LogWarning("GlobalSoundEffectController is not initialized properly.");
        }
    }
}
