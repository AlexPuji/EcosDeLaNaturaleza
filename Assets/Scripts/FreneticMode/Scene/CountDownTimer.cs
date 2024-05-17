using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text countdownText;
    public float timeRemaining = 3f;
    public GameStarter gameStarter; // Referencia GameStarter Script
    private bool isTimerRunning = true; // control del temporizador

    void Start()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f);
    }

    void UpdateTimer()
    {
        if (isTimerRunning)
        {
            //Funcionament
            timeRemaining -= 1f;
            countdownText.text = timeRemaining > 0 ? timeRemaining.ToString("0") : "";

            if (timeRemaining <= 0)
            {
                gameStarter.StartGame(); 
                CancelInvoke("UpdateTimer");
                countdownText.gameObject.SetActive(false);
            }
        }
    }
}
