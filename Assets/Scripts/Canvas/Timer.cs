using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float gameTimeInSeconds = 305f; 
    private float remainingTime; 
    public Text timerText; 

    void Start()
    {
        remainingTime = gameTimeInSeconds;
    }

    void Update()
    {
        
        remainingTime -= Time.deltaTime;

        
        UpdateTimerText();

        
        if (remainingTime <= 0)
        {
            EndGame();
        }
    }

    void UpdateTimerText()
    {
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Actualizar el texto del temporizador
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        
        SceneManager.LoadScene("LoadingScene");
    }
}
