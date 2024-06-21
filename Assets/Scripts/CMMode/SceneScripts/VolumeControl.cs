using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Asignar el valor inicial del volumen al slider
        if (GlobalMusicController.instance != null)
        {
            volumeSlider.value = GlobalMusicController.instance.GetVolume();
        }

        // Añadir listener para cuando el valor del slider cambia
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        if (GlobalMusicController.instance != null)
        {
            GlobalMusicController.instance.SetVolume(volume);
        }
    }
}
