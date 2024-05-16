using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public float cycleDuration = 120f; // Duración del ciclo 
    private float currentTime = 0f;
    public Text timerText;
    public Image dayNightIcon;
    public Sprite daySprite;
    public Sprite nightSprite;
    public GameObject nightWarningMessage;
    public GameObject nightOverlay;

    private static bool isNight = false;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= cycleDuration)
        {
            currentTime = 0f; // Reinicio del tiempo
        }

        float currentHour = (currentTime / cycleDuration) * 24f;
        int hour = Mathf.FloorToInt(currentHour);
        int minute = Mathf.FloorToInt((currentHour - hour) * 60f);
        timerText.text = string.Format("{0:00}:{1:00}", hour, minute);

        // Iconos día y noche 
        if (nightWarningMessage != null && nightOverlay != null)
        {
            if (currentHour >= 7 && currentHour < 21)
            {
                dayNightIcon.sprite = daySprite;
                nightWarningMessage.SetActive(false);
                nightOverlay.SetActive(false);
                isNight = false;
            }
            else
            {
                dayNightIcon.sprite = nightSprite;
                nightWarningMessage.SetActive(true);
                nightOverlay.SetActive(true);
                isNight = true;
            }
        }
        else
        {
            Debug.LogWarning("nightWarningMessage o nightOverlay es nulo.");
        }
    }

    public static bool IsNight()
    {
        return isNight;
    }
}
