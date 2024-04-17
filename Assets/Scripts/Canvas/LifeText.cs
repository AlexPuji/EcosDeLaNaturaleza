using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    public Text livesText; 
    public PlayerHealth playerHealth; 

    void Update()
    {
        
        if (livesText != null && playerHealth != null)
        {
            
            livesText.text = "Vidas: " + playerHealth.currentLives.ToString();
        }
    }
}
