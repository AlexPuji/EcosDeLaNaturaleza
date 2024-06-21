using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public Button returnButton; // Asigna el bot�n desde el inspector
    public string mainMenuScene = "MainMenu"; // Nombre de la escena del men� principal

    private void Start()
    {
        if (returnButton != null)
        {
            returnButton.onClick.AddListener(ReturnToMainMenu);
        }
        else
        {
            Debug.LogError("El bot�n no est� asignado en el inspector.");
        }
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
