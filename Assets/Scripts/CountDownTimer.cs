using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text countdownText;
    public float timeRemaining = 5f;
    public GameStarter gameStarter; // Referencia al script GameStarter
    private bool isTimerRunning = true; // Variable para controlar si el temporizador está corriendo

    void Start()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void UpdateTimer()
    {
        if (isTimerRunning)
        {
            timeRemaining -= 1f;
            countdownText.text = timeRemaining > 0 ? timeRemaining.ToString("0") : "";

            if (timeRemaining <= 0)
            {
                gameStarter.StartGame(); // Llamar a la función StartGame() para iniciar el juego
                CancelInvoke("UpdateTimer");
                countdownText.gameObject.SetActive(false);
            }
        }
    }
}
