using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    public Text livesText; // Referencia al componente Texto del Canvas
    public PlayerHealth playerHealth; // Referencia al script PlayerHealth

    void Update()
    {
        // Verificar si la referencia al componente Texto está asignada y si el script PlayerHealth está asignado
        if (livesText != null && playerHealth != null)
        {
            // Actualizar el texto del componente Texto con la cantidad de vidas restantes del jugador
            livesText.text = "Vidas: " + playerHealth.currentLives.ToString();
        }
    }
}
