using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public float cycleDuration = 120f; // Duración completa de un ciclo día-noche en segundos
    private float currentTime = 0f;
    public Text timerText;
    public Image dayNightIcon;
    public Sprite daySprite;
    public Sprite nightSprite;
    public GameObject nightWarningMessage; // Mensaje de advertencia para la noche

    private static bool isNight = false; // Variable estática para indicar si es de noche

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= cycleDuration)
        {
            currentTime = 0f; // Reinicia el tiempo al llegar al final del ciclo
        }

        // Actualiza el texto del timer
        float currentHour = (currentTime / cycleDuration) * 24f;
        int hour = Mathf.FloorToInt(currentHour);
        int minute = Mathf.FloorToInt((currentHour - hour) * 60f);
        timerText.text = string.Format("{0:00}:{1:00}", hour, minute);

        // Actualiza el icono de día/noche
        if (currentHour >= 7 && currentHour < 21)
        {
            // Es de día
            dayNightIcon.sprite = daySprite; // Asigna el sprite del sol
            nightWarningMessage.SetActive(false); // Desactiva el mensaje de advertencia
            isNight = false;
        }
        else
        {
            // Es de noche
            dayNightIcon.sprite = nightSprite; // Asigna el sprite de la luna
            nightWarningMessage.SetActive(true); // Activa el mensaje de advertencia
            isNight = true;
        }
    }

    public static bool IsNight()
    {
        return isNight;
    }
}
