using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip buttonHoverSound; // Sonido al pasar el rat�n por encima del bot�n
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

    // M�todo para reproducir el sonido del bot�n
    void PlayButtonSound()
    {
        if (audioSource != null && buttonHoverSound != null)
        {
            // Reproducir el sonido del bot�n una vez
            audioSource.PlayOneShot(buttonHoverSound);
        }
    }

    // M�todo llamado cuando el rat�n entra en el �rea del bot�n
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayButtonSound();
    }

    // M�todo llamado cuando el rat�n sale del �rea del bot�n
    public void OnPointerExit(PointerEventData eventData)
    {
        // Puedes a�adir cualquier l�gica adicional aqu� si es necesario
    }
}