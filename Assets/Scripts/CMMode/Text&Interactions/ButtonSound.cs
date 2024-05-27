using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip buttonHoverSound; // Sonido al pasar el ratón por encima del botón
    private AudioSource audioSource;

    void Start()
    {
        // Obtener o agregar el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asegurarse de que el sonido no se reproduzca al inicio
        audioSource.playOnAwake = false;
    }

    // Método para reproducir el sonido del botón
    void PlayButtonSound()
    {
        if (audioSource != null && buttonHoverSound != null)
        {
            // Reproducir el sonido del botón una vez
            audioSource.PlayOneShot(buttonHoverSound);
        }
    }

    // Método llamado cuando el ratón entra en el área del botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayButtonSound();
    }

    // Método llamado cuando el ratón sale del área del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        // Puedes añadir cualquier lógica adicional aquí si es necesario
    }
}